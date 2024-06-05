using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Oyago.Domain.Entities;

namespace Oyago.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser,
        ApplicationRole, string, ApplicationUserClaim, ApplicationUserRole,
        ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {

        public AppDbContext()
        {
        }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<RouteShare> RouteShare { get; set; }
        public DbSet<MatchingRoute> MatchingRoute { get; set; }
        public DbSet<RouteChoice> RouteChoice { get; set; }
        public DbSet<Performance> Performance { get; set; }
        public DbSet<AssignRoute> AssignRoute { get; set; }
             
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserRole>(entity =>
            {

                entity.ToTable("UserRoles");

            });
            modelBuilder.Entity<ApplicationUserClaim>(entity =>
            {

                entity.ToTable("UserClaims");

            });
            modelBuilder.Entity<ApplicationRoleClaim>(entity =>
            {

                entity.ToTable("RoleClaims");

            });
            modelBuilder.Entity<ApplicationUserLogin>(entity =>
            {

                entity.ToTable("UserLogins");

            });
            modelBuilder.Entity<ApplicationUserToken>(entity =>
            {

                entity.ToTable("UserTokens");

            });
        }
    }
}
