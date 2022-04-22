using ColegioApp.Data;
using ColegioApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ColegioApp.Controllers.Administrador
{
    public class EstudianteGradoController : Controller
    {
        EstudianteGrado EstudianteGrado;
        private readonly UserManager<UsuarioAplicacion> gestionUsuarios;
        private readonly RoleManager<IdentityRole> gestionRoles;
        private readonly ControlNotasColegioContext _context;

        public EstudianteGradoController(UserManager<UsuarioAplicacion> gestionUsuarios, RoleManager<IdentityRole> gestionRoles, ControlNotasColegioContext context)
        {
            this.gestionUsuarios = gestionUsuarios;
            this.gestionRoles = gestionRoles;
            _context = context;
        }


        // GET: EstudianteGradoControllerController
        public ActionResult Index()
        {
            var model = _context.Grados;

            return View(model);
        }


        public ActionResult GetStudent(int id)
        {
            EstudianteGrado = new();

           

            ViewData["Grado"] = _context.Grados.Find(id);

            DataTable estudiantes = EstudianteGrado.ConsultarEstudiantes(id);

            if (estudiantes.Rows.Count > 0)
            {
                ViewData["Estudiantes"] = estudiantes;


            }
            else
            {
                TempData["NoStudent"] = "no hay registros";

                RedirectToAction("GetStudent", "EstudianteGrado");

            }




            return View();
        }


        public ActionResult AgregarEstudiante()
        {

            
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarEstudiante(AspNetUser model)
        {

            try
            {
                var FkGrado = Int32.Parse(model.Id);
                // creamos la transaccion
                using var transaction = _context.Database.BeginTransaction();


                var RolName = "Estudiante";


                var usuario = new UsuarioAplicacion
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Edad = model.Edad,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Identificacion = model.Identificacion

                };

                var resultado = await gestionUsuarios.CreateAsync(usuario, model.Identificacion.ToString());
                var result2 = await gestionUsuarios.AddToRoleAsync(usuario, RolName);

                //creamos un objeto de tipo estudiante 
                var UsuarioEstudiante = new Estudiante
                {
                    IdUser = usuario.Id,

                };
                // Add un estudiante
                _context.Add(UsuarioEstudiante);
                await _context.SaveChangesAsync();


                //creamos objeto de la clase estudiantegrado
                var EstudianteGrados = new EstudianteGrado
                {
                    FkEstudiante = UsuarioEstudiante.IdEstudiante,
                    FkGrado = FkGrado,
                    Año = @DateTime.Now.Year.ToString()
                };

                // Guardamos en la base de datos
                _context.Add(EstudianteGrados);
                await _context.SaveChangesAsync();




                transaction.Commit();


                if (resultado.Succeeded && result2.Succeeded)
                {
                    return RedirectToAction("GetStudent", new { id = FkGrado });

                }

            }
            catch
            {
               await  _context.Database.RollbackTransactionAsync();
            }

           
           

            return View();







        }

        // GET: EstudianteGradoControllerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EstudianteGradoControllerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstudianteGradoControllerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: EstudianteGradoControllerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstudianteGradoControllerController/Edit/5
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

        // GET: EstudianteGradoControllerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EstudianteGradoControllerController/Delete/5
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

      

    }
}
