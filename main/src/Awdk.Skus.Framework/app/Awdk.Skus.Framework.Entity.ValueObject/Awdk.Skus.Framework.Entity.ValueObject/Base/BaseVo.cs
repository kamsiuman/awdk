using System;

namespace Awdk.Skus.Framework.Entity.ValueObject.Base
{
    public class BaseVo
    {        
        public BaseVo()
        {
            //Id = Math.Abs(Guid.NewGuid().GetHashCode());
            var now = DateTime.UtcNow;
            CreatedBy = "test";
            CreatedDate = now;
            LastModifiedBy = "test";
            LastModifiedDate = now;
        }
        //public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; } 
    }
}


