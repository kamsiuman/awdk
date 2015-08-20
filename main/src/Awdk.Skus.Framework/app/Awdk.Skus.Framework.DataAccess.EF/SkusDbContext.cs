using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Awdk.Skus.Framework.DataAccess.EF.Base;
using Awdk.Skus.Framework.DataAccess.EF.Interface;
using Awdk.Skus.Framework.DataAccess.EF.Models.Mapping;
using Awdk.Skus.Framework.Entity.ValueObject;
using Awdk.Skus.Framework.Entity.ValueObject.Base;

namespace Awdk.Skus.Framework.DataAccess.EF
{
    public partial class SkusDbContext : DbContextBase<SkusDbContext>, ISkusDbContext
    {
        public IDbSet<EventVo> Events { get; set; }
        public IDbSet<JobVo> Jobs { get; set; }
        public IDbSet<RoleTypeVo> RoleTypes { get; set; }
        public IDbSet<SkUserVo> SkUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EventMap());
            modelBuilder.Configurations.Add(new JobMap());
            modelBuilder.Configurations.Add(new RoleTypeMap());
            modelBuilder.Configurations.Add(new SkUserMap());

            MapBaseVo(modelBuilder);
            MapConcurrencyControlProperty(modelBuilder);
        }


        protected void MapBaseVo(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types<BaseVo>().Configure(c =>
            {
                //c.HasKey(t => t.Id);
                c.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
                c.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
                c.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
                c.Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");
            });
        }

        protected void MapConcurrencyControlProperty(DbModelBuilder modelBuilder)
        {
//            modelBuilder.Entity<EventVo>().Property(p => p.Id).IsRowVersion();
        }
    }

}



