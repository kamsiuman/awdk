using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Awdk.Skus.Framework.Entity.ValueObject;

namespace Awdk.Skus.Framework.DataAccess.EF.Models.Mapping
{
    public class SkUserMap : EntityTypeConfiguration<SkUserVo>
    {
        public SkUserMap()
        {
            // Primary Key
            this.HasKey(t => t.SkUserId);

            // Properties
            this.Property(t => t.Alias)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SkUser", "fwk");
            this.Property(t => t.SkUserId).HasColumnName("SkUserId");
            this.Property(t => t.Alias).HasColumnName("Alias");
            this.Property(t => t.RoleTypeId).HasColumnName("RoleTypeId");

            // Relationships
            this.HasRequired(t => t.RoleType)
                .WithMany(t => t.SkUsers)
                .HasForeignKey(d => d.RoleTypeId);

        }
    }
}
