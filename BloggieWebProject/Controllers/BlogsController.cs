using BloggieWebProject.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace BloggieWebProject.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogPostRepositorio blogPostRepositorio;

        public BlogsController(IBlogPostRepositorio blogPostRepositorio)
        {
            this.blogPostRepositorio = blogPostRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var blogPost = await blogPostRepositorio.GetAllAsync();

            return View(blogPost);
        }
    }
}
