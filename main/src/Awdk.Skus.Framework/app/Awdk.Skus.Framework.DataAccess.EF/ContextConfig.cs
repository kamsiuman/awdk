using Awdk.Skus.Framework.DataAccess.EF.Interface;
using Microsoft.Practices.Unity;

namespace Awdk.Skus.Framework.DataAccess.EF
{
    public class ContextConfig
    {
        public static void RegisterDependency(UnityContainer container)
        {
            container.RegisterType<ISkusDbContext, SkusDbContext>(new HierarchicalLifetimeManager());
        }
    }
}