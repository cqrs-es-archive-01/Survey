using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Transverse.Domain.Features;
using System;

namespace Survey.Transverse.Infrastracture.Data.Mapping
{
    internal class FeatureMap : IEntityTypeConfiguration<Feature>
    {
        public  void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.ToTable("FEATURES", schema: DbSchemaNames.Identity);
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Label).HasMaxLength(50);
            builder.Property(a => a.Description).HasMaxLength(500);
            builder.Property(a => a.Timestamp).IsRowVersion();

            builder.Property(a => a.Controller).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Action).HasMaxLength(50).IsRequired();
            builder.Property(a => a.ControllerActionName).HasMaxLength(50);
            builder.Ignore(a => a.Disabled);
            builder.Ignore(a => a.Deleted);

            builder.Property(a => a.CreatedOn).HasDefaultValue(DateTime.Now);
            builder.Property(a => a.CreatedBy).HasDefaultValue(Guid.Parse("13A22305-1767-4167-A680-03DAFDF1A260"));

            builder.HasMany(a => a.PermissionFeatures)
                    .WithOne(a => a.Feature)
                    .HasForeignKey(a => a.FeatureId)
                    .IsRequired();

        }
    }
}
