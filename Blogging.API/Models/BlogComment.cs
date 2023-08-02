namespace Blogging.API.Models
{
    public class BlogComment
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Body { get; set; }
        public DateTime PostedAt { get; set; }

        // Navigation properties to represent the relationships with the Blog and User models
        public Blog Blog { get; set; }
        public User Author { get; set; }
        // Add other properties as needed
    }
}
