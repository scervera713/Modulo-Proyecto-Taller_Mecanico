using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Backend.Modelo;

namespace TallerMecanico.Backend.Servicios
{
    public class PiezaServicio : ServicioGenerico<pieza>
    {
        private DbContext contexto;

        public PiezaServicio(DbContext context) : base(context)
        {
            contexto = context;
        }
    }
}
