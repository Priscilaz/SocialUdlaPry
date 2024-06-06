using Microsoft.AspNetCore.Mvc;

namespace BloggieWebProject.Controllers
{
    public class AdminBlogPostController : Controller
    {
        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }
    }
}
