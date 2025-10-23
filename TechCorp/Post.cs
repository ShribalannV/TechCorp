namespace TechCorp.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostName { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
