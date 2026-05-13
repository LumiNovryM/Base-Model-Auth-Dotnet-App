using Base_Model_Auth_Dotnet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Base_Model_Auth_Dotnet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}