namespace TechCorp.Models
{
    public class ClientComment
    {
        public int ClientCommentId { get; set; }
        public string Comment { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
