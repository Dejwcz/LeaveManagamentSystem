using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagamentSystem.Web.Data {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole {
                    Id = "f52dedb1-29de-48d0-8091-798e3c52fef4",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole {
                    Id = "2f198f3f-1b40-4fd8-b869-d89b0d86d6d7",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR",
                },
                new IdentityRole {
                    Id = "edccd9cd-806c-4aa4-82f3-c75b93151891",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                });

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>()
                .HasData(new ApplicationUser {
                    Id = "5baca6bf-8b5b-4451-8be2-a81837b5dd92",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                    FirstName = "Default",
                    LastName = "Admin",
                    DateOfBirth = new DateOnly(1950, 12, 01),
                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> {
                    RoleId = "edccd9cd-806c-4aa4-82f3-c75b93151891",
                    UserId = "5baca6bf-8b5b-4451-8be2-a81837b5dd92",
                });

        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
