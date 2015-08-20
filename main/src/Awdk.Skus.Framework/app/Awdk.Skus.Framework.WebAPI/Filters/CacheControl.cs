using System;
using System.Net.Http.Headers;
using System.Web.Http.Filters;


namespace Awdk.Skus.Framework.WebAPI.Filters
{
    public class CacheControl : ActionFilterAttribute
    {
        public int MaxAge { get; set; }
        public bool Public { get; set; }
        public bool Private { get; set; }
        public bool NoCache { set; get; }
        public CacheControl()
        {
            MaxAge = 3600;
            Public = true;
            Private = false;
            NoCache = false;
        }

        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            context.Response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                Public = this.Public,
                Private = this.Private,
                NoCache = this.NoCache,
                MaxAge = TimeSpan.FromSeconds(this.MaxAge)
            };

            base.OnActionExecuted(context);
        }
    }
}