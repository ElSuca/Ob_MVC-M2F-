using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesObligatorio
{
    public abstract class Publicacion : IComparable<Publicacion>
    {
        public int Id { get; set; }
        public static int S_UltimoId { get; set; }
        public string Titulo { get; set; }
        public Miembro Autor { get; set; }
        public bool EsPrivado { get; set; }
        public DateTime Fecha { get; set; }
        public string Contenido { get; set; }
        public Publicacion() { }
        public List<Reaccion> Reacciones {get; set;}
        public void AddReaccion(Reaccion unaReaccion)
        {
            Reacciones.Add(unaReaccion);
        }

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
        public abstract int CalcularVA(Publicacion publicacion);
        public int devolverLikes(List<Reaccion> lista)
        {
            int cantidad = 0;
            foreach(Reaccion reaccion in lista)
            {
                if(reaccion.TipoReaccion == TipoReaccion.like) cantidad++;
            }
            return cantidad;
        }
        public int devolverDislikes(List<Reaccion> lista)
        {
            int cantidad = 0;
            foreach (Reaccion reaccion in lista)
            {
                if (reaccion.TipoReaccion == TipoReaccion.dislike) cantidad++;
            }
            return cantidad;
        }
        public int CompareTo(Publicacion? other)
        {
            return Titulo.CompareTo(other.Titulo);
        }
    }
}
