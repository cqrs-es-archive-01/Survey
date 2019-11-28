using Microsoft.EntityFrameworkCore;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Identity;
using Survey.Transverse.Domain.Permissions;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Infrastracture.Data.Mapping;

namespace Survey.Transverse.Infrastracture.Data
{
    public class TransverseContext:DbContext
    {
        public TransverseContext(DbContextOptions<TransverseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new FeatureMap());
            modelBuilder.ApplyConfiguration(new PermissionMap());
            modelBuilder.ApplyConfiguration(new UserPermissionMap());
            modelBuilder.ApplyConfiguration(new PermissionFeatureMap());
            modelBuilder.ApplyConfiguration(new RefreshTokenMap());



            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Feature> Features { get; set; }

        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<PermissionFeature> PermissionFeatures { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }



    }
}
