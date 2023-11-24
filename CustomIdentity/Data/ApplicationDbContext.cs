using CustomIdentity.Models;
using CustomIdentity.Models.Category;
using CustomIdentity.Models.PermissionModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Security.Claims;

namespace CustomIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            var hasher = new PasswordHasher<ApplicationUser>();

            var Roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "056ca257-19fc-4499-88b5-903cda6bd9d7",
                    Name = CustomIdentity.Utilities.Helper.User,
                    NormalizedName = (CustomIdentity.Utilities.Helper.User).ToUpper(),
                },
                new IdentityRole
                {
                    Id = "8974f75b-9037-4f8e-8aaf-4d66fbca5a01",
                    Name = CustomIdentity.Utilities.Helper.Admin,
                    NormalizedName = (CustomIdentity.Utilities.Helper.Admin).ToUpper(),
                },
                new IdentityRole
                {
                    Id = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa",
                    Name = CustomIdentity.Utilities.Helper.SuperAdmin,
                    NormalizedName = (CustomIdentity.Utilities.Helper.SuperAdmin).ToUpper()
                }

            };
            modelbuilder.Entity<IdentityRole>().HasData(Roles);

            var Users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "d66f3123-77d1-4109-b4ec-f11a10dafeae",
                    Name = "Basic User",
                    UserName = "basicuser@gmail.com",
                    //NormalizedUserName = "basicuser@gmail.com",
                    Email = "basicuser@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Peshawar1@")
                },
                new ApplicationUser
                {
                    Id = "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b",
                     Name = "Super Admin",
                    UserName = "superadmin@gmail.com",
                    //NormalizedUserName = "superadmin@gmail.com",
                    Email = "superadmin@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Peshawar1@")
                }
            };
            modelbuilder.Entity<ApplicationUser>().HasData(Users);

            var AsignUsersRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa",
                    UserId = "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "8974f75b-9037-4f8e-8aaf-4d66fbca5a01",
                    UserId = "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b"
                }
            };

            modelbuilder.Entity<IdentityUserRole<string>>().HasData(AsignUsersRoles);

            SeedPermissions(modelbuilder);
        }

        private static void SeedPermissions(ModelBuilder modelBuilder)
        {
            var SuperAdminId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa";
            List<string> allPermissions = new List<string>();
            List<string> Modules = new List<string>()
            {
                "Account","Product","Category","SubCategory"
            };
            foreach (var module in Modules)
            {
                var fulllist = Permissions.GeneratePermissionsForModule(module).ToList();
                foreach(var list in fulllist)
                {
                    allPermissions.Add(list);
                }
            }

            var roleClaims = new List<IdentityRoleClaim<string>>();
            int i = 1;
            foreach (var permission in allPermissions)
            {
                roleClaims.Add(new IdentityRoleClaim<string> { Id = i, RoleId = SuperAdminId, ClaimType = CustomClaimTypes.Permission, ClaimValue = permission });
                i++;
            }
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
        }
    }
}
