using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesObligatorio
{
    public class Reaccion
    {
        public TipoReaccion TipoReaccion { get; set; }
        public Miembro Miembro { get; set; }
        public Reaccion(TipoReaccion tipoReaccion, Miembro miembro) 
        {
            TipoReaccion = tipoReaccion;
            Miembro = miembro;  
        }
    }
}
