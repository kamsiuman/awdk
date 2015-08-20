using System;
using System.Diagnostics;
using System.Linq;
using Awdk.Skus.Framework.Common.Helpers;
using Awdk.Skus.Framework.DataAccess.Repository.Interface;
using Microsoft.AspNet.SignalR;
using Awdk.Skus.Framework.Common.EventManager;
//using Awdk.Skus.Framework.Common.Identity;
//using Awdk.Skus.Framework.DataAccess.Repository.Studio;
//using Awdk.Skus.Framework.DataAccess.Studio;
using Awdk.Skus.Framework.Entity.ValueObject;
using Slb.TaiJi.Framework.Common.EventManager;
using Awdk.Skus.Framework.DataAccess.EF.Enum;

namespace Awdk.Skus.Framework.Service.Notification
{
    public class NotificationLogger : IDisposable
    {
        private readonly IHubContext hub;

        private readonly IEventRepository eventRepository;
        private readonly ISkUserRepository skUserRepository;
        private INotificationRepository notificationRepository;

        private bool disposed;

        public NotificationLogger(IEventRepository eventRepository, ISkUserRepository skUserRepository, INotificationRepository notificationStudioRepository)
        {
            this.eventRepository = eventRepository;
            this.skUserRepository = skUserRepository;
            this.notificationRepository = notificationStudioRepository;

            hub = GlobalHost.ConnectionManager.GetHubContext<NotificationPushHub>();
            SkusEventManager.Instance.Subscribe(this, "Publish", OnNewDesignShared);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                SkusEventManager.Instance.UnSubscribe(this, "Publish");
            }

            disposed = true;
        }

        private void OnNewDesignShared(object sender, SkusEventArgs args)
        {
            var publishEvent = args.Data as PublishEvent;
            var workspaceId = publishEvent.WorkspaceId;
            //var entityId = new EntityId(publishEvent.EntityIds[0]);
            var entityType = publishEvent.EntityType;
            var isFirstTImePublished = publishEvent.IsFirstTimePublished;
            var actionType = isFirstTImePublished ? "shared" : "updated";

            var notificationVo = GetNotificationVo(entityType, workspaceId, publishEvent.PublishTime, actionType);

            SendNotification(entityType, actionType, notificationVo);
            notificationRepository.Insert(notificationVo);
        }

        private NotificationVO GetNotificationVo(string entityType, string userId, DateTime activityDate, string actionType)
        {
//            var userVo = skUserRepository.GetUserVoFromWorkspaceId(workspaceId);
//            string userAlias = userVo.Alias;

            string sectionName = string.Empty;
            //WorkspaceEntityId wellId = null;
            //var workspaceEntityId = new WorkspaceEntityId(workspaceId, entityId);

            if (entityType == SkusEntityType.SkusEvent)
            {
                //var bhaVo = eventRepository.GetEventsByUserId();
                //var sectionVo = wellStudioRepository.GetSectionByIdLite(bhaVo.SectionId);
                //sectionName = sectionVo.SectionName;
                //wellId = sectionVo.WellId;
            }
            //else if (entityType == SkusEntityType.SkusTraj)
            //{
            //    var trajVo = wellStudioRepository.GetTrajectoryById(workspaceEntityId);
            //    wellId = trajVo.WellId;
            //}

            //Debug.Assert(wellId != null);
            //var projectVo = projectStudioRepository.GetByWellId(wellId).FirstOrDefault();
            var SkusUserVo = skUserRepository.SelectByUserId(userId);

            return new NotificationVO
            {
//                EntityId = entityId,
 //               ProjectId = projectVo.Id,
 //               ProjectName = projectVo.ProjectName,
                SectionName = sectionName,
                DesignType = entityType,
                ActivityType = actionType,
//                CreatedDate = activityDate,
                LastModifiedBy = SkusUserVo.Alias,
                LastModifiedDate = activityDate,
                ActorFullName = SkusUserVo.Alias,
//                CreatedBy = userAlias,
            };
        }

        private void SendNotification(string entityType, string actionType, NotificationVO notificationVo)
        {
            var title = GetNotificationTitle(entityType, notificationVo.ActorFullName, actionType);

            ///
            /// the logic is to send the notification by
            /// 1) getting the list of user (receipant) that assocaited with the project
            /// 2) excluding the creater....
            /// 
            /// 
            /// 
            var content = string.Empty;
            //var projectVo = projectStudioRepository.GetFullProjectById(notificationVo.ProjectId);
            //var receiverList = projectVo.UserAlias.Select(alias => alias.ToUpperInvariant()).
            //    Except(new[] { notificationVo.CreatedBy.ToUpperInvariant() }).ToList();
            
            if (entityType == SkusEntityType.SkusEvent)
            {
                content = "on project {0}, {1}".FormatInvariant(notificationVo.ProjectName, notificationVo.SectionName);
            }
            //if (entityType == SkusEntityType.SkusTraj)
            //{
            //    content = "on project " + notificationVo.ProjectName;
            //}

            var timeStamp = DateTime.UtcNow;
            //hub.Clients.Users(receiverList).serverNotify(new { title, content, timeStamp });
        }

        private string GetNotificationTitle(string entityType, string userFullName, string action)
        {
            return "{0} {1} a {2}".FormatInvariant(userFullName, action, entityType);
        }
    }
}
