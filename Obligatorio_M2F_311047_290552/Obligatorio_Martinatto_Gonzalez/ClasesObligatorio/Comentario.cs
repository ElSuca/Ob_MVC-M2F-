using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesObligatorio
{
    public class Comentario : Publicacion
    {
        public Comentario(string titulo, DateTime fecha, Usuario autor, string contenido, Boolean privacidad)
        {
            Id = S_UltimoId;
            S_UltimoId++;
            Titulo = titulo;
            Autor = (Miembro)autor;
            Fecha = fecha;
            Contenido = contenido;
            Privacidad = privacidad;
        }
        public Comentario() { }
        public override string ToString()
        {
            return "Tipo: Comentario | Titulo: " + Titulo + "| Autor: " + Autor.ToString()
                + "| Fecha: " + Fecha + "| Contenido: " + Contenido;
        }
    }
}
