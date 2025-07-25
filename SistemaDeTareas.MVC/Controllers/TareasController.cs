using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTareas.API.Models;
using SistemaTareas.APIConsumer;
using System.Numerics;

namespace SistemaTareas.MVC.Controllers
{
    public class TareasController : Controller
    {
        // GET: TareasController
        public ActionResult Index(string? estado, string? ordenarPor)
        {
            var tareas = CRUD<Tarea>.GetAll();

            if (!string.IsNullOrEmpty(estado))
                tareas = tareas.Where(t => t.Estado == estado).ToList();

            if (ordenarPor == "Estado")
            {
                tareas = tareas.OrderBy(t => t.Estado).ToList();
            }
                
            ViewData["Estado"] = estado;
            return View(tareas);
        }

        // GET: TareasController/Details/5
        public ActionResult Details(int id)
        {
            var tareas = CRUD<Tarea>.GetById(id);
            return View(tareas);
        }

        // GET: TareasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TareasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tarea tarea)
        {
            try
            {
                var nuevaTarea = CRUD<Tarea>.Create(tarea);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TareasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TareasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tarea tarea)
        {
            try
            {
                var nuevaTarea = CRUD<Tarea>.Update(id, tarea);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TareasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TareasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var nuevaTarea = CRUD<Tarea>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
