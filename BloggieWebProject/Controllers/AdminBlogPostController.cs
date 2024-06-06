using BloggieWebProject.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BloggieWebProject.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using BloggieWebProject.Models.Dominio;

namespace BloggieWebProject.Controllers
{
    public class AdminBlogPostController : Controller
    {
        private readonly ITagRepositorio tagRepositorio;

        public AdminBlogPostController(ITagRepositorio tagRepositorio)
        {
            this.tagRepositorio = tagRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Agregar()
        {
            // Obtener las etiquetas del repositorio
            var tags = await tagRepositorio.GetAllAsync();

            var model = new AgregarBlogPostRequest
            {
                Tags = tags.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() })
            };

            return View(model); // Devolver el modelo a la vista
        }

        [HttpPost]
        public async Task<IActionResult> Agrsgr(AgregarBlogPostRequest agregarBlogPostRequest)
        {
            // Map view model to domain model
            var blogPost = new BlogPost { 
            
                Encabezado = agregarBlogPostRequest.Encabezado,
                TituloPagina = agregarBlogPostRequest.TituloPagina,
                Contenido = agregarBlogPostRequest.Contenido,
                DescripcionCorta = agregarBlogPostRequest.DescripcionCorta,
                UrlImagenDestacada = agregarBlogPostRequest.UrlImagenDestacada,
                ManejadorUrl = agregarBlogPostRequest.ManejadorUrl,
                FechaPublicacion = agregarBlogPostRequest.FechaPublicacion,
                Autor = agregarBlogPostRequest.Autor,
                Visible = agregarBlogPostRequest.Visible,
            };

            // Map Tags from selected tags
            var tagSeleccionados = new List<Tag>();
            foreach (var tagSeleccionadosId in agregarBlogPostRequest.TagSeleccionado)
            {
                var selectedTagIdAsGuid = Guid.Parse(tagSeleccionadosId);
                var existingTag = await tagRepositorio.GetAsync(selectedTagIdAsGuid);

                if (existingTag != null)
                {
                    tagSeleccionados.Add(existingTag);
                }
            }

            // Mapping tags back to domain model
            blogPost.Tags = selectedTags;


            await blogPostRepositorio.AddAsync(blogPost);

            return RedirectToAction("Add");
        }
    }
}
