namespace Blogging.API.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishedAt { get; set; }
        public bool IsDeleted { get; set; }

        // Navigation property to represent the relationship with the User model
        public User Author { get; set; }
        // Navigation property to represent the relationship with the BlogComment model
        public List<BlogComment> Comments { get; set; }
        // Add other properties as needed
    }
}
