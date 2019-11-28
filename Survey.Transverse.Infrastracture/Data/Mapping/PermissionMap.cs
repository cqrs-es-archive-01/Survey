using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Transverse.Domain.Permissions;
using System;

namespace Survey.Transverse.Infrastracture.Data.Mapping
{
    internal class PermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("PERMISSIONS",schema:DbSchemaNames.Identity);
            builder.HasKey(a => a.Id);


            builder.Property(a => a.Label).HasMaxLength(50);
            builder.Property(a => a.Description).HasMaxLength(500);
            builder.Property(a => a.Timestamp).IsRowVersion();
            builder.Ignore(a => a.Deleted);
            builder.Property(a => a.CreatedOn).HasDefaultValue(DateTime.Now);
            builder.Property(a => a.CreatedBy).HasDefaultValue(Guid.Parse("13A22305-1767-4167-A680-03DAFDF1A260"));

            builder.Ignore(a => a.Disabled);


            builder.HasMany(a => a.PermissionFeatures)
                    .WithOne(a => a.Permission)
                    .HasForeignKey(a => a.PermissionId)
                    .IsRequired();

        }
    }
}
