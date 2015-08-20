using System.Security.Principal;

namespace Awdk.Skus.Framework.WebAPI.Identity
{
    public class TaiJiIdentity : IIdentity
    {
        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }

        }

        public string Name
        {
            get;
            set;
        }

    }
}
