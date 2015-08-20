using Microsoft.Practices.Unity;
//using Awdk.Skus.Framework.DataAccess.Repository.Studio;
//using Awdk.Skus.Framework.DataAccess.Studio;
using Awdk.Skus.Framework.Entity.ValueObject;
using Awdk.Skus.Framework.DataAccess.Repository.Interface;

namespace Awdk.Skus.Framework.DataAccess.Repository
{
    public class RepositoryConfig
    {
        public static void RegisterDependency(UnityContainer container)
        {
            container.RegisterType<IEventRepository ,EventRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<INotificationRepository, NotificationRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISkUserRepository, SkUserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISkUserRepository, SkUserRepository>(new HierarchicalLifetimeManager());
            
            container.RegisterType<INotificationRepository, NotificationRepository>(
                new HierarchicalLifetimeManager());

        }
    }
}
