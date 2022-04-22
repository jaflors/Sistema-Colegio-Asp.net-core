using ColegioApp.Data;
using ColegioApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColegioApp.Controllers.Administrador
{

    [Authorize(Roles="Administrador")]
    public class GradoController : Controller
    {

        private readonly ControlNotasColegioContext _context;

        public GradoController(ControlNotasColegioContext context)
        {
            _context = context;
        }



        // GET: GradoController
        public ActionResult Index()
        {
            List<Grado> lista = _context.Grados.ToList();
            ViewData["grados"] = lista;
            return View();
        }

        // GET: GradoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GradoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GradoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Grado model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.AddAsync(model);
                    await _context.SaveChangesAsync();
                    TempData["mensaje"] = "el Grado se ah creado correctamente";



                }else
                {
                    TempData["error"] = "Algo salio mal";
                    return RedirectToAction("Index", "Grado");
                }
            }
            catch
            {

                return View();
            }
            return RedirectToAction("Index", "Grado");
        }

        // GET: GradoController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _context.Grados.Find(id);


            return View(result);
        }

        // POST: GradoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>Edit(Grado modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(modelo);
                    await _context.SaveChangesAsync();
                    TempData["mensaje"] = "se actualizo correctamente";
                    return RedirectToAction("Index", "Grado");
                }
            }
            catch
            {
                TempData["mensaje"] = "algo salio mal";
                return View("Index");
            }

            return View();
        }

        // GET: GradoController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _context.Grados.Find(id);
            if (result == null)
            {
                ModelState.AddModelError("no se encuentra el grado", null);
                return RedirectToAction("Index", "Grado");
            }
            return View(result);
        }

        // POST: GradoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Grado modelo)
        {
            try
            {
                var result = await _context.Grados.FindAsync(modelo.IdGrado);


                if (result == null)
                {
                    TempData["error"] = "no se encontro el registro";
                    return RedirectToAction("Index", "Grado");

                }
                _context.Remove(result);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "se elimino correctamente";
                return RedirectToAction("Index", "Grado");


            }
            catch
            {

                TempData["error"] = "¡¡upps!! no se pudo eliminar algo salio mal ";



                List<Grado> lista = _context.Grados.ToList();
                ViewData["grados"] = lista;
                return View("Index");
            }

        }
    }
}
