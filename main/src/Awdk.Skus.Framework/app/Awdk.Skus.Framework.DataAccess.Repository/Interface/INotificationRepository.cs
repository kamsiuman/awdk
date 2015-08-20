using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Awdk.Skus.Framework.Common.Identity;
using Awdk.Skus.Framework.Entity.ValueObject;

namespace Awdk.Skus.Framework.DataAccess.Repository.Interface
{
    public interface INotificationRepository
    {
        /// <summary>
        /// Returns notifications that can be sent to userAlias from all the specified projects.
        /// </summary>
        /// <param name="userAlias"></param>
        /// <param name="projectIds"></param>
        /// <returns></returns>
        //IEnumerable<NotificationVO> GetNotificationsFor(string userAlias, IEnumerable<WorkspaceEntityId> projectIds);
        IEnumerable<NotificationVO> GetNotificationsFor(string userAlias, IEnumerable<int> projectIds);

        /// <summary>
        /// Insert/store a notification
        /// </summary>
        /// <param name="?"></param>
        void Insert(NotificationVO notification);
    }
}



//namespace Slb.TaiJi.Framework.DataAccess.Repository.Studio
//{
//    public interface INotificationStudioRepository
//    {
//        /// <summary>
//        /// Returns notifications that can be sent to userAlias from all the specified projects.
//        /// </summary>
//        /// <param name="userAlias"></param>
//        /// <param name="projectIds"></param>
//        /// <returns></returns>
//        IEnumerable<NotificationVO> GetNotificationsFor(string userAlias, IEnumerable<WorkspaceEntityId> projectIds);

//        /// <summary>
//        /// Insert/store a notification
//        /// </summary>
//        /// <param name="?"></param>
//        void Insert(NotificationVO notification);
//    }
//}
