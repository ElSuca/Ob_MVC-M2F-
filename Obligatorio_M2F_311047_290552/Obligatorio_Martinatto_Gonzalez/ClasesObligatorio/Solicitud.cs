using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesObligatorio
{
    public class Solicitud
    {
        public int Id { get; set; }
        private static int s_ultimoId;
        public Miembro Emisor { get; set; }
        public Miembro Receptor { get; set; } 
        public Invitacion EstadoSolicitud { get; set; }

        public Solicitud(Miembro emisor, Miembro receptor)
        {
            this.Id = s_ultimoId;
            s_ultimoId++;
            this.Emisor = emisor;
            this.Receptor = receptor;
            this.EstadoSolicitud = Invitacion.PENDIENTE_APROBACION;
        }
    }
}
