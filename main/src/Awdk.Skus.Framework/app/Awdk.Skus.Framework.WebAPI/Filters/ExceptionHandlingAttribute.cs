using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Web;
using System.Web.Http.Filters;
using Awdk.Skus.Framework.Common.CustomException;
using Newtonsoft.Json;

namespace Awdk.Skus.Framework.WebAPI.Filters
{
    /// <summary>
    /// ExceptionHandling Attribute. Convert .NET exception to meanful HTTP status Code and Content
    /// </summary>
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Gets a dictionary mapping exception types to http status codes.
        /// </summary>
        public Dictionary<Type, HttpStatusCode> ExceptionStatusCodeMap { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ExceptionHandlingAttribute()
        {
            CreateExceptionStatusCodeMap();
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            CreateResponse(context);
        }

        private void CreateExceptionStatusCodeMap()
        {
            ExceptionStatusCodeMap = new Dictionary<Type, HttpStatusCode>
            {
                {
                    typeof (NotSupportedException),
                    HttpStatusCode.MethodNotAllowed
                },
                {
                    typeof(InvalidUserRequestException),
                    HttpStatusCode.BadRequest
                },
                {
                    typeof (NotImplementedException),
                    HttpStatusCode.MethodNotAllowed
                },
                {
                    typeof (ArgumentException),
                    HttpStatusCode.BadRequest
                },
                {
                    typeof (ArgumentNullException),
                    HttpStatusCode.BadRequest
                },
                {
                    typeof (JsonSerializationException),
                    HttpStatusCode.BadRequest
                },
                {
                    typeof (UnauthorizedAccessException),
                    HttpStatusCode.Forbidden
                },
                {
                    typeof (AuthenticationException),
                    HttpStatusCode.Unauthorized
                },
                {
                    typeof (InvalidCredentialException),
                    HttpStatusCode.Unauthorized
                },
                {
                    typeof (FileNotFoundException),
                    HttpStatusCode.NotFound
                },
                {
                    typeof (RecordNotFoundException),
                    HttpStatusCode.NotFound
                },
                {
                    typeof (InvalidOperationException),
                    HttpStatusCode.InternalServerError
                }
            };
        }

        private void CreateResponse(HttpActionExecutedContext context)
        {
            var exType = context.Exception.GetType();

            var status = ExceptionStatusCodeMap.ContainsKey(exType) ? 
                ExceptionStatusCodeMap[exType] : 
                HttpStatusCode.InternalServerError;
            var stckTrace = context.Exception.StackTrace;
            var message = context.Exception.Message + "\r\n" + stckTrace.ToString(CultureInfo.InvariantCulture);
            context.Response = context.Request.CreateResponse(status, message);
            base.OnException(context);
        }
    }
}