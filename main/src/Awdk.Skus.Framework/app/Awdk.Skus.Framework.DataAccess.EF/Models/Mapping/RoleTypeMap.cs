using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Awdk.Skus.Framework.Entity.ValueObject;

namespace Awdk.Skus.Framework.DataAccess.EF.Models.Mapping
{
    public class RoleTypeMap : EntityTypeConfiguration<RoleTypeVo>
    {
        public RoleTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleTypeId);

            // Properties
            this.Property(t => t.RoleTypeName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("RoleType", "fwk");
            this.Property(t => t.RoleTypeId).HasColumnName("RoleTypeId");
            this.Property(t => t.RoleTypeName).HasColumnName("RoleTypeName");
        }
    }
}
