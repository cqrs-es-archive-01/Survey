using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Transverse.Domain.Users;

namespace Survey.Transverse.Infrastracture.Data.Mapping
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USERS",schema:DbSchemaNames.Identity);

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(100);
            builder.Property(a => a.FirstName).HasMaxLength(50);
            builder.Property(a => a.LastName).HasMaxLength(50);
            builder.Property(a => a.Timestamp).IsRowVersion();
            builder.Property(a => a.DeleteReason).HasMaxLength(250);

            builder.HasMany<UserPermission>(a => a.UserPermissions)
              .WithOne(a => a.User)
              .HasForeignKey(a => a.UserId)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
