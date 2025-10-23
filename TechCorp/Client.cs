using EFDemo;
using System.Collections.Generic;

namespace TechCorp.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public List<ClientComment> ClientComments { get; set; } = new();
    }
}
