using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Transverse.Domain.Users;

namespace Survey.Transverse.Infrastracture.Data.Mapping
{
    internal class UserPermissionMap : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.ToTable("USER_PERMISSIONS",schema:DbSchemaNames.Identity);

            builder.HasKey(a => new { a.PermissionId, a.UserId });

            builder.Property(a => a.AssociatedOn).IsRequired();
            builder.Property(a => a.Timestamp).IsRowVersion();
        }
    }
}
