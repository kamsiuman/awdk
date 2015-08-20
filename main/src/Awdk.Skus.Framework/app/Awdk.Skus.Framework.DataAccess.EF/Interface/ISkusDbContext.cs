using System.Data.Entity;
using Awdk.Skus.Framework.Entity.ValueObject;

namespace Awdk.Skus.Framework.DataAccess.EF.Interface
{
    public interface ISkusDbContext : IDbContext
    {
        IDbSet<EventVo> Events { get; set; }
        IDbSet<JobVo> Jobs { get; set; }
        IDbSet<RoleTypeVo> RoleTypes { get; set; }
        IDbSet<SkUserVo> SkUsers { get; set; }
    }
}

