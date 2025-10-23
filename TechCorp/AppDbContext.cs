using Microsoft.EntityFrameworkCore;
using TechCorp.Models;

namespace TechCorp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientComment> ClientComments { get; set; }
    }
}
