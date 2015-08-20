using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awdk.Skus.Framework.Service.Notification.DTO
{
    public class NotificationDTO
    {
        /// <summary>
        /// The time at which the activity/operation is performed
        /// </summary>
        public DateTime ActivityTime { get; set; }

        /// <summary>
        /// The type of operation/activity
        /// </summary>
        public string ActivityType { get; set; }

        /// <summary>
        /// The name of the person who performed the operation that triggered the notification
        /// </summary>
        public string ActorFullName { get; set; }

        /// <summary>
        /// The name of the job in which the operation is performed.
        /// </summary>
        public string JobName { get; set; }
    }

}
