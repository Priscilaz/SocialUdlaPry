using BloggieWebProject.Data;
using BloggieWebProject.Models.Dominio;
using BloggieWebProject.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BloggieWebProject.Repositorio
{
    public class TagRepositorio : ITagRepositorio

    {

        private readonly BlogDbContext _blogDbContext;        
        public TagRepositorio(BlogDbContext blogDbContext)
        {
            this._blogDbContext = blogDbContext;

            _blogDbContext = blogDbContext;
        }

        public BlogDbContext BlogDbContext { get; }

        public async Task<Tag> AddAsync(Tag tag)
        {
            await _blogDbContext.Tags.AddAsync(tag);
            await _blogDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existeTag = await _blogDbContext.Tags.FindAsync(id);

            if (existeTag != null)
            {
                _blogDbContext.Tags.Remove(existeTag);
                await _blogDbContext.SaveChangesAsync();
                // mostrar notificacion
                return existeTag;

            };
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
           return await _blogDbContext.Tags.ToListAsync();
        }

        public Task<Tag?> GetAsync(Guid id)
        {

           return _blogDbContext.Tags.FirstOrDefaultAsync(x => x.Id==id);


        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existeTag = await _blogDbContext.Tags.FindAsync(tag.Id);
        
            if(existeTag != null)
            {
                existeTag.Nombre = tag.Nombre;
                existeTag.DisplayNombre = tag.DisplayNombre;
                
                await _blogDbContext.SaveChangesAsync();
                return existeTag;
            }
            return null;
        
        }
    }
}
