using System;
using System.Collections.Concurrent;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Awdk.Skus.Framework.DataAccess.Repository.Interface;


namespace Awdk.Skus.Framework.Service.Notification
{
    [AuthorizeClaims]
    public class NotificationPushHub : Hub
    {
        private static object _syncObj = new object();
        protected static ConcurrentDictionary<string, string> conectionIdToUserId =
            new ConcurrentDictionary<string, string>();

        public override Task OnConnected()
        {
            //Add this to fix a bug for signalr which seems only exists for .net Client. 
            //If firt time server calls clients after caller connected, and caller is not int the list, Caller will never be called
            //So we have to immediately call the caller after it connected to server
            Clients.Caller.pingClient();
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            lock (_syncObj)
            {
                string userId;
                conectionIdToUserId.TryRemove(Context.ConnectionId, out userId);
            }
            return base.OnDisconnected(stopCalled);
        }

        public int GetHubConnectionCount()
        {
            lock (_syncObj)
            {
                var userId = Context.Request.Environment["UserName"].ToString();
                conectionIdToUserId.TryAdd(Context.ConnectionId, userId);
                return conectionIdToUserId.Count(pair => pair.Value == userId);
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class AuthorizeClaimsAttribute : AuthorizeAttribute
    {
        private readonly ISkUserRepository skUserRepository;

        public AuthorizeClaimsAttribute()
        {
            this.skUserRepository = GlobalHost.DependencyResolver.Resolve<ISkUserRepository>();
        }

        public override bool AuthorizeHubConnection(HubDescriptor hubDescriptor, IRequest request)
        {
            var token = request.Cookies[AuthCookieName()].Value;
            var user = skUserRepository.GetUserByToken(token);

            if (user == null) return false;
            request.Environment["UserName"] = user.Alias.ToUpperInvariant();
            return true;
        }

        public override bool AuthorizeHubMethodInvocation(IHubIncomingInvokerContext hubIncomingInvokerContext, bool appliesToMethod)
        {
            return true;
        }

        private string AuthCookieName()
        {
            return ConfigurationManager.AppSettings["TaiJiAuthentication.Cookie.Name"];
        }
    }
}
