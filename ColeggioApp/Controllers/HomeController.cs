using ColeggioApp.Models;
using ColegioApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ColeggioApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<UsuarioAplicacion> gestionUsuario;
        private readonly SignInManager<UsuarioAplicacion> gestionLogin;

        public HomeController(ILogger<HomeController> logger, UserManager<UsuarioAplicacion> gestionUsuario, SignInManager<UsuarioAplicacion> gestionLogin)
        {
            _logger = logger;
            this.gestionUsuario = gestionUsuario;
            this.gestionLogin = gestionLogin;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Home/Login")]
        public IActionResult Login()
        {

            return View();

        }
        [HttpPost]
        [Route("Home/Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await gestionUsuario.FindByEmailAsync(model.Email);
                ViewData["userName"] = user.Nombre;

                var resultado = await gestionLogin.PasswordSignInAsync(user.UserName, model.Password,
                    model.Recuerdame, false);


                if(gestionLogin.IsSignedIn(User))
                {
                    var name = User.Identity.Name;
                }



                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Administrador");


                }
                ModelState.AddModelError(string.Empty, "Inicio de sesion no valido");


            }


            return View(model);

        }


        [HttpPost]
        [Route("Home/CerrarSesion")]
        public async Task<IActionResult> CerrarSesion()
        {
            await gestionLogin.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
