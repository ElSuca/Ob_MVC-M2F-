using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesObligatorio
{
    public abstract class Publicacion
    {
        public int Id { get; set; }
        public static int S_UltimoId { get; set; }
        public string Titulo { get; set; }
        public Miembro Autor { get; set; }
        public bool EsPrivado { get; set; }
        public DateTime Fecha { get; set; }
        public string Contenido { get; set; }
        public List<Reaccion> Reacciones = new List<Reaccion>();
        public Publicacion() { }

        public virtual Boolean ValidarTitulo(string titulo) // Valida que el titulo no sea vacío.
        {
            Boolean result = false;
            if (titulo != null)
            {
                result = true;
            }
            return result;
        }
        public virtual Boolean ValidarContenido(string contenido) // Valida que el contenido no sea vacío.
        {
            Boolean result = false;
            if (contenido != null)
            {
                result = true;
            }
            return result;
        }
        public virtual Reaccion GetReaccion(Miembro miembro)
        {
            Reaccion laReaccion = null;
            if (Reacciones != null)
            {
                foreach (Reaccion reaccion in Reacciones)
                {
                    if (reaccion.Miembro == miembro)
                    {
                        laReaccion = reaccion;
                    }
                }
            }
            return laReaccion;
        }
        public abstract int CalcularVA(Publicacion publicacion);
        public int devolverLikes(List<Reaccion> lista)
        {
            int cantidad = 0;
            if (lista != null)
            {
                foreach (Reaccion reaccion in lista)
                {
                    if (reaccion.TipoReaccion == TipoReaccion.like) cantidad++;
                }
            }
            return cantidad;
        }
        public int devolverDislikes(List<Reaccion> lista)
        {
            int cantidad = 0;
            if (lista != null)
            {
                foreach (Reaccion reaccion in lista)
                {
                    if (reaccion.TipoReaccion == TipoReaccion.dislike) cantidad++;
                }
            }
            return cantidad;
        }
    }
}
