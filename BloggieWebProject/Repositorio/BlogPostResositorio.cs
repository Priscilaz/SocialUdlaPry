using BloggieWebProject.Data;
using BloggieWebProject.Models.Dominio;

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

        public Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
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
