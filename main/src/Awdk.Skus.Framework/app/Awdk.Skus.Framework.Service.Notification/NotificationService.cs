using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Awdk.Skus.Framework.DataAccess.Repository.Interface;
using Awdk.Skus.Framework.Service.Notification.DTO;
using Awdk.Skus.Framework.Service.Notification.Interface;

namespace Awdk.Skus.Framework.Service.Notification
{
    public class NotificationService : INotificationService
    {
        private IEventRepository eventRepository;
        private ISkUserRepository skUserRepository;

        public NotificationService(IEventRepository eventRepository, ISkUserRepository skUserRepository)
        {
            this.eventRepository = eventRepository;
            this.skUserRepository = skUserRepository;
        }

        public IEnumerable<NotificationDTO> GetNotificationsFor(string userAlias)
        {
            // The following notifications can be sent to a user if:
            //    - those raised in a project that the user has joined
            //    - those that are not raised by an activity performed by the user himself.  
            //       notificationRepository.GetNotificationsFor will ensure this.

            //var userProjectIds = this.projectRepository.GetUserJoinedProjects(userAlias).Select(p => p.Id);
            //return this.notificationRepository.GetNotificationsFor(userAlias, userProjectIds).Select(CreateDto);
            return null;
        }

//        private NotificationDTO CreateDto(NotificationVO notificationVo)
        private NotificationDTO CreateDto()
        {
            return new NotificationDTO
            {
                //ActorFullName = notificationVo.ActorFullName,
                //ActivityTime = notificationVo.CreatedDate,
                //ActivityType = notificationVo.ActivityType,
                //DesignType = notificationVo.DesignType,
                //ProjectName = notificationVo.ProjectName,
                //SectionName = notificationVo.SectionName
            };
        }
    }
}
