using System;
using System.Collections.Generic;

namespace Awdk.Skus.Framework.Entity.ValueObject
{
    public class SkUserVo
    {
        public SkUserVo()
        {
            this.Events = new List<EventVo>();
        }

        public int SkUserId { get; set; }
        public string Alias { get; set; }
        public int RoleTypeId { get; set; }
        public virtual ICollection<EventVo> Events { get; set; }
        public virtual RoleTypeVo RoleType { get; set; }
    }
}
