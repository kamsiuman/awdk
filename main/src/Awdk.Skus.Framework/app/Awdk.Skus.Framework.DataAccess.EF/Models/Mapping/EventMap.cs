using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Awdk.Skus.Framework.Entity.ValueObject;

namespace Awdk.Skus.Framework.DataAccess.EF.Models.Mapping
{
    public class EventMap : EntityTypeConfiguration<EventVo>
    {
        public EventMap()
        {
            // Primary Key
            this.HasKey(t => t.EventId);

            // Properties
            this.Property(t => t.EventName)
                .HasMaxLength(100);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedBy)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Event", "fwk");
            this.Property(t => t.EventId).HasColumnName("EventId");
            this.Property(t => t.EventName).HasColumnName("EventName");
            this.Property(t => t.JobId).HasColumnName("JobId");
            this.Property(t => t.SkUserId).HasColumnName("SkUserId");
            this.Property(t => t.StartTime).HasColumnName("StartTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            this.Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");

            // Relationships
            this.HasRequired(t => t.Job)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.JobId);
            this.HasRequired(t => t.SkUser)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.SkUserId);

        }
    }
}
