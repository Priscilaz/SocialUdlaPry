using BloggieWebProject.Data;
using BloggieWebProject.Models.Dominio;
using Microsoft.EntityFrameworkCore;

namespace BloggieWebProject.Repositorio
{
    public class BlogPostResositorio : IBlogPostRepositorio
         
    {
        private readonly BlogDbContext blogDbContext;
        public BlogPostResositorio(BlogDbContext blogDbContext)
        {
     
            this.blogDbContext = blogDbContext;
        }

        public BlogDbContext BlogDbContext { get; }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await blogDbContext.AddAsync(blogPost);
            await blogDbContext.SaveChangesAsync();
            return blogPost;
        }

        public Task<BlogPost?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await blogDbContext.BlogPosts.Include(bp => bp.Tags).ToListAsync();

        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
            return await blogDbContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }
    }
}
