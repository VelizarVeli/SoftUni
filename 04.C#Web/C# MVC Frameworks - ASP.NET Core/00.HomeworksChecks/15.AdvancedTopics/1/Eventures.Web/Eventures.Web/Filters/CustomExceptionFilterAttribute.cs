using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Eventures.Web.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IModelMetadataProvider modelMetadataProvider;

        public CustomExceptionFilterAttribute(
            IHostingEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.modelMetadataProvider = modelMetadataProvider;
        }

        public override void OnException(ExceptionContext context)
        {
            if (!this.hostingEnvironment.IsDevelopment())
            {
                // do nothing
                return;
            }
            var result = new ViewResult { ViewName = "CustomError" };
            result.ViewData = new ViewDataDictionary(this.modelMetadataProvider, context.ModelState);
            result.ViewData.Add("Exception", context.Exception);
            result.ViewData.Add("ExceptionMessage", context.Exception.Message);
            // Pass additional detailed data via ViewData
            context.Result = result;
        }
    }
}
