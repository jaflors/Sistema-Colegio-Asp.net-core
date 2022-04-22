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
    public class ProfesorController : Controller
    {
        Profesor profe;
        Periodo periodo;
        private readonly UserManager<UsuarioAplicacion> gestionUsuarios;
        private readonly RoleManager<IdentityRole> gestionRoles;
        private readonly ControlNotasColegioContext _context;

        public ProfesorController(UserManager<UsuarioAplicacion> gestionUsuarios, RoleManager<IdentityRole> gestionRoles, ControlNotasColegioContext context)
        {
            this.gestionUsuarios = gestionUsuarios;
            this.gestionRoles = gestionRoles;
            _context = context;
        }



        // GET: ProfesorController
        public ActionResult Index()
        {
            profe = new();

            DataTable Profesores = profe.ConsultarProfes();

            if (Profesores.Rows.Count > 0)
            {
                ViewData["lisProfes"] = Profesores;


            }
            else
            {
                TempData["NoTeacher"] = "no hay registros";

                RedirectToAction("Index", "Profesor");

            }




            return View();
        }

        // GET: ProfesorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfesorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AspNetUser model)
        {

            try
            {

                // creamos la transaccion
                using var transaction = _context.Database.BeginTransaction();


                var RolName = "Profesor";


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
                var UserTeacher = new Profesor
                {
                    IdUser = usuario.Id,
                    Especialidad=model.Especialidad

                };
                // Add un estudiante
                _context.Add(UserTeacher);
                await _context.SaveChangesAsync();
                transaction.Commit();


                if (resultado.Succeeded && result2.Succeeded)
                {

                    TempData["success"] = "El registro fue un exito";
                    return RedirectToAction("Index");

                }

            }
            catch
            {
                await _context.Database.RollbackTransactionAsync();
                TempData["Error"] = "Algo salio mal no se pudo insertar";
                return RedirectToAction("Index");

            }




            return View("Index");

        }

        // GET: ProfesorController/GetGrados/5
        public async Task<IActionResult> GetGrados(string id )
        {
            profe= new();
            DataRow dato;
            var consulid = profe.ConsultarIdProfe(id);

            if (consulid.Rows.Count>0)
            {
                dato = consulid.Rows[0];
                var ide = dato["IdProfesor"].ToString();
                var IdProfe = Int32.Parse(ide);
                var MateriasProfe = _context.MateriaProfesors
                .Include(e => e.FkProfesorNavigation)
                .Include(e => e.FkMateriaNavigation)
                .ThenInclude(e=> e.FkGradoNavigation)
                
                .Where(m => m.FkProfesor == IdProfe);
                return View(await MateriasProfe.ToListAsync());

            }



            return View();

            

           
        }

        public IActionResult GetStudent(string id)
        {
            profe = new();
            DataRow dato;
            var consulest = profe.ConsultarEstudiantes(id);

           

            if (consulest.Rows.Count > 0)
            {
                dato = consulest.Rows[0];
                ViewData["IdEstudiante"] = Int32.Parse(dato["IdEstudiante"].ToString());
                ViewData["IdMateria"] = Int32.Parse(dato["IdMateria"].ToString());
                
                ViewData["Estudiantes"] = consulest;


            }
            else
            {
                TempData["NoStudent"] = "no hay registros";

                RedirectToAction("GetStudent", new {id });

            }



            return View();

        }

        public async Task<IActionResult>Calificar(Calificacion model)
        {
            var id = model.FkMateria;
            try
            {     
                periodo= new ();
                DataRow dato;
               
                var dataTable =  periodo.ConsultarIdPeriodo();
                if (dataTable.Rows.Count > 0)
                {
                    dato = dataTable.Rows[0];
                    var idperiodo = Int32.Parse(dato["IdPeriodo"].ToString());
                    var nota1 = model.Nota1;
                    var nota2 = model.Nota2;
                    var nota3 = model.Nota3;
                    var definitiva = (nota1 + nota2 + nota3) / 3;
                    var calificacion = new Calificacion()
                    {
                        FkEstudiante = model.FkEstudiante,
                        FkMateria = model.FkMateria,
                        Nota1 = nota1,
                        Nota2 = nota2,
                        Nota3 = nota3,
                        Definitiva = definitiva,
                        FkPeriodo = idperiodo

                    };
                    await _context.AddAsync(calificacion);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    TempData["error"] = "En el momento no se encuentra activo un periodo academico activo";
                    return RedirectToAction("GetStudent", new { id });
                }


            }
            catch
            {
                TempData["error"] = "upps algo salio mal";
                return RedirectToAction("GetStudent", new { id });
            }


            TempData["mensaje"] = "Calificación Exitosa";
            return RedirectToAction("GetStudent", new { id });
        }



       




        // GET: ProfesorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfesorController/Edit/5
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

        // GET: ProfesorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfesorController/Delete/5
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
