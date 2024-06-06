using BloggieWebProject.Data;
using BloggieWebProject.Models.Dominio;

namespace BloggieWebProject.Repositorio
{
    public class TagRepositorio : ITagRepositorio

    {

        private readonly BlogDbContext _blogDbContext;        
        public TagRepositorio(BlogDbContext blogDbContext)
        {
            BlogDbContext = blogDbContext;
        }

        public BlogDbContext BlogDbContext { get; }

        public async Task<Tag> AddAsync(Tag tag)
        {
            await _blogDbContext.Tags.AddAsync(tag);
            await _blogDbContext.SaveChangesAsync();
            return tag;
        }

        public Task<Tag?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tag>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Tag?> UpdateAsync(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
