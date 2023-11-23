using ClasesObligatorio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SolicitudesController : Controller
    {
        private Sistema sistema;
        public SolicitudesController() 
        {
            sistema = Sistema.GetInstancia();
        }

        public IActionResult Index(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            ViewBag.User = Sistema.GetInstancia().GetUsuario((HttpContext.Session.GetString("usuario"))) as Miembro;
            return View();
        }

        public IActionResult AceptarSolicitud() { return View(); }
        [HttpPost]
        public IActionResult AceptarSolicitud(int idSolicitud)
        {
            string mensaje = "";
            try
            {
                sistema.AceptarSolicitud(idSolicitud);
                mensaje = "Solicitud aceptada!";
            }
            catch (Exception ex)
            {
                mensaje = "Hubo un problema, intente nuevamente." + ex;
            }
            return RedirectToAction("Index", "Solicitudes", new { mensaje });
        }

        public IActionResult RechazarSolicitud() { return View(); }
        [HttpPost]
        public IActionResult RechazarSolicitud(int idSolicitud)
        {
            string mensaje = "";
            try
            {
                sistema.RechazarSolicitud(idSolicitud);
                mensaje = "Solicitud rechazada correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = "Hubo un problema, intente nuevamente." + ex;
            }
            return RedirectToAction("Index", "Solicitudes", new { mensaje });
        }
    }
}
