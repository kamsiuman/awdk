using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Awdk.Skus.Framework.Common.Helpers;
//using Awdk.Skus.Framework.Common.Identity;
using Awdk.Skus.Framework.DataAccess.Repository.Interface;
//using Awdk.Skus.Framework.DataAccess.Studio;
using Awdk.Skus.Framework.Entity.ValueObject;

namespace Awdk.Skus.Framework.DataAccess.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        public IEnumerable<NotificationVO> GetNotificationsFor(string userAlias, IEnumerable<int> projectIds)
        {
            throw new NotImplementedException();
        }

        public void Insert(NotificationVO notification)
        {
            throw new NotImplementedException();
        }
    //    private IStudioDataAccessor studioDataAccessor;

    //    public NotificationStudioRepository(IStudioDataAccessor studioDataAccessor)
    //    {
    //        if (studioDataAccessor == null) throw new ArgumentNullException("studioDataAccessor");
    //        this.studioDataAccessor = studioDataAccessor;
    //    }

    //    public IEnumerable<NotificationVO> GetNotificationsFor(string userAlias, IEnumerable<WorkspaceEntityId> projectIds)
    //    {
    //        if (!projectIds.Any())
    //            return Enumerable.Empty<NotificationVO>();

    //        // Query for notifications raised in the specified project and not raised by the specified user.
    //        var propertyConstraints = new[]
    //        {
    //            studioDataAccessor.CreateRawEntityConstraintForTaiJiType(TaiJiEntityType.TaiJiNotification),
    //            studioDataAccessor.CreateRawEntityConstraintForProperty("CreatedByUser", Operator.NotEqual, false,
    //                                                                    userAlias),
    //            studioDataAccessor.CreateRawEntityConstraintForProperty("GroupId", Operator.Equal, false,
    //                                                        projectIds.Select(p => p.EntityId.ToString()).ToArray())
    //        };

    //        return studioDataAccessor.FetchByConstraints(studioDataAccessor.GetPublicWorkspaceId(), propertyConstraints)
    //            .Select(r => r.ToNotificationVo());
    //    }

    //    public void Insert(NotificationVO notification)
    //    {
    //        studioDataAccessor.InsertOrUpdateWithoutLoggingActivity(studioDataAccessor.GetPublicWorkspaceId(),
    //                                                        new[] {notification.ToRawEntity()});
    //    }
    }

}
