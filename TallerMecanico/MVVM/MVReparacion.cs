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
    public class MVReparacion : MVBaseCRUD<reparacion>
    {
        private mydbEntities tallerEnt;
        private reparacion repOriginal;
        private reparacion rep;
        private reparacion repSel;
        private empleado empl;
        private ReparacionServicio repServ;
        private EmpleadoServicio empServ;
        private ClienteServicio cliServ;
        private ListCollectionView lista;
        private List<string> listaEst = new List<string>() { "PENDIENTE", "EN REPARACION", "REPARADO" };
        private String id;
        private String tipo;
        private String estado;
        private String precio;
        private DateTime? fecRec;
        private DateTime? fecRes;
        private String emp;
        private String cli;
        private String descr;

        private List<Predicate<reparacion>> listaCriterios;
        private Predicate<reparacion> criterioId;
        private Predicate<reparacion> criterioTipo;
        private Predicate<reparacion> criterioEstado;
        private Predicate<reparacion> criterioPrecio;
        private Predicate<reparacion> criterioFechaRec;
        private Predicate<reparacion> criterioFechaRes;
        private Predicate<reparacion> criterioEmpleado;
        private Predicate<reparacion> criterioCliente;
        private Predicate<reparacion> criterioDescripcion;
        private Predicate<object> filtroPredicados;

        public MVReparacion(mydbEntities ent)
        {
            tallerEnt = ent;
            rep = new reparacion();
            rep.fechaRecepcion = DateTime.Now;
            rep.resolucion = "Resolución pendiente";
            inicializar();
        }

        public MVReparacion(mydbEntities ent, empleado e)
        {
            tallerEnt = ent;
            empl = e;
            rep = new reparacion();
            rep.fechaRecepcion = DateTime.Now;
            rep.resolucion = "Resolución pendiente";
            inicializar();
        }

        public MVReparacion(mydbEntities ent, reparacion r, empleado e)
        {
            tallerEnt = ent;
            repOriginal = r;
            rep = new reparacion();
            CopiarReparacion(repOriginal, rep);
            empl = e;
            inicializar();
        }

        public void inicializar()
        {
            repServ = new ReparacionServicio(tallerEnt);
            servicio = repServ;
            empServ = new EmpleadoServicio(tallerEnt);
            cliServ = new ClienteServicio(tallerEnt);

            if (empl != null && empl.rol.idRol == 3) lista = new ListCollectionView(servicio.getAll().Where(r => r.empleado.idEmpleado == empl.idEmpleado).ToList());
            else lista = new ListCollectionView(servicio.getAll().ToList());

            listaCriterios = new List<Predicate<reparacion>>();
            criterioId = new Predicate<reparacion>(r => r.idReparacion.ToString().Contains(FiltroId));
            criterioTipo = new Predicate<reparacion>(r => !String.IsNullOrEmpty(r.tipo) && r.tipo.ToUpper().Contains(FiltroTipo.ToUpper()));
            criterioEstado = new Predicate<reparacion>(r => !String.IsNullOrEmpty(r.estado) && r.estado.ToUpper().Contains(FiltroEstado.ToUpper()));
            criterioPrecio = new Predicate<reparacion>(r => r.precio.ToString().Contains(FiltroPrecio));
            criterioFechaRec = new Predicate<reparacion>(r => r.fechaRecepcion != null && r.fechaRecepcion.Date.Equals(FiltroFechaRecepcion.Value.Date));
            criterioFechaRes = new Predicate<reparacion>(r => r.fechaResolucion != null && r.fechaResolucion.Value.Date.Equals(FiltroFechaResolucion.Value.Date));
            criterioEmpleado = new Predicate<reparacion>(r => r.empleado != null && !String.IsNullOrEmpty(r.empleado.nombre) && !String.IsNullOrEmpty(r.empleado.apellidos)
               && nombreCompletoEmpleado(r.empleado).ToUpper().Contains(FiltroEmpleado.ToUpper()));
            criterioCliente = new Predicate<reparacion>(r => r.cliente != null && !String.IsNullOrEmpty(r.cliente.nombre) && !String.IsNullOrEmpty(r.cliente.apellidos)
               && nombreCompletoCliente(r.cliente).ToUpper().Contains(FiltroCliente.ToUpper()));
            criterioDescripcion = new Predicate<reparacion>(r => !String.IsNullOrEmpty(r.descripcion) && r.descripcion.ToUpper().Contains(FiltroDescripcion.ToUpper()));
            filtroPredicados = new Predicate<object>(filtroCombinadoCriterios);
        }

        public void CopiarReparacion(reparacion fuente, reparacion destino)
        {
            if (destino != null)
            {
                destino.descripcion = fuente.descripcion;
                destino.precio = fuente.precio;
                destino.tipo = fuente.tipo;
                destino.estado = fuente.estado;
                destino.resolucion = fuente.resolucion;
                destino.fechaRecepcion = fuente.fechaRecepcion;
                destino.fechaResolucion = fuente.fechaResolucion;
                destino.observaciones = fuente.observaciones;
                destino.Cliente_idCliente = fuente.Cliente_idCliente;
                destino.Empleado_idEmpleado = fuente.Empleado_idEmpleado;
                destino.horasTrabajadas = fuente.horasTrabajadas;
                destino.cliente = fuente.cliente;
                destino.empleado = fuente.empleado;
                destino.factura = fuente.factura;
                destino.pieza = fuente.pieza;
            }
        }
        public ListCollectionView ListaReparaciones
        {
            get { return lista; }
            set { lista = value; NotifyPropertyChanged(nameof(ListaReparaciones)); }
        }

        public ListCollectionView refresca
        {
            get { return new ListCollectionView(servicio.getAll().ToList()); }
        }

        public List<empleado> ListaEmpleados
        {
            get 
            { 
                if (empl != null && empl.rol != null && empl.rol.idRol == 3)
                {
                    return empServ.getAll().Where(e => e.idEmpleado == empl.idEmpleado).ToList();
                }
                else
                {
                    return empServ.getAll().Where(e => e.Rol_idRol == 3).ToList();
                }
            }
        }

        public List<cliente> ListaClientes
        {
            get { return cliServ.getAll().ToList(); }
        }

        public List<String> ListaEstados
        {
            get { return listaEst; }
        }

        public double precioTotal
        {
            get
            {
                double pt = 0;
                foreach (pieza p in nuevaReparacion.pieza)
                {
                    pt += p.precio;
                }

                if (nuevaReparacion.horasTrabajadas != null)
                {
                    double horas = (double)nuevaReparacion.horasTrabajadas * 30;
                    pt += horas;
                    return pt;
                }
                else
                {
                    return pt;
                }
            }
        }

        public bool EliminarReparaciones
        {
            get
            {
                bool permiso = false;
                if (empl != null && empl.rol != null)
                {
                    foreach (permiso p in empl.rol.permiso)
                    {
                        if (p.idPermiso == 3) permiso = true;
                    }
                }

                return permiso;
            }
        }

        public bool IntroducirCobro
        {
            get
            {
                bool permiso = false;
                if (empl != null && empl.rol != null)
                {
                    foreach (permiso p in empl.rol.permiso)
                    {
                        if (p.idPermiso == 4) permiso = true;
                    }
                }

                return permiso;
            }
        }

        public bool DevolucionCobro
        {
            get
            {
                bool permiso = false;
                if (empl != null && empl.rol != null)
                {
                    foreach (permiso p in empl.rol.permiso)
                    {
                        if (p.idPermiso == 5) permiso = true;
                    }
                }

                return permiso;
            }
        }

        public reparacion nuevaReparacion
        {
            get { return rep; }
            set { rep = value; NotifyPropertyChanged(nameof(nuevaReparacion)); }
        }

        public reparacion ReparacionSeleccionada
        {
            get { return repSel; }
            set { repSel = value; NotifyPropertyChanged(nameof(ReparacionSeleccionada)); }
        }

        public bool guarda
        {
            get { return add(nuevaReparacion); }
        }

        public String nombreCompletoEmpleado(empleado empl)
        {
            String cadena = empl.nombre + " " + empl.apellidos;
            return cadena;
        }

        public String nombreCompletoCliente(cliente cli)
        {
            String cadena = cli.nombre + " " + cli.apellidos;
            return cadena;
        }

        public bool edita
        {
            get
            {
                CopiarReparacion(nuevaReparacion, repOriginal);
                return update(repOriginal);
            }
        }

        public bool borra
        {
            get { return delete(repSel); }
        }
        public String FiltroId
        {
            get { return id; }
            set { id = value; NotifyPropertyChanged(nameof(FiltroId)); }
        }

        public String FiltroTipo
        {
            get { return tipo; }
            set { tipo = value; NotifyPropertyChanged(nameof(FiltroTipo)); }
        }

        public String FiltroEstado
        {
            get { return estado; }
            set { estado = value; NotifyPropertyChanged(nameof(FiltroEstado)); }
        }

        public String FiltroPrecio
        {
            get { return precio; }
            set { precio = value; NotifyPropertyChanged(nameof(FiltroPrecio)); }
        }

        public DateTime? FiltroFechaRecepcion
        {
            get { return fecRec; }
            set { fecRec = value; NotifyPropertyChanged(nameof(FiltroFechaRecepcion)); }
        }

        public DateTime? FiltroFechaResolucion
        {
            get { return fecRes; }
            set { fecRes = value; NotifyPropertyChanged(nameof(FiltroFechaResolucion)); }
        }
        public String FiltroEmpleado
        {
            get { return emp; }
            set { emp = value; NotifyPropertyChanged(nameof(FiltroEmpleado)); }
        }

        public String FiltroCliente
        {
            get { return cli; }
            set { cli = value; NotifyPropertyChanged(nameof(FiltroCliente)); }
        }

        public String FiltroDescripcion
        {
            get { return descr; }
            set { descr = value; NotifyPropertyChanged(nameof(FiltroDescripcion)); }
        }

        public void filtra()
        {
            addCriterios();
            ListaReparaciones.Filter = filtroPredicados;
        }

        public void quitarFiltros()
        {
            FiltroId = "";
            FiltroTipo = "";
            FiltroEstado = "";
            FiltroPrecio = "";
            FiltroFechaRecepcion = null;
            FiltroFechaResolucion = null;
            FiltroEmpleado = "";
            FiltroCliente = "";
            FiltroDescripcion = "";
            ListaReparaciones.Filter = null;
        }

        private void addCriterios()
        {
            listaCriterios.Clear();
            if (!String.IsNullOrEmpty(FiltroId)) listaCriterios.Add(criterioId);
            if (!String.IsNullOrEmpty(FiltroTipo)) listaCriterios.Add(criterioTipo);
            if (!String.IsNullOrEmpty(FiltroEstado)) listaCriterios.Add(criterioEstado);
            if (!String.IsNullOrEmpty(FiltroPrecio)) listaCriterios.Add(criterioPrecio);
            if (FiltroFechaRecepcion != null) listaCriterios.Add(criterioFechaRec);
            if (FiltroFechaResolucion != null) listaCriterios.Add(criterioFechaRes);
            if (!String.IsNullOrEmpty(FiltroEmpleado)) listaCriterios.Add(criterioEmpleado);
            if (!String.IsNullOrEmpty(FiltroCliente)) listaCriterios.Add(criterioCliente);
            if (!String.IsNullOrEmpty(FiltroDescripcion)) listaCriterios.Add(criterioDescripcion);
        }

        private bool filtroCombinadoCriterios(object item)
        {
            bool correcto = true;
            reparacion rep = (reparacion)item;
            if (listaCriterios.Count() != 0)
            {
                correcto = listaCriterios.TrueForAll(x => x(rep));
            }
            return correcto;
        }
    }
}
