using BloggieWebProject.Data;
using BloggieWebProject.Models.Dominio;
using BloggieWebProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        public async Task<IActionResult> Agregar(AgregarTagRequest agregarTagRequest)
        {
            if (ModelState.IsValid)
            {
                var tag = new Tag
                {
                    Nombre = agregarTagRequest.Nombre,
                    DisplayNombre = agregarTagRequest.DisplayNombre
                };
                



                //await _blogDbContext.Tags.AddAsync(tag);
                //await _blogDbContext.SaveChangesAsync() ;

                //return RedirectToAction(nameof(Agregar));
                return RedirectToAction("Listar");
            }

            //return View(agregarTagRequest);
            return View(agregarTagRequest);
        }

        [HttpGet]
        [ActionName("Listar")]
        public async Task<IActionResult> Listar()
        {
            //Usar DbContext para leer los tags
            var tags = await _blogDbContext.Tags.ToListAsync();


            return View(tags);
        }


        [HttpGet]
        public async Task<IActionResult> Editar(Guid id)
        //    //primer metodoo
        //    // var tag = _blogDbContext.Tags.Find(id);

        //    //segundo metodo
        {
            var tag = await _blogDbContext.Tags.FirstOrDefaultAsync(t => t.Id == id);

            if (tag != null)
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

        [HttpPost]
        public async Task<IActionResult> Editar(EditarTagRequest editarTagRequest)
        {
            var tag = new Tag
            {
                Id = editarTagRequest.Id,
                Nombre = editarTagRequest.Nombre,
                DisplayNombre = editarTagRequest.DisplayNombre

            };

            var existinTag = await _blogDbContext.Tags.FindAsync(tag.Id);
            if (existinTag != null)
            {
                existinTag.Nombre = tag.Nombre;
                existinTag.DisplayNombre = tag.DisplayNombre;

                await _blogDbContext.SaveChangesAsync();
                //return RedirectToAction("Listar");
                //Mostrar notificación de exito
                return RedirectToAction("Editar", new { id = editarTagRequest.Id });

            }
            //Mostrar notificación de fallo
            return RedirectToAction("Editar", new { id = editarTagRequest.Id });

        }
        public async Task<IActionResult> Eliminar(EditarTagRequest editarTagRequest)
        {
            {
               var tag= await _blogDbContext.Tags.FindAsync(editarTagRequest.Id);

                if (tag != null)
                {
                    _blogDbContext.Tags.Remove(tag);
                   await _blogDbContext.SaveChangesAsync();
                    // mostrar notificacion
                    return RedirectToAction("Listar");

                }
                //mostrar notificacion de error
                return RedirectToAction("Edit",new { id = editarTagRequest.Id });

            };
            //return RedirectToAction(nameof(Index));


        }
    }

}
