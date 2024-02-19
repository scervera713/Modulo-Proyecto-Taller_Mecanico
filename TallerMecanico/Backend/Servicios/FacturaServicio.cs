using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Backend.Modelo;

namespace TallerMecanico.Backend.Servicios
{
    class FacturaServicio : ServicioGenerico<factura>
    {
        private DbContext contexto;

        public FacturaServicio(DbContext context) : base(context)
        {
            contexto = context;
        }
    }
}
