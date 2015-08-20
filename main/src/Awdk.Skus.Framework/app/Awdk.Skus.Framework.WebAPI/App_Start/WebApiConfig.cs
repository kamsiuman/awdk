using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Awdk.Skus.Framework.WebAPI.Filters;
using Awdk.Skus.Framework.WebAPI.Handlers;

namespace Awdk.Skus.Framework.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MessageHandlers.Add(new AuthenticateHandler());

//            RegisterRouteAndHandler(config);
        }

        public static void RegisterRouteAndHandler(HttpConfiguration config)
        {

            RegisterFormatter(config);
            config.Filters.Add(new ExceptionHandlingAttribute());
        }

        private static void RegisterFormatter(HttpConfiguration config)
        {
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
        }
    }
}
