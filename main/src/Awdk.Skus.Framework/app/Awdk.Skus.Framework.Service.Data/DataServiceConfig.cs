using Awdk.Skus.Framework.Service.Data.Interface;
using Microsoft.Practices.Unity;
using Awdk.Skus.Framework.Service.Data;

namespace Awdk.Skus.Framework.Service.Data
{
    public class DataServiceConfig
    {
        public static void RegisterDependency(UnityContainer container)
        {
            RegisterDataService(container);
        }

        private static void RegisterDataService(UnityContainer container)
        {
            container.RegisterType<IEventService, EventService>(new HierarchicalLifetimeManager());
            container.RegisterType<ISkUserService, SkUserService>(new HierarchicalLifetimeManager());            
        }
    }
}