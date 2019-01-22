using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SIS.Framework.Common;

namespace SIS.Framework.Views
{
    public class ViewEngine
    {
	private string ViewsFolderPath => MvcContext.Get.AppPath
	    + Constants.FolderSeparator + MvcContext.Get.ViewsFolderName;

	private string SharedViewsFolderPath => ViewsFolderPath
	    + Constants.FolderSeparator + MvcContext.Get.SharedViewsFolderName;

	private string DisplayTemplatesFolderPath => SharedViewsFolderPath
	    + Constants.FolderSeparator + MvcContext.Get.DisplayTemplatesFolderName;

	private string LayoutViewFilePath => SharedViewsFolderPath
	    + Constants.FolderSeparator + MvcContext.Get.LayoutViewName
	    + Constants.HtmlFileExtension;

	private string ErrorViewFilePath => SharedViewsFolderPath
	    + Constants.FolderSeparator + MvcContext.Get.ErrorViewName
	    + Constants.HtmlFileExtension;

	private string GetDisplayTemplateFilePath(string templateName)
	{
	    string displayTemplateFilePath = DisplayTemplatesFolderPath
		+ Constants.FolderSeparator + templateName
		+ MvcContext.Get.DisplayTemplatesSuffix
		+ Constants.HtmlFileExtension;
	    return displayTemplateFilePath;
	}

	public string RenderHtml(string controllerName, string actionName, IDictionary<string, object> viewData)
	{
	    var layoutHtmlRenderTask = RenderLayoutHtmlAsync(LayoutViewFilePath);
	    string viewFilePath = ViewsFolderPath
		+ Constants.FolderSeparator + controllerName
		+ Constants.FolderSeparator + actionName
		+ Constants.HtmlFileExtension;
	    var viewHtmlLoadTask = RenderViewHtmlAsync(viewFilePath);
	    var errorHtmlRenderTask = RenderErrorHtmlAsync(ErrorViewFilePath);
	    string content = string.Empty;
	    string errorMessage = string.Empty;
	    if (layoutHtmlRenderTask.IsFaulted)
	    {
		return layoutHtmlRenderTask.Exception.InnerException.Message;
	    }
	    else content = layoutHtmlRenderTask.Result;
	    if (viewHtmlLoadTask.IsFaulted)
	    {
		content = content.Replace(Constants.HtmlBodyPlaceholder, string.Empty);
		if (errorHtmlRenderTask.IsFaulted)
		{
		    content = content.Replace(Constants.HtmlErrorPlaceholder,
			viewHtmlLoadTask.Exception.InnerException.Message);
		}
		else
		{
		    errorMessage = errorHtmlRenderTask.Result.Replace(
			Constants.HtmlErrorMessagePlaceholder,
			viewHtmlLoadTask.Exception.InnerException.Message);
		    content = content.Replace(Constants.HtmlErrorPlaceholder, errorMessage);
		}
	    }
	    else content = content.Replace(Constants.HtmlBodyPlaceholder, viewHtmlLoadTask.Result);
	    if (viewData.ContainsKey(Constants.ErrorKey))
	    {
		if (errorHtmlRenderTask.IsFaulted)
		{
		    errorMessage = errorHtmlRenderTask.Exception.InnerException.Message +
			"<br />" + viewData[Constants.ErrorKey].ToString();
		}
		else
		{
		    errorMessage = errorHtmlRenderTask.Result.Replace(
			Constants.HtmlErrorMessagePlaceholder,
			viewData[Constants.ErrorKey].ToString());
		}
		content = content.Replace(Constants.HtmlErrorPlaceholder, errorMessage);
		viewData.Remove(Constants.ErrorKey);
	    }
	    else content = content.Replace(Constants.HtmlErrorPlaceholder, string.Empty);
	    foreach (var item in viewData)
	    {
		content = RenderViewData(content, item.Key, item.Value);
	    }
	    return content;
	}

	private async Task<string> RenderLayoutHtmlAsync(string layoutViewFilePath)
	{
	    if (!File.Exists(layoutViewFilePath))
	    {
		throw new FileNotFoundException(
		    string.Format(Constants.ViewNotFoundMessage, "Layout ", $" at: {layoutViewFilePath}"),
		    layoutViewFilePath.Split('/', StringSplitOptions.RemoveEmptyEntries).Last());
	    }
	    return await File.ReadAllTextAsync(layoutViewFilePath);
	}

	private async Task<string> RenderViewHtmlAsync(string viewFilePath)
	{
	    if (!File.Exists(viewFilePath))
	    {
		throw new FileNotFoundException(
		    string.Format(Constants.ViewNotFoundMessage, string.Empty, $" at: {viewFilePath}"),
		    viewFilePath.Split('/', StringSplitOptions.RemoveEmptyEntries).Last());
	    }
	    return await File.ReadAllTextAsync(viewFilePath);
	}

	private async Task<string> RenderErrorHtmlAsync(string errorViewFilePath)
	{
	    if (!File.Exists(errorViewFilePath))
	    {
		throw new FileNotFoundException(
		    string.Format(Constants.ViewNotFoundMessage, "Error ", $" at: {errorViewFilePath}"),
		    errorViewFilePath.Split('/', StringSplitOptions.RemoveEmptyEntries).Last());
	    }
	    return await File.ReadAllTextAsync(errorViewFilePath);
	}

	private string RenderViewData(string template, string viewObjectName, object viewObject)
	{
	    if (viewObject == null) return template;
	    string objectPlaceholder = $"{Constants.ModelPlaceholder}.{viewObjectName}";
	    if (viewObject.GetType().IsPrimitive || viewObject.GetType() == typeof(string))
	    {
		if (viewObject.GetType() == typeof(bool))
		{
		    return template.Replace(objectPlaceholder, viewObject.ToString().ToLower());
		}
		return template.Replace(objectPlaceholder, viewObject.ToString());
	    }
	    if (viewObject is IEnumerable collection
		&& Regex.IsMatch(template, Constants.ModelCollectionPattern))
	    {
		Match collectionMatch = Regex.Matches(template, Constants.ModelCollectionPattern)
		    .FirstOrDefault(m => m.Groups["collection"].Value == viewObjectName);
		if (!collectionMatch.Success) return template;
		string itemMatch = collectionMatch.Groups["item"].Value;
		StringBuilder collectionItems = new StringBuilder("\r\n");
		foreach (var item in collection)
		{
		    string itemData = string.Empty;
		    if (item.GetType().IsPrimitive || item.GetType() == typeof(string))
		    {
			string itemName = item.GetType().Name;
			itemData = RenderViewData(itemMatch, itemName, item);
		    }
		    else itemData = RenderViewData(itemMatch, null, item);
		    string collectionItem = itemMatch.Replace(Constants.ItemPlaceholder, itemData);
		    collectionItems.Append($"{collectionItem}\r\n");
		}
		return template.Replace(collectionMatch.Value, collectionItems.ToString());
	    }
	    if (!viewObject.GetType().IsPrimitive)
	    {
		string displayTemplateName = viewObject.GetType().Name;
		string displayTemplateFilePath = GetDisplayTemplateFilePath(displayTemplateName);
		if (File.Exists(displayTemplateFilePath))
		{
		    string displayTemplateContent = File.ReadAllText(displayTemplateFilePath);
		    string renderedObject = RenderObject(viewObject, displayTemplateContent);
		    if (!string.IsNullOrWhiteSpace(viewObjectName))
		    {
			return template.Replace(objectPlaceholder, renderedObject);
		    }
		    else return renderedObject;
		}
	    }
	    return template.Replace(objectPlaceholder, viewObject.ToString());
	}

	private string RenderObject(object viewObject, string displayTemplate)
	{
	    PropertyInfo[] objectProperties = viewObject.GetType().GetProperties(
		BindingFlags.DeclaredOnly
		| BindingFlags.Public
		| BindingFlags.Instance);
	    foreach (var property in objectProperties)
	    {
		displayTemplate = RenderViewData(displayTemplate,
		    property.Name, property.GetValue(viewObject));
	    }
	    return displayTemplate;
	}
    }
}
