using BloggieWebProject.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BloggieWebProject.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
