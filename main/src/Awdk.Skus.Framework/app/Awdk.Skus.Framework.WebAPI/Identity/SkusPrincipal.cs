using System.Collections;
using System.Security.Principal;

namespace Awdk.Skus.Framework.WebAPI.Identity
{
    public class SkusPrincipal : IPrincipal
    {
        private ArrayList _roles;

        public SkusPrincipal(IIdentity id, ArrayList rolesArray)
        {
            Identity = id;
            _roles = rolesArray;
        }

      
        public bool IsInRole(string role)
        {
            return _roles.Contains(role);
        }

        public IIdentity Identity { get; set; }
    }
}
