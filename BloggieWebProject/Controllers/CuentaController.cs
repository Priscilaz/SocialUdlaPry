using BloggieWebProject.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloggieWebProject.Controllers
{
    public class CuentaController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public CuentaController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarViewModel  registrarViewModel)
        {
            var identityUser = new IdentityUser
            {
                UserName = registrarViewModel.Nombreusuario
            };
            var identityResult = await userManager.CreateAsync(identityUser, registrarViewModel.Contrasenia);

            if (identityResult.Succeeded) 
            {
                //asignar el rol al usuario
                var roleIdentityresult= await userManager.AddToRoleAsync(identityUser, "User");

                if (roleIdentityresult.Succeeded) 
                { 
                    //notificar exito
                    return RedirectToAction("Registrar");
                }
            }

            //notificar error
            return View();
        
        }

    }
}
