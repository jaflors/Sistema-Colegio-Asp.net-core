using ColegioApp.Data;
using ColegioApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColegioApp.Controllers.Administrador
{
    public class PeriodoController : Controller
    {

        private readonly ControlNotasColegioContext _context;

        public PeriodoController(ControlNotasColegioContext context)
        {
            _context = context;
        }


        // GET: PeriodoController
        public IActionResult Index()
        {
            List<Periodo> lista = _context.Periodos.ToList();
            ViewData["periodos"] = lista;
            return View();
        }

        // GET: PeriodoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PeriodoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeriodoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Periodo model)
        {
            try
            {

                var periodo = new Periodo
                {
                    Nombre= model.Nombre,
                    FechaInicio= model.FechaInicio,
                    FechaFin= model.FechaFin,
                    Año= @DateTime.Now.Year.ToString()
                };

                await _context.AddAsync(periodo);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Se registro con exito";
                
            }
            catch
            {
                TempData["error"] = "Algo salio mal";
                return RedirectToAction("Index", "Periodo");
            }
            return RedirectToAction("Index", "Periodo");
        }

        // GET: PeriodoController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _context.Periodos.Find(id);
            return View(result);
        }

        // POST: PeriodoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Periodo modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(modelo);
                    await _context.SaveChangesAsync();
                    TempData["mensaje"] = "se actualizo correctamente";
                    return RedirectToAction("Index", "Periodo");
                }
            }
            catch
            {
                TempData["error"] = "algo salio mal";
                return View("Index");
            }
            return View();
        }

        // GET: PeriodoController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _context.Periodos.Find(id);
            if (result == null)
            {
                ModelState.AddModelError("no se encuentra el periodo", null);
                return RedirectToAction("Index", "Periodo");
            }
            return View(result);
        }

        // POST: PeriodoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Periodo modelo)
        {
            try
            {
                var result = await _context.Periodos.FindAsync(modelo.IdPeriodo);


                if (result == null)
                {
                    TempData["error"] = "no se encontro el registro";
                    return RedirectToAction("Index", "Periodo");

                }
                _context.Remove(result);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "se elimino correctamente";
                return RedirectToAction("Index", "Periodo");


            }
            catch
            {

                TempData["error"] = "¡¡upps!! no se pudo eliminar algo salio mal ";



                List<Periodo> lista = _context.Periodos.ToList();
                ViewData["periodos"] = lista;
                return View();
            }

        }
    }
}
