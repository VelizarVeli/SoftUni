using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using SIS.Services.Contracts;

namespace SIS.Services
{
    public class EnumerationService : IEnumerationService
    {
	public IEnumerable<string> GetTextValues(Type enumType)
	{
	    Array enumValues = Enum.GetValues(enumType);
	    var enumTextValues = new List<string>();
	    foreach (var enumValue in enumValues)
	    {
		var enumTextValue = enumValue.GetType()
		    .GetMember(enumValue.ToString()).First()
		    .GetCustomAttribute<DisplayNameAttribute>();
		if (enumTextValue != null)
		{
		    enumTextValues.Add(enumTextValue.DisplayName);
		}
		else enumTextValues.Add(enumValue.ToString());
	    }
	    return enumTextValues;
	}

	public string ToTextOrDefault(Type enumType, Enum enumValue)
	{
	    return ToTextOrDefault(enumType, enumValue.ToString());
	}

	public string ToTextOrDefault(Type enumType, int enumValue)
	{
	    return ToTextOrDefault(enumType, enumValue.ToString());
	}

	public string ToTextOrDefault(Type enumType, string enumValue)
	{
	    if (string.IsNullOrWhiteSpace(enumValue)) return null;
	    if (!Enum.TryParse(enumType, enumValue, true, out object validValue)) return null;
	    var targetAttribute = enumType
		.GetMember(enumValue)[0]
		.GetCustomAttribute<DisplayNameAttribute>();
	    if (targetAttribute != null) return targetAttribute.DisplayName;
	    else return enumValue;
	}

	public TEnum ToEnumOrDefault<TEnum>(string enumName) where TEnum : struct
	{
	    if (!Enum.TryParse(enumName, true, out TEnum enumValue))
	    {
		string enumDisplayName = typeof(TEnum).GetFields()
		    .SelectMany(f => f.GetCustomAttributes(typeof(DisplayNameAttribute), false), (f, a) => new { Field = f, Att = a })
		    .Where(a => ((DisplayNameAttribute)a.Att).DisplayName == enumName)
		    .SingleOrDefault().Field.Name;
		if (!Enum.TryParse(enumDisplayName, true, out enumValue)) return default(TEnum);
	    }
	    return enumValue;
	}
    }
}
