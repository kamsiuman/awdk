using System.Web;

namespace Awdk.Skus.Framework.WebAPI.Controllers
{
    public class PrincipleProvider : IPrincipleProvider
    {
        public string CurrentUserAlias
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    return HttpContext.Current.User.Identity.Name;
                }
                return string.Empty;
            }
        }
    }
}