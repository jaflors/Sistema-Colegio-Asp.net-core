﻿
using ColegioApp.Data;
using ColegioApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColegioApp.Controllers
{
    public class AdministradorController : Controller
    {


        //private readonly ControlNotasColegioContext _context;
        //private readonly RoleManager<IdentityRole> gestionRoles;
        //private readonly UserManager<UsuarioAplicacion> gestionUsuarios;
        // GET: AdministradorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdministradorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdministradorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministradorController/Create
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

        // GET: AdministradorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdministradorController/Edit/5
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

        // GET: AdministradorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdministradorController/Delete/5
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
