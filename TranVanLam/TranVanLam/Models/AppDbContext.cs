using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TranVanLam.Models;
namespace CodeFirst.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
