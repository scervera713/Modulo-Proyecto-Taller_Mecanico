using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Backend.Modelo;

namespace TallerMecanico.Backend.Servicios
{
    public class EmpleadoServicio : ServicioGenerico<empleado>
    {
        private DbContext contexto;
        public empleado empLogin { get; set; }

        public EmpleadoServicio(DbContext context): base(context)
        {
            contexto = context;
        }
        public Boolean login(String user, String pass)
        {
            Boolean correcto = true;
            try
            {
                empLogin = contexto.Set<empleado>().Where(u => u.usuLogin == user).FirstOrDefault();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
            }
            if (empLogin == null)
            {
                correcto = false;
            }
            else if (!empLogin.usuLogin.Equals(user) || !empLogin.contrasenya.Equals(pass))
            {
                correcto = false;
            }

            return correcto;
        }

        public Boolean usuarioUnico(string usu)
        {
            bool unico = true;
            if (contexto.Set<empleado>().Where(u => u.usuLogin == usu).Count() > 0)
            {
                unico = false;
            }
            return unico;
        }
    }
}
