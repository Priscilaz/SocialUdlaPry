using BloggieWebProject.Data;
using BloggieWebProject.Models.Dominio;
using BloggieWebProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BloggieWebProject.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly BlogDbContext _blogDbContext;

        public AdminTagsController(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(AgregarTagRequest agregarTagRequest)
        {
            if (ModelState.IsValid)
            {
                var tag = new Tag
                {
                    Nombre = agregarTagRequest.Nombre,
                    DisplayNombre = agregarTagRequest.DisplayNombre
                };

                _blogDbContext.Tags.Add(tag);
                _blogDbContext.SaveChanges();

                //return RedirectToAction(nameof(Agregar));
                return RedirectToAction("Listar");
            }

            //return View(agregarTagRequest);
            return View(agregarTagRequest);
        }

        [HttpGet]
        [ActionName("Listar")]
        public IActionResult Listar()
        {
            //Usar DbContext para leer los tags
            var tags = _blogDbContext.Tags.ToList();


            return View(tags);
        }
        [HttpGet]
        public IActionResult Editar(Guid id) { 
            //primer metodoo
            // var tag = _blogDbContext.Tags.Find(id);
           
            //segundo metodo
            var tag= _blogDbContext.Tags.FirstOrDefault(t => t.Id == id);
            
            if(tag != null)
            {
                var editarTagRequest = new EditarTagRequest
                {
                    Id = tag.Id,
                    Nombre = tag.Nombre,
                    DisplayNombre = tag.DisplayNombre
                };
                return View(editarTagRequest);
            }

            return View(null);
        }
    }
}