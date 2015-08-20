using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Awdk.Skus.Framework.Entity.ValueObject
{
    public class NotificationVO
    {
        /// <summary>
        /// Create VO with new unique ID.
        /// Note: Currently this type of entity is always stored in the public workspace. 
        /// Thus, for now, we can hard-code the workspace ID to be the public workspace.
        /// </summary>
        public NotificationVO()
        {
        }

        /// <summary>
        /// Create VO with the given ID.
        /// Note: Currently this type of entity is always stored in the public workspace. 
        /// Thus, for now, we can hard-code the workspace ID to be the public workspace.
        /// </summary>
        //public NotificationVO(EntityId entityId)
        //    : base(new WorkspaceEntityId(PublicWorkspaceId, entityId))
        //{
        //}

        /// <summary>
        /// The name of the person who performed the operation that triggered the notification
        /// </summary>
        public string ActorFullName { get; set; }

        /// <summary>
        /// The ID of the project in which the operation is performed
        /// </summary>
        //public WorkspaceEntityId ProjectId { get; set; } 

        /// <summary>
        /// The name of the project in which the operation is performed.
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// The ID of the entity on which the operation is performed.
        /// </summary>
        //public EntityId EntityId { get; set; }

        /// <summary>
        /// The design type on which the operation is performed.
        /// This relates to the EntityId.
        /// </summary>
        public string DesignType { get; set; }

        /// <summary>
        /// The name of the section that may be associated with the activity.
        /// </summary>
        public string SectionName { get; set; }

        /// <summary>
        /// The type of operation/activity
        /// </summary>
        public string ActivityType { get; set; }

        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }


    }
}
