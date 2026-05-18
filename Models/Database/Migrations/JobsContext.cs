using Microsoft.EntityFrameworkCore;

namespace JobsApp.Models.Database.Migrations
{
    public class JobsContext : DbContext
    {
        public JobsContext(DbContextOptions<JobsContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserServices> UserServices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, name = "Admin" },
                new Role { Id = 2, name = "User" },
                new Role { Id = 3, name = "Client" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, name = "Jorge G", email = "jorgeG@test.com", isActive = true, jobTitle = "Admin", password = BCrypt.Net.BCrypt.HashPassword("Test123"), roleId = 1, phoneNumber = "3224785546" }
                );
        }
    }
}
