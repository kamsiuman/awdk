using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
//using Slb.TaiJi.Framework.DataAccess.Repository.Studio;
//using Slb.TaiJi.Framework.DataAccess.Studio;
//using Slb.TaiJi.Framework.Service.UserAccount;
using Awdk.Skus.Framework.WebAPI.Identity;

namespace Awdk.Skus.Framework.WebAPI.Handlers
{
    public class AuthenticateHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (InExemption(request.RequestUri)||SetCurrentUser(request))
            {
                return base.SendAsync(request, cancellationToken);
            }
            return CreateFailureResponseAsync();
        }

        private bool InExemption(Uri requestUri)
        {
            return requestUri.AbsoluteUri.ToLower(CultureInfo.InvariantCulture).Contains("accesstoken");
        }

        private Task<HttpResponseMessage> CreateFailureResponseAsync()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Forbidden)
            {
                Content = new StringContent("Forbidden: No permission to access the server.")
            };
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);   
            return tsc.Task;
        }

        private bool SetCurrentUser(HttpRequestMessage req)
        {
            var alias = GetUserAlias(GetTokenFromCookie(req));
            if (string.IsNullOrEmpty(alias)) return false;
            SetUserIdentity(alias);
            return true;
        }

        private string GetTokenFromCookie(HttpRequestMessage req)
        {
            var cookie = req.Headers.GetCookies(AuthCookie()).FirstOrDefault();
            return cookie == null ? string.Empty : cookie[AuthCookie()].Value;
        }
        private string AuthCookie()
        {
            return ConfigurationManager.AppSettings["TaiJiAuthentication.Cookie.Name"];
        }
        private string GetUserAlias(string userToken)
        {
            //var accountService = new UserAccountService(new TJUserStudioRepository(new StudioDataAccessor()));
            //return accountService.GetUserAlias(userToken);
            return "alex";
        }

        private static void SetUserIdentity(string alias)
        {
            Thread.CurrentPrincipal = GetTaiJiPrincipal(alias);
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = GetTaiJiPrincipal(alias);
            }
        }

        private static SkusPrincipal GetTaiJiPrincipal(string alias)
        {
            var userIdentity = new TaiJiIdentity() {Name = alias.ToLower(CultureInfo.InvariantCulture)};
            var principal = new SkusPrincipal(userIdentity, null);
            return principal;
        }
    }
}