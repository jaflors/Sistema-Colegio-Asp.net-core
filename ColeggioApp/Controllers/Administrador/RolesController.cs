using ColegioApp.Data;
using ColegioApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColegioApp.Controllers.Administrador
{
    public class RolesController : Controller
    {


        private readonly RoleManager<IdentityRole> gestionRoles;
        private readonly ControlNotasColegioContext _context;

        public RolesController(RoleManager<IdentityRole> gestionRoles, ControlNotasColegioContext context)
        {
            this.gestionRoles = gestionRoles;
            _context = context;
        }





        // GET: RolesController
        public ActionResult Index()
        {
            var roles = gestionRoles.Roles;
            return View(roles);
        }

        // GET: RolesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RolesController/Create

        [HttpGet]
        [Route("Roles/Create")]
        public IActionResult Create()
        {
            return View();

        }

        // POST: RolesController/Create

        [HttpPost]
        [Route("Roles/Create")]
        public async Task<IActionResult> Create(AspNetRole modelo)
        {

            if (ModelState.IsValid)
            {
                IdentityRole identityrole = new()
                {
                    Name = modelo.Name

                };
                IdentityResult result = await gestionRoles.CreateAsync(identityrole);
                if (result.Succeeded)
                {
                    TempData["mensaje"] = "El Rol se ha creado con exito";

                    return RedirectToAction("Index", "Roles");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }




            }


            return View(modelo);

        }


        // GET: RolesController/Edit/5
        public async Task<ActionResult> Edit(string Id)
        {
            if (Id == null)
            {
                return NotFound();

            }
            var ressult = await gestionRoles.FindByIdAsync(Id);
            if (ressult==null)
            {
                ViewBag.ErrorMessage = $"Rol con el Id = {Id} no fue encontrado";
                return View("Error");
            }

            var model = new AspNetRole
            {
                Id = ressult.Id,
                Name = ressult.Name
            };


            return View(model);
        }


        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AspNetRole model)
        {
            if (ModelState.IsValid)
            {
                var rol = await gestionRoles.FindByIdAsync(model.Id);
                if (rol == null)
                {
                    TempData["error"] = "El rol no se encuentra";
                    return RedirectToAction("Index", "Roles");
                }
                rol.Name = model.Name;
                IdentityResult result = await gestionRoles.UpdateAsync(rol);
                if (result.Succeeded)
                {
                    TempData["mensaje"] = "El Rol se ha Editado con exito";

                    return RedirectToAction("Index", "Roles");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }




            }


            return View(model);
        }

        // GET: RolesController/Delete/5
        public async Task<IActionResult> Delete(string  Id)
        {
            if (Id == null)
            {
                return NotFound();

            }
            var ressult = await gestionRoles.FindByIdAsync(Id);
            if (ressult == null)
            {
                TempData["error"] = "El rol no se encuentra";
                return RedirectToAction("Index", "Roles");
                
            }

            var model = new AspNetRole
            {
                Id = ressult.Id,
                Name = ressult.Name
            };


            return View(model);
        }

        // POST: RolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Delete(AspNetRole model)
        {

            var rol = await gestionRoles.FindByIdAsync(model.Id);
            if (rol == null)
            {
                TempData["error"] = "El rol no se encuentra";
                return RedirectToAction("Index", "Roles");
            }



            IdentityResult resultado = await gestionRoles.DeleteAsync(rol);
            if (resultado.Succeeded)
            {
                TempData["mensaje"] = "El Rol se ha borrado con exito";
                return RedirectToAction("Index", "Roles");
            }
            else
            {
                foreach (IdentityError error in resultado.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }


            return View(model);
        }
    }
}
