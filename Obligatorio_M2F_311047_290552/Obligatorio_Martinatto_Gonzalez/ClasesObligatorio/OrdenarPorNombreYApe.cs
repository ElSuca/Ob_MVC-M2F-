using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesObligatorio
{
    public class OrdenarPorNombreYApe : IComparer<Miembro>
    {
        public int Compare(Miembro? x, Miembro? y)
        {

            int resultado = x.Apellido.CompareTo(y.Apellido);
            if (resultado == 0)
            {
                return x.Nombre.CompareTo(y.Nombre);
            }
            return resultado;
        }
    }
}
