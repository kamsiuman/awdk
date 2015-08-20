using System.Net.Http.Headers;
using System.Web.Http.Filters;

namespace Awdk.Skus.Framework.WebAPI.Filters
{
    /// <summary>
    /// add http content type in response header
    /// </summary>
    public class ContentType : ActionFilterAttribute
    {           
        public string MediaType { get; set; }
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            context.Response.Content.Headers.ContentType = new MediaTypeHeaderValue(MediaType);

            base.OnActionExecuted(context);
        }
    }
}