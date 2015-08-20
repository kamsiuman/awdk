using System.Web.Http;
using Awdk.Skus.Framework.Service.Data;
using Awdk.Skus.Framework.WebAPI.Controllers;
using Microsoft.Practices.Unity;
using Awdk.Skus.Framework.DataAccess.Repository;
using Awdk.Skus.Framework.Service.Data;
using Awdk.Skus.Framework.Service.Notification;
//using Awdk.Skus.Framework.Service.Unit;
//using Awdk.Skus.Framework.Service.UserAccount;
using Awdk.Skus.Framework.WebAPI.Controllers;
using Awdk.Skus.Framework.WebAPI.Injection;

namespace Awdk.Skus.Service
{
    /// <summary>
    /// Dependency injection
    /// </summary>
    public class DependencyInjectionConfig
    {
        /// <summary>
        /// Register dependency injection
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            var container = DoRegister(config);
            container.Resolve<NotificationLogger>();
        }

        public static UnityContainer DoRegister(HttpConfiguration config)
        {
            var container = new UnityContainer();

            RepositoryConfig.RegisterDependency(container);
            //UserServiceConfig.RegisterDependency(container);
            DataServiceConfig.RegisterDependency(container);
            container.RegisterType<NotificationLogger>(new ContainerControlledLifetimeManager());
            container.RegisterType<IPrincipleProvider, PrincipleProvider>(new HierarchicalLifetimeManager());
            //container.RegisterType<IUnitServiceProvider, UnitServiceProvider>(new ContainerControlledLifetimeManager());
            NotificationServiceConfig.RegisterDependency(container);
            config.DependencyResolver = new UnityResolver(container);
            return container;
        }
    }
}