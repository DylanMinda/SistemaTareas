using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaTareas.API.Models;
using SistemaTareas.APIConsumer;

namespace SistemaDeTareas.MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {

            if (usuario.email == "xd@gmai.com" && usuario.password == "123")
            {
              
                return RedirectToAction("Central", "Home");
            }
            else if(!(usuario.email == "xd@gmai.com" && usuario.password == "123"))
            {
                ViewBag.ErrorMessage = "Usuario no encotrado";
                return RedirectToAction("Central", "Home");
            }
            else {                 
                ViewBag.ErrorMessage = "Error, usuario o contraseña incorrectos";
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Usuario usuario)
        {
            try
            {
                var nuevoUsuario=CRUD<Usuario>.Create(usuario);
                return RedirectToAction("Index", "Login");
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
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

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
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

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
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
