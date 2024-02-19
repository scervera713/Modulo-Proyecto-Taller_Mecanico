using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TallerMecanico.Backend.Modelo;
using TallerMecanico.Backend.Servicios;
using TallerMecanico.MVVM.Base;

namespace TallerMecanico.MVVM
{
    public class MVEmpleado : MVBaseCRUD<empleado>
    {
        private mydbEntities tallerEnt;
        private empleado emp;
        private empleado empOriginal;
        private EmpleadoServicio empServ;
        private RolServicio rolServ;
        private empleado empSel;
        private String id;
        private String nomApe;
        private String usu;
        private String contr;
        private String rol;
        private ListCollectionView lista;

        private List<Predicate<empleado>> listaCriterios;
        private Predicate<empleado> criterioNombreYApellido;
        private Predicate<empleado> criterioId;
        private Predicate<empleado> criterioUsuario;
        private Predicate<empleado> criterioContrasenya;
        private Predicate<empleado> criterioRol;
        private Predicate<object> filtroPredicados;
        public MVEmpleado(mydbEntities tallerEnt)
        {
            this.tallerEnt = tallerEnt;
            emp = new empleado();
            inicializar();
        }

        public MVEmpleado(mydbEntities tallerEnt, empleado e)
        {
            this.tallerEnt = tallerEnt;
            empOriginal = e;
            emp = new empleado();
            CopiarEmpleado(empOriginal, emp);
            inicializar();
        }

        public void inicializar()
        {
            empServ = new EmpleadoServicio(tallerEnt);
            rolServ = new RolServicio(tallerEnt);
            servicio = empServ;
            lista = new ListCollectionView(servicio.getAll().ToList());

            listaCriterios = new List<Predicate<empleado>>();
            criterioId = new Predicate<empleado>(e => e.idEmpleado.ToString().Contains(FiltroId));
            criterioNombreYApellido = new Predicate<empleado>(e => !String.IsNullOrEmpty(e.nombre) && !String.IsNullOrEmpty(e.apellidos)
               && nombreCompleto(e).ToUpper().Contains(FiltroNombre.ToUpper()));
            criterioUsuario = new Predicate<empleado>(e => !String.IsNullOrEmpty(e.usuLogin) && e.usuLogin.ToUpper().Contains(FiltroUsuario.ToUpper()));
            criterioContrasenya = new Predicate<empleado>(e => !String.IsNullOrEmpty(e.contrasenya) && e.contrasenya.ToUpper().Contains(FiltroContrasenya.ToUpper()));
            criterioRol = new Predicate<empleado>(e => e.rol != null && e.rol.nombreRol.ToUpper().Contains(FiltroRol.ToUpper()));
            filtroPredicados = new Predicate<object>(filtroCombinadoCriterios);
        }

        public void CopiarEmpleado(empleado fuente, empleado destino)
        {
            if (destino != null)
            {
                destino.nombre = fuente.nombre;
                destino.apellidos = fuente.apellidos;
                destino.usuLogin = fuente.usuLogin;
                destino.contrasenya = fuente.contrasenya;
                destino.Rol_idRol = fuente.Rol_idRol;
                destino.rol = fuente.rol;
                destino.reparacion = fuente.reparacion;
            }
        }

        public ListCollectionView ListaEmpleados
        {
            get { return lista; }
            set { lista = value; NotifyPropertyChanged(nameof(ListaEmpleados)); }
        }

        public ListCollectionView refresca
        {
            get { return new ListCollectionView(servicio.getAll().ToList()); }
        }

        public List<rol> listaRoles
        {
            get { return rolServ.getAll().ToList(); }
        }

        public empleado nuevoEmpleado
        {
            get { return emp; }
            set { emp = value; NotifyPropertyChanged(nameof(nuevoEmpleado)); }
        }

        public empleado EmpleadoSeleccionado
        {
            get { return empSel; }
            set { empSel = value; NotifyPropertyChanged(nameof(EmpleadoSeleccionado)); }
        }

        public bool userValido
        {
            get { return empServ.usuarioUnico(emp.usuLogin); }
        }

        public String FiltroNombre
        {
            get { return nomApe; }
            set { nomApe = value; NotifyPropertyChanged(nameof(FiltroNombre)); }
        }

        public String FiltroId
        {
            get { return id; }
            set { id = value; NotifyPropertyChanged(nameof(FiltroId)); }
        }

        public String FiltroUsuario
        {
            get { return usu; }
            set { usu = value; NotifyPropertyChanged(nameof(FiltroUsuario)); }
        }

        public String FiltroContrasenya
        {
            get { return contr; }
            set { contr = value; NotifyPropertyChanged(nameof(FiltroContrasenya)); }
        }

        public String FiltroRol
        {
            get { return rol; }
            set { rol = value; NotifyPropertyChanged(nameof(FiltroRol)); }
        }

        public String nombreCompleto(empleado empl)
        {
            String cadena = empl.nombre + " " + empl.apellidos;
            return cadena;
        }

        public bool guarda
        {
            get
            {
                return add(nuevoEmpleado);
            }
        }

        public bool edita
        {
            get
            {
                CopiarEmpleado(nuevoEmpleado, empOriginal);
                return update(empOriginal);
            }
        }

        public bool borra
        {
            get { return delete(EmpleadoSeleccionado); }
        }

        public bool GestionarEmpleados(empleado e)
        {
            bool permiso = false;
            if (e != null && e.rol != null)
            {
                foreach (permiso p in e.rol.permiso)
                {
                    if (p.idPermiso == 9) permiso = true;
                }
            }

            return permiso;
        }

        public bool IntroducirClientes(empleado e)
        {
            bool permiso = false;
            if (e != null && e.rol != null)
            {
                foreach (permiso p in e.rol.permiso)
                {
                    if (p.idPermiso == 8) permiso = true;
                }
            }

            return permiso;
        }

        public bool IntroducirCobro(empleado e)
        {
            bool permiso = false;
            if (e != null && e.rol != null)
            {
                foreach (permiso p in e.rol.permiso)
                {
                    if (p.idPermiso == 4) permiso = true;
                }
            }

            return permiso;
        }

        //public bool DevolucionCobro(empleado e)
        //{
        //    bool permiso = false;
        //    if (e != null && e.rol != null)
        //    {
        //        foreach (permiso p in e.rol.permiso)
        //        {
        //            if (p.idPermiso == 5) permiso = true;
        //        }
        //    }

        //    return permiso;
        //}

        public void filtra()
        {
            addCriterios();
            ListaEmpleados.Filter = filtroPredicados;
        }

        public void quitarFiltros()
        {
            FiltroId = "";
            FiltroNombre = "";
            FiltroUsuario = "";
            FiltroContrasenya = "";
            FiltroRol = "";
            ListaEmpleados.Filter = null;
        }

        private void addCriterios()
        {
            listaCriterios.Clear();
            if (!String.IsNullOrEmpty(FiltroId)) listaCriterios.Add(criterioId);
            if (!String.IsNullOrEmpty(FiltroNombre)) listaCriterios.Add(criterioNombreYApellido);
            if (!String.IsNullOrEmpty(FiltroUsuario)) listaCriterios.Add(criterioUsuario);
            if (!String.IsNullOrEmpty(FiltroContrasenya)) listaCriterios.Add(criterioContrasenya);
            if (!String.IsNullOrEmpty(FiltroRol)) listaCriterios.Add(criterioRol);
        }

        private bool filtroCombinadoCriterios(object item)
        {
            bool correcto = true;
            empleado empl = (empleado)item;
            if (listaCriterios.Count() != 0)
            {
                correcto = listaCriterios.TrueForAll(x => x(empl));
            }
            return correcto;
        }
    }
}
