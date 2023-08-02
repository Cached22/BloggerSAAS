using Blogging.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogging.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlogsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("createBlogs")]
        public async Task<ActionResult<Blog>> CreateBlogPost(Blog blog)
        {
            // Set the published date to now if it's not provided
            if (blog.PublishedAt == default)
            {
                blog.PublishedAt = DateTime.Now;
            }

            // Add the blog post to the database
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            // Return the created blog post with a 201 Created status code
            return CreatedAtAction(nameof(GetBlogPost), new { id = blog.Id }, blog);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlogPost(int id)
        {
            var blogPost = await _context.Blogs.FindAsync(id);

            if (blogPost == null)
            {
                return NotFound();
            }

            return blogPost;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> SearchBlogs(
    string searchQuery = null,
    int? authorId = null,
    bool? isDeleted = null,
    DateTime? fromDate = null,
    DateTime? toDate = null)
        {
            var query = _context.Blogs.AsQueryable();

            // Filter by search query
            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(b => b.Title.Contains(searchQuery) || b.Body.Contains(searchQuery));
            }

            // Filter by author ID
            if (authorId.HasValue)
            {
                query = query.Where(b => b.AuthorId == authorId.Value);
            }

            // Filter by deleted status
            if (isDeleted.HasValue)
            {
                query = query.Where(b => b.IsDeleted == isDeleted.Value);
            }

            // Filter by published date range
            if (fromDate.HasValue)
            {
                query = query.Where(b => b.PublishedAt >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                query = query.Where(b => b.PublishedAt <= toDate.Value);
            }

            // Execute the query and return the results
            var blogs = await query.ToListAsync();
            return blogs;
        }
    }
}
