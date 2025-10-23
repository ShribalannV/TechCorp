using EFDemo;
using System.Collections.Generic;

namespace TechCorp.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; } = new();
        public List<Client> Clients { get; set; } = new();
    }
}
