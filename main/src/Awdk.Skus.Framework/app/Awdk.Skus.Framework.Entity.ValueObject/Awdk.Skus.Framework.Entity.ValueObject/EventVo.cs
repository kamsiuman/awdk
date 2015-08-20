using System;
using System.Collections.Generic;
using Awdk.Skus.Framework.Entity.ValueObject.Base;

namespace Awdk.Skus.Framework.Entity.ValueObject
{
    public partial class EventVo : BaseVo
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int JobId { get; set; }
        public int SkUserId { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        //public string CreatedBy { get; set; }
        //public System.DateTime CreatedDate { get; set; }
        //public string LastModifiedBy { get; set; }
        //public System.DateTime LastModifiedDate { get; set; }
        public virtual JobVo Job { get; set; }
        public virtual SkUserVo SkUser { get; set; }
    }
}
