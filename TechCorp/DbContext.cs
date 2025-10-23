using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TechCorp.Models;

namespace EFDemo
{
    public class AppDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientComment> ClientComments { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=SHRIBALAN-LAP;Initial Catalog=CompanyDB;Integrated Security=True;TrustServerCertificate=True"
            );
        }
    }
}
