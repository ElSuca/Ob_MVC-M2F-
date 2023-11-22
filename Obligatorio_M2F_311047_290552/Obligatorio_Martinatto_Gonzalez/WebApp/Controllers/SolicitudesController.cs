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

        public IActionResult Index()
        {
            ViewBag.User = Sistema.GetInstancia().GetUsuario((HttpContext.Session.GetString("usuario"))) as Miembro;
            return View();
        }

        public IActionResult AceptarSolicitud() { return View(); }
        [HttpPost]
        public IActionResult AceptarSolicitud(int idSolicitud)
        {
            try
            {
                sistema.AceptarSolicitud(idSolicitud);
            }
            catch
            {
                throw new Exception();
            }
            return RedirectToAction("Index", "Solicitudes");
        }
    }
}
