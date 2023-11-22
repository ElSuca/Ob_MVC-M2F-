using ClasesObligatorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace WebApp.Controllers
{
    public class BusquedaController : Controller
    {
        private Sistema sistema;
        public BusquedaController() 
        {
            sistema = Sistema.GetInstancia();
        }

        public IActionResult Buscar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Buscar(int valorAceptacion, string texto)
        {
            if (texto == null) texto = " ";
            List<Publicacion> lista = new List<Publicacion>();
            foreach(Publicacion publicacion in sistema.GetPublicaciones())
            {
                if((publicacion.CalcularVA(publicacion)) >= valorAceptacion && publicacion.Contenido.Contains(texto))
                {
                    lista.Add(publicacion);
                }
            }
            ViewBag.User = Sistema.GetInstancia().GetUsuario((HttpContext.Session.GetString("usuario"))) as Miembro;
            ViewBag.lista = lista;
            return View(lista);

        }
    }
}
