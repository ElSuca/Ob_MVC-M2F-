using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesObligatorio
{
    public class Post : Publicacion
    {
        public string Imagen {  get; set; }
        public Boolean Censurado {  get; set; }
        private List<Comentario> _comentarios = new List<Comentario>();
        public List<Comentario> GetComentarios() { return _comentarios; }
        public void AddComentario(Comentario unComentario) { _comentarios.Add(unComentario); }
        private static int s_fva_likes = 5;
        private static int s_fva_dislikes = -2;
        private static int s_fva_modificador = 10;
        public Post(string titulo, Usuario autor, string contenido, string imagen, bool esPrivado)
        {
            Id = S_UltimoId;
            S_UltimoId++;
            Titulo = titulo;
            Autor = (Miembro)autor;
            Fecha = DateTime.Now;
            Contenido = contenido;
            Imagen = imagen;
            Censurado = false;
            _comentarios = new List<Comentario>();
            EsPrivado = esPrivado; 
            Reacciones = new List<Reaccion>();
        }
        public Post() { }
        public override int CalcularVA(Publicacion unPost)
        {
            int va = 0;
            int likes = unPost.devolverLikes(unPost.Reacciones);
            int dislikes = unPost.devolverDislikes(unPost.Reacciones);
            va = (likes * s_fva_likes) + (dislikes *  s_fva_dislikes);
            if (!unPost.EsPrivado) va += s_fva_modificador;
            return va;
        }
        public override string ToString()
        {
            return "ID : " + Id + " | Tipo: Post | Titulo: " + Titulo + "| Autor: " + Autor.ToString()
                + "| Fecha: " + Fecha + "| Contenido: " + Contenido;
        }
    }
}
