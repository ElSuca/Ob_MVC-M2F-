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
        private List<Comentario> _comentarios;
        public List<Comentario> GetComentarios() { return _comentarios; }
        public void AddComentario(Comentario unComentario) { _comentarios.Add(unComentario); }

        public Post(string titulo, DateTime fecha, Usuario autor, string contenido, Boolean privacidad, string imagen)
        {
            Id = S_UltimoId;
            S_UltimoId++;
            Titulo = titulo;
            Autor = (Miembro)autor;
            Fecha = fecha;
            Contenido = contenido;
            Privacidad = privacidad;
            Imagen = imagen;
            Censurado = false;
            _comentarios = new List<Comentario>();
        }
        public Post() { }
       
        public override string ToString()
        {
            return "ID : " + Id + " | Tipo: Post | Titulo: " + Titulo + "| Autor: " + Autor.ToString()
                + "| Fecha: " + Fecha + "| Contenido: " + Contenido;
        }
    }
}
