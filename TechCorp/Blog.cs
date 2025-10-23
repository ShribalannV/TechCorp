using System.Collections.Generic;

namespace TechCorp.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public List<Post> Posts { get; set; } = new();
    }
}
