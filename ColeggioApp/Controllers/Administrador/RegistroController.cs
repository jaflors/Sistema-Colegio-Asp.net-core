using ColegioApp.Data;
using ColegioApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColegioApp.Controllers.Administrador
{
    public class RegistroController : Controller
    {
        private readonly UserManager<UsuarioAplicacion> gestionUsuarios;
        private readonly RoleManager<IdentityRole> gestionRoles;
        private readonly ControlNotasColegioContext _context;
        //AspNetUser usu = new AspNetUser();

        public RegistroController(UserManager<UsuarioAplicacion> gestionUsuarios, RoleManager<IdentityRole> gestionRoles, ControlNotasColegioContext context)
        {
            this.gestionUsuarios = gestionUsuarios;
            this.gestionRoles = gestionRoles;
            _context = context;
        }


        


        // GET: RegistroController
        public ActionResult Index()
        {
            //var user = usu.ConsultarUsuario();

            return View();
        }

        // GET: RegistroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistroController/Create
        public ActionResult Create()
        {


            List<IdentityRole> ListRoles = gestionRoles.Roles.ToList();
            ViewData["Roles"] = ListRoles;
            return View();
        }

        // POST: RegistroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AspNetUser model, string RolName)
        {


            if (ModelState.IsValid)
            {
                //using var transaction = _context.Database.BeginTransaction();




                var usuario = new UsuarioAplicacion
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Edad = model.Edad,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido
                };

               
                var resultado = await gestionUsuarios.CreateAsync(usuario, model.PasswordHash);
                var result2 = await gestionUsuarios.AddToRoleAsync(usuario, RolName);

                switch (RolName)
                {
                    case "Estudiante":
                        var UsuarioEstudiante = new Estudiante
                        {
                            IdUser = usuario.Id

                        };
                        _context.Add(UsuarioEstudiante);
                        int v = await _context.SaveChangesAsync();
                        break;


                    case "Profesor":
                        var UsuarioProfe = new Profesor
                        {
                            IdUser = usuario.Id

                        };
                        _context.Add(UsuarioProfe);
                        await _context.SaveChangesAsync();
                        break;
                }


                //transaction.Commit();



                //if (resultado. && result2.Succeeded)
                //{
                    return RedirectToAction("Index", "Administrador");

                //}
            }

            return View(/*model*/);
        }

        // GET: RegistroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [AcceptVerbs("Get", "Post")]

        [Route("Registro/ComprobarEmail")]
        public async Task<IActionResult> ComprobarEmail(string email)
        {
            var user = await gestionUsuarios.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"El email {email} no está disponible.");
            }
        }


    }
}
