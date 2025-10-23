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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Blogs)
                .WithOne(b => b.Company)
                .HasForeignKey(b => b.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Posts)
                .WithOne(p => p.Blog)
                .HasForeignKey(p => p.BlogId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Company>()
                .HasMany(b => b.Clients)
                .WithOne(cl => cl.Company)
                .HasForeignKey(cl => cl.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Client>()
                .HasMany(cl => cl.ClientComments)
                .WithOne(cc => cc.Client)
                .HasForeignKey(cc => cc.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Company>().Property(c =>c.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Blog>().Property(b => b.Title).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Blog>().Property(b => b.Url).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Post>().Property(p => p.PostName).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Client>().Property(cl => cl.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<ClientComment>().Property(cc => cc.Comment).IsRequired().HasMaxLength(1000);    

        }
    }
}
