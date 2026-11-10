using Microsoft.EntityFrameworkCore;
using UserManagementSystem.Models;

namespace UserManagementSystem.Data
{
    // AppDbContext inherits from DbContext
    // AppDbContext acts as a bridge between the application(C# models) and the database
    // Comes from Entity Framework Core (EF Core) package - Microsoft ORM
    // EF core generates SQL queries based on C# code
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet<User> tells EF Core to create and query a Users table in the database
        public DbSet<User> Users { get; set; }


    }
}