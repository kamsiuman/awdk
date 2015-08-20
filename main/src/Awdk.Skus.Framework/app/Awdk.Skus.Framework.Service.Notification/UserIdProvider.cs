using Microsoft.AspNet.SignalR;

namespace Awdk.Skus.Framework.Service.Notification
{
    public class UserIdProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {
            return request.Environment["UserName"].ToString();
        }
    }
}
