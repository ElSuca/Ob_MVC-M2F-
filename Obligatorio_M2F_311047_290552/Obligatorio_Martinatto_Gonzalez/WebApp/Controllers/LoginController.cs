using ClasesObligatorio;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }
            
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (Sistema.GetInstancia().Login(email, password))
            {
                Usuario logueado = Sistema.GetInstancia().GetUsuario(email);
                HttpContext.Session.SetString("usuario", email);
                HttpContext.Session.SetString("rol", logueado.GetType().Name);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", new { mensaje = "Nombre de usuario o contraseña incorrecta." });
        }

        public IActionResult Register(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View(new Miembro());
        }
        [HttpPost]
        public IActionResult Register(Miembro miembro)
        {
            try
            {
                string resultado = Sistema.GetInstancia().RegisterMiembro(miembro);
                return RedirectToAction("Login", new {mensaje = resultado});
            }
            catch
            {
                throw new Exception();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("usuario", "");
            return RedirectToAction("Login");
        }


    }
}
