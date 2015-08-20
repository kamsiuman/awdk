using System;
using System.Collections.Generic;

namespace Awdk.Skus.Framework.Entity.ValueObject
{
    public partial class RoleTypeVo
    {
        public RoleTypeVo()
        {
            this.SkUsers = new List<SkUserVo>();
        }

        public int RoleTypeId { get; set; }
        public string RoleTypeName { get; set; }
        public virtual ICollection<SkUserVo> SkUsers { get; set; }
    }
}
