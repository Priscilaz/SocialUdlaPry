using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BloggieWebProject.Data
{
    public class AuthDbContext: IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Rol Usuario
            var adminRolId = "ff9f1e91-e5cb-4621-8b33-a1804fa841cc";
            var usuarioRolId = "c4389286-2126-4d01-991c-a50051195bbb";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRolId,
                    ConcurrencyStamp = adminRolId
                },
                new IdentityRole
                {
                    Name = "Usuario",
                    NormalizedName = "Usuario",
                    Id = usuarioRolId,
                    ConcurrencyStamp = usuarioRolId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            var adminId = "8a27a12e-5c03-46bc-89c7-280de99262ed";
            var adminUser = new IdentityUser
            {
                UserName = "admin@udla.com",
                Email = "admin@udla.com",
                NormalizedUserName = "admin@udla.com",
                Id = adminId
            };
            adminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(adminUser, "Admin123");

            builder.Entity<IdentityUser>().HasData(adminUser);

            //Dando roles al Admin como User
            var adminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = usuarioRolId,
                    UserId = adminUser.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = adminRolId,
                    UserId = adminUser.Id,
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}
