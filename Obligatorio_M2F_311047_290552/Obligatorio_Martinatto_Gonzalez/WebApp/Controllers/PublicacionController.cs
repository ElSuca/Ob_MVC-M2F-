using Microsoft.AspNetCore.Mvc;
using ClasesObligatorio;

namespace WebApp.Controllers
{
    public class PublicacionController : Controller
    {
        private Sistema sistema;
        private IWebHostEnvironment _environment;
        public PublicacionController(IWebHostEnvironment environment)
        {
            sistema = Sistema.GetInstancia();
            this._environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Postear()
        {
            ViewBag.Autor = HttpContext.Session.GetString("usuario");
            ViewBag.User = sistema.GetUsuario(HttpContext.Session.GetString("usuario")) as Miembro;
            return View(new Post());
        }
        [HttpPost]
        public IActionResult Postear(Post post, IFormFile foto)
        {
            try
            {
                if (GuardarImagen(foto, post))
                {
                    sistema.RealizarPost(post);
                    string mensaje = "Post Realizado con Exito!";
                    return RedirectToAction("Index", "Home", new { mensaje });
                }
                ViewBag.Mensaje = "Error al cargar la imagen.";
                return View(new Post());
            } 
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Post());
            }
        }
        private bool GuardarImagen(IFormFile imagen, Post post)
        {
            if (imagen == null || post == null) return false;
            // SUBIR LA IMAGEN
            //ruta física de wwwroot
            string rutaFisicaWwwRoot = _environment.WebRootPath;

            string nombreImagen = imagen.FileName;
            //ruta donde se guardan las fotos de las personas
            string rutaFisicaFoto = Path.Combine
            (rutaFisicaWwwRoot, "img", nombreImagen);
            //FileStream permite manejar archivos
            try
            {
                //el método using libera los recursos del objeto FileStream al finalizar
                using (FileStream f = new FileStream(rutaFisicaFoto, FileMode.Create))
                {
                    //Para archivos grandes o varios archivos usar la versión
                    //asincrónica de CopyTo. Sería: await imagen.CopyToAsync (f);
                    imagen.CopyTo(f);
                }
                //GUARDAR EL NOMBRE DE LA IMAGEN SUBIDA EN EL OBJETO
                post.Imagen = nombreImagen;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
