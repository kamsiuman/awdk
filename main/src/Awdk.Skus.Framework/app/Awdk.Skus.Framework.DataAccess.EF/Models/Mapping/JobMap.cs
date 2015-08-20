using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Awdk.Skus.Framework.Entity.ValueObject;

namespace Awdk.Skus.Framework.DataAccess.EF.Models.Mapping
{
    public class JobMap : EntityTypeConfiguration<JobVo>
    {
        public JobMap()
        {
            // Primary Key
            this.HasKey(t => t.JobId);

            // Properties
            this.Property(t => t.JobName)
                .HasMaxLength(100);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedBy)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Job", "fwk");
            this.Property(t => t.JobId).HasColumnName("JobId");
            this.Property(t => t.JobName).HasColumnName("JobName");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            this.Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");
        }
    }
}
