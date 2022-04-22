using ColegioApp.Data;
using ColegioApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ColegioApp.Controllers.Administrador
{
    public class MateriasController : Controller
    {
        private readonly ControlNotasColegioContext _context;
        Materium Materias;
        MateriaProfesor MateriaProfesores;
        public MateriasController(ControlNotasColegioContext context)
        {
            _context = context;
        }



        // GET: MateriasController
        public ActionResult Index()
        {
            var model = _context.Grados;

            return View(model);
        }

        // GET: MateriasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MateriasController/Create
        public ActionResult Create(int id)
        {

            Materias = new();



            ViewData["Grado"] = _context.Grados.Find(id);

            DataTable DtMaterias = Materias.ConsultarMaterias(id);

            if (DtMaterias.Rows.Count > 0)
            {
                ViewData["ListMaterias"] = DtMaterias;


            }
            else
            {
                TempData["NoMaterias"] = "no hay registros";

                RedirectToAction("Create", new { id });

            }

            Materias = new();
            DataTable DtProfes = Materias.ConsultarProfesores();
            if (DtProfes.Rows.Count > 0)
            {
                ViewData["Profesores"] = DtProfes;


            }
            else
            {
                TempData["Noprofes"] = "no hay profesores";

                RedirectToAction("Create", new { id });

            }


            return View();
        }

        // POST: MateriasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Materium Model,string IdProfe)
        {

            var idprofe = Int32.Parse(IdProfe);
            var idGrado = Model.FkGrado;

            try
            {
                using var transaction = _context.Database.BeginTransaction();
                Materias = new()
                {
                    Nombre = Model.Nombre,
                    FkGrado = Model.FkGrado
                };
                await _context.AddAsync(Materias);
                await _context.SaveChangesAsync();

                MateriaProfesores = new MateriaProfesor()
                {
                    FkMateria= Materias.IdMateria,
                    FkProfesor= idprofe
                };

                await _context.AddAsync(MateriaProfesores);
                await _context.SaveChangesAsync();


                transaction.Commit();

            }
            catch
            {
                await _context.Database.RollbackTransactionAsync();
                TempData["error"] = "no se pudo Registrar";
                return RedirectToAction("Create", new { id = idGrado });
            }

            TempData["mensaje"] = "Registro Exitoso";
            return RedirectToAction("Create", new { id = idGrado });
        }

        // GET: MateriasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MateriasController/Edit/5
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

        // GET: MateriasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MateriasController/Delete/5
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
