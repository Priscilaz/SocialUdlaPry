using Microsoft.AspNetCore.Mvc;

namespace BloggieWebProject.Controllers
{
    public class AdminTagsController : Controller
    {
        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }
    }
}
