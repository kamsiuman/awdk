using System;
using System.Collections.Generic;

namespace Awdk.Skus.Framework.Entity.ValueObject
{
    public partial class JobVo
    {
        public JobVo()
        {
            this.Events = new List<EventVo>();
        }

        public int JobId { get; set; }
        public string JobName { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public virtual ICollection<EventVo> Events { get; set; }
    }
}
