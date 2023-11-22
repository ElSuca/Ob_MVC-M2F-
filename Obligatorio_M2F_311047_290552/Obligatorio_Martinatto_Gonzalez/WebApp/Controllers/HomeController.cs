using ClasesObligatorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private Sistema sistema;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            sistema = Sistema.GetInstancia();
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "No tienes acceso" });
            }
            else
            {
                ViewBag.User = Sistema.GetInstancia().GetUsuario((HttpContext.Session.GetString("usuario"))) as Miembro;
                ViewBag.Publicaciones = Sistema.GetInstancia().GetPublicaciones();
                return View();
            }
        }
        public IActionResult Like()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Like(int idPubli)
        {
            Publicacion publicacion = sistema.GetPublicacion(idPubli);
            Miembro miembro = (sistema.GetUsuario(HttpContext.Session.GetString("usuario")) as Miembro);
            Reaccion reaccion = publicacion.GetReaccion(miembro);
            if (reaccion == null)
            {
                publicacion.Reacciones.Add(new Reaccion(TipoReaccion.like, miembro));
            }
            else
            {
                if(reaccion.TipoReaccion == TipoReaccion.like)
                {
                    publicacion.Reacciones.Remove(reaccion);
                }
                else
                {
                    publicacion.Reacciones.Remove(reaccion);
                    publicacion.Reacciones.Add(new Reaccion(TipoReaccion.like, miembro));
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Dislike()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Dislike(int idPubli)
        {
            Publicacion publicacion = sistema.GetPublicacion(idPubli);
            Miembro miembro = (sistema.GetUsuario(HttpContext.Session.GetString("usuario")) as Miembro);
            Reaccion reaccion = publicacion.GetReaccion(miembro);
            if (reaccion == null)
            {
                publicacion.Reacciones.Add(new Reaccion(TipoReaccion.dislike, miembro));
            }
            else
            {
                if (reaccion.TipoReaccion == TipoReaccion.dislike)
                {
                    publicacion.Reacciones.Remove(reaccion);
                }
                else
                {
                    publicacion.Reacciones.Remove(reaccion);
                    publicacion.Reacciones.Add(new Reaccion(TipoReaccion.dislike, miembro));
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Comment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Comment(int idPost, string titulo, string contenido)
        {
            try
            {
                sistema.RealizarComentario(new Comentario(titulo, (sistema.GetUsuario(HttpContext.Session.GetString("usuario")) as Miembro), contenido, false), idPost);
            }
            catch
            {
                throw new Exception();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult EnviarSolicitud()
        {
            return View();
        }

        [HttpPost]

        public IActionResult EnviarSolicitud(string emailReceptor)
        {
            try
            {
                sistema.EnviarSolicitud(emailReceptor);
            }
            catch
            {
                throw new Exception();
            }
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}