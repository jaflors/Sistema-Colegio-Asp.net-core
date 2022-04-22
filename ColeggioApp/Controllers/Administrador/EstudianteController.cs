using ColegioApp.Data;
using ColegioApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ColegioApp.Controllers.Administrador
{
    public class EstudianteController : Controller
    {
        Estudiante Student;
        private readonly ControlNotasColegioContext _context;

        public EstudianteController(ControlNotasColegioContext context)
        {
            _context = context;
        }


        // GET: EstudianteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EstudianteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EstudianteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstudianteController/Create
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

        // GET: EstudianteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstudianteController/Edit/5
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

        // GET: EstudianteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EstudianteController/Delete/5
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
        // GET: ProfesorController/GetMaterias/5
        public IActionResult GetMaterias(string id)
        {
            Student = new();
            DataRow dato;
            var consulid = Student.ConsultarIdEstudiante(id);

            if (consulid.Rows.Count > 0)
            {
                dato = consulid.Rows[0];
                var ide = dato["IdEstudiante"].ToString();
                var Idestude = Int32.Parse(ide);
                var MateriasStuden = Student.ConsultarMaterias(Idestude);

                if (MateriasStuden.Rows.Count > 0)
                {
                    ViewData["MisMaterias"] = MateriasStuden;

                }

                else
                {
                    TempData["NoMateria"] = "no hay registros";

                    RedirectToAction("GetMaterias", "Estudiante");

                }

            }

            return View();
        }

        // GET: ProfesorController/GetNotas/5
        public async Task<IActionResult> GetNotas(int id)
        {
            

            var Notas = await _context.Calificacions
                .Include(e => e.FkMateriaNavigation)
                .Include(e => e.FkPeriodoNavigation)
                .FirstOrDefaultAsync(m => m.FkEstudiante == id);
            if (Notas == null)
            {
                return NotFound();
            }

            return View(Notas);



            
        }



    }
}
