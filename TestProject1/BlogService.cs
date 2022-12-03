using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace TestProject1
{
    public class BlogService
    {
        private BloggingContext _context;

        public BlogService(BloggingContext context)
        {
            _context = context; 
        }

        public EntityEntry<Blog> AddBlog(string name, string url)
        {
            var blog = _context.Blogs.Add(new Blog { Name=name, Url=url});
            _context.SaveChanges();

            return blog;    
        }

        public List<Blog> GetAllBlogs()
        {
            var query = _context.Blogs.OrderBy(x=>x.Name).ToList();

            return query;
        }

        public EntityEntry<Post> AddPost(string title, string content, int blogId)
        {
            var post = _context.Posts.Add(new Post { Title = title, Content = content, BlogId = blogId });
            _context.SaveChanges();

            return post;
        }

        public List<Post> GetAllPostByBlogId(int blogId)
        {
            var query = _context.Posts.Where(x=>x.BlogId == blogId).ToList();

            return query;
        }
    }
}
