using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechCorp.Data;   // AppDbContext
using TechCorp.Models; // Company, Client, Blog, ClientComment, Post

namespace TechCorp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Configure DbContext options
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(@"Data Source=SHRIBALAN-LAP;Initial Catalog=TechCorpDB;Integrated Security=True;TrustServerCertificate=True")
                .Options;

            using var context = new AppDbContext(options);

            // Ensure database is created (for dev/testing)
            context.Database.EnsureCreated();

            // Seed sample data if not already present
            if (!context.Companies.Any())
            {
                var company = new Company
                {
                    Name = "TechCorp",
                    Blogs = new()
                    {
                        new Blog
                        {
                            Title = "Tech Daily",
                            Url = "http://techdaily.com",
                            Posts = new()
                            {
                                new Post { PostName = "First Post" },
                                new Post { PostName = "Second Post" }
                            }
                        },
                        new Blog
                        {
                            Title = "Innovation Buzz",
                            Url = "http://innovationbuzz.com"
                        }
                    },
                    Clients = new()
                    {
                        new Client
                        {
                            Name = "Client A",
                            ClientComments = new()
                            {
                                new ClientComment { Comment = "Great service!" },
                                new ClientComment { Comment = "Prompt response." }
                            }
                        },
                        new Client
                        {
                            Name = "Client B"
                        }
                    }
                };

                context.Companies.Add(company);
                context.SaveChanges();
                Console.WriteLine("✅ Sample data added!\n");
            }

            // Display all data
            var companies = context.Companies
                                   .Include(c => c.Blogs)
                                   .ThenInclude(b => b.Posts)
                                   .Include(c => c.Clients)
                                   .ThenInclude(cl => cl.ClientComments)
                                   .ToList();

            foreach (var co in companies)
            {
                Console.WriteLine($"Company: {co.Name}");

                foreach (var blog in co.Blogs)
                {
                    Console.WriteLine($"\tBlog: {blog.Title} ({blog.Url})");

                    if (blog.Posts.Any())
                    {
                        foreach (var post in blog.Posts)
                        {
                            Console.WriteLine($"\t\tPost: {post.PostName}");
                        }
                    }
                }

                foreach (var client in co.Clients)
                {
                    Console.WriteLine($"\tClient: {client.Name}");

                    if (client.ClientComments.Any())
                    {
                        foreach (var comment in client.ClientComments)
                        {
                            Console.WriteLine($"\t\tComment: {comment.Comment}");
                        }
                    }
                }

                Console.WriteLine(); // blank line between companies
            }
        }
    }
}
