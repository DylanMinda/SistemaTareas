using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTareas.APIConsumer;
using SistemaTareas.API.Models;

namespace SistemaTareas.MVC.Controllers
{
    public class ProyectosController : Controller
    {
        // GET: ProyectosController
        public ActionResult Index()
        {
            CRUD<Proyecto>.GetAll();
            var proyectos = CRUD<Proyecto>.GetAll();
            return View(proyectos);
        }

        // GET: ProyectosController/Details/5
        public ActionResult Details(int id)
        {
            var proyectos = CRUD<Proyecto>.GetById(id);
            return View(proyectos);
        }

        // GET: ProyectosController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ProyectosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Proyecto proyecto)
        {
            try
            {
                var nuevoProyetco = CRUD<Proyecto>.Create(proyecto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProyectosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProyectosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Proyecto proyecto)
        {
            try
            {
                var nuevoProyetco = CRUD<Proyecto>.Update(id,proyecto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProyectosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProyectosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Proyecto proyeco)
        {
            try
            {
                var proyecto = CRUD<Proyecto>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
