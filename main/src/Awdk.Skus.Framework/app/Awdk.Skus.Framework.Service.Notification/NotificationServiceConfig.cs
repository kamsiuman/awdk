using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Awdk.Skus.Framework.Service.Notification.Interface;
using Microsoft.Practices.Unity;

namespace Awdk.Skus.Framework.Service.Notification
{
    public class NotificationServiceConfig
    {
        public static void RegisterDependency(UnityContainer container)
        {
            container.RegisterType<INotificationService, NotificationService>(new HierarchicalLifetimeManager());
        }
    }
}
