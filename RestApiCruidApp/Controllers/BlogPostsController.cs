using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiCruidApp.Data;
using RestApiCruidApp.Data.Repository;
using RestApiCruidApp.Models;

namespace RestApiCruidApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly BlogPostsContext _context;
        private readonly IDataRepository<BlogPost> _repository;

        public BlogPostsController(BlogPostsContext context, IDataRepository<BlogPost> repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: api/BlogPosts
        [HttpGet]
        public IEnumerable<BlogPost> GetBlogPosts()
        {
            return _context.BlogPost.OrderByDescending(p => p.PostId);
        }

        // GET: api/BlogPosts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blogPost = await _context.BlogPost.FindAsync(id);

            if (blogPost == null)
            {
                return NotFound();
            }

            return Ok(blogPost);
        }

        // PUT: api/BlogPosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogPost([FromRoute] int id, [FromBody] BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blogPost.PostId)
            {
                return BadRequest();
            }

            _context.Entry(blogPost).State = EntityState.Modified;

            try
            {
                _repository.Update(blogPost);
                var save = await _repository.SaveAsync(blogPost);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BlogPosts
        [HttpPost]
        public async Task<IActionResult> PostBlogPost([FromBody] BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(blogPost);
            var save = await _repository.SaveAsync(blogPost);

            return CreatedAtAction("GetBlogPost", new { id = blogPost.PostId }, blogPost);
        }

        // DELETE: api/BlogPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blogPost = await _context.BlogPost.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            _repository.Delete(blogPost);
            var save = await _repository.SaveAsync(blogPost);

            return Ok(blogPost);
        }

        private bool BlogPostExists(int id)
        {
            return _context.BlogPost.Any(e => e.PostId == id);
        }
    }
}
