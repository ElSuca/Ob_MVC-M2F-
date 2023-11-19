using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesObligatorio
{
    public class Comentario : Publicacion
    {
        private static int s_fva_likes = 5;
        private static int s_fva_dislikes = -2;
        public Comentario(string titulo, Usuario autor, string contenido, bool esPrivado)
        {
            Id = S_UltimoId;
            S_UltimoId++;
            Titulo = titulo;
            Autor = (Miembro)autor;
            Fecha = DateTime.Now;
            Contenido = contenido;
            EsPrivado = esPrivado;
            Reacciones = new List<Reaccion>();
        }
        public Comentario() { }
        public override int CalcularVA(Publicacion unPost)
        {
            int va = 0;
            int likes = unPost.devolverLikes(unPost.Reacciones);
            int dislikes = unPost.devolverDislikes(unPost.Reacciones);
            va = (likes * s_fva_likes) + (dislikes * s_fva_dislikes);
            return va;
        }
        public override string ToString()
        {
            return "Tipo: Comentario | Titulo: " + Titulo + "| Autor: " + Autor.ToString()
                + "| Fecha: " + Fecha + "| Contenido: " + Contenido;
        }
    }
}
