using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggieWebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("GET Images API llamada");
        }

    }
}
