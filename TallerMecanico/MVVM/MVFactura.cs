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
    public class MVFactura : MVBaseCRUD<factura>
    {
        private mydbEntities tallerEnt;
        private factura fac;
        private factura facOriginal;
        private factura facSel;
        private empleado emp;
        private FacturaServicio facServ;
        private ClienteServicio cliServ;
        private ReparacionServicio repServ;
        private ListCollectionView lista;
        private String id;
        private DateTime? fechaEmision;
        private String cliente;
        private String importe;
        private String concepto;

        private List<Predicate<factura>> listaCriterios;
        private Predicate<factura> criterioId;
        private Predicate<factura> criterioImporte;
        private Predicate<factura> criterioFechaEmi;
        private Predicate<factura> criterioCliente;
        private Predicate<factura> criterioConcepto;
        private Predicate<object> filtroPredicados;

        public MVFactura(mydbEntities tallerEnt)
        {
            this.tallerEnt = tallerEnt;
            fac = new factura();
            fac.fechaEmision = DateTime.Now;
            inicializar();
        }

        public MVFactura(mydbEntities tallerEnt, empleado empLogin)
        {
            this.tallerEnt = tallerEnt;
            emp = empLogin;
            fac = new factura();
            fac.fechaEmision = DateTime.Now;
            inicializar();
        }


        public MVFactura(mydbEntities tallerEnt, factura f)
        {
            this.tallerEnt = tallerEnt;
            facOriginal = f;
            fac = new factura();
            CopiarFactura(facOriginal, fac);
            inicializar();
        }

        public void inicializar()
        {
            facServ = new FacturaServicio(tallerEnt);
            cliServ = new ClienteServicio(tallerEnt);
            repServ = new ReparacionServicio(tallerEnt);
            servicio = facServ;
            lista = new ListCollectionView(servicio.getAll().ToList());

            listaCriterios = new List<Predicate<factura>>();
            criterioId = new Predicate<factura>(f => f.idFactura.ToString().Contains(FiltroId));
            criterioFechaEmi = new Predicate<factura>(f => f.fechaEmision != null && f.fechaEmision.Date.Equals(FiltroFechaEmision.Value.Date));
            criterioCliente = new Predicate<factura>(f => f.cliente != null && !String.IsNullOrEmpty(f.cliente.nombre) && !String.IsNullOrEmpty(f.cliente.apellidos)
              && nombreCompletoCliente(f.cliente).ToUpper().Contains(FiltroCliente.ToUpper()));
            criterioImporte = new Predicate<factura>(f => f.importeTotal.ToString().Contains(FiltroImporte));
            criterioConcepto = new Predicate<factura>(f => !String.IsNullOrEmpty(f.concepto) && f.concepto.ToUpper().Contains(FiltroConcepto.ToUpper()));
            filtroPredicados = new Predicate<object>(filtroCombinadoCriterios);
        }

        public void CopiarFactura(factura fuente, factura destino)
        {
            if (destino != null)
            {
                destino.idFactura = fuente.idFactura;
                destino.fechaEmision = fuente.fechaEmision;
                destino.concepto = fuente.concepto;
                destino.importeTotal = fuente.importeTotal;
                destino.Cliente_idCliente = fuente.Cliente_idCliente;
                destino.cliente = fuente.cliente;
                destino.Reparacion_idReparacion = fuente.Reparacion_idReparacion;
                destino.reparacion = fuente.reparacion;
            }
        }

        public ListCollectionView ListaFacturas
        {
            get { return lista; }
            set { lista = value; NotifyPropertyChanged(nameof(ListaFacturas)); }
        }

        public ListCollectionView refresca
        {
            get { return new ListCollectionView(servicio.getAll().ToList()); }
        }

        public List<cliente> ListaClientes
        {
            get { return cliServ.getAll().ToList(); }
        }

        public List<reparacion> ListaReparaciones
        {
            get { return repServ.getAll().ToList(); }
        }

        public factura nuevaFactura
        {
            get { return fac; }
            set { fac = value; NotifyPropertyChanged(nameof(nuevaFactura)); }
        }

        public factura FacturaSeleccionada
        {
            get { return facSel; }
            set { facSel = value; NotifyPropertyChanged(nameof(FacturaSeleccionada)); }
        }

        public double importeTotal
        {
            get
            {
                if (nuevaFactura != null)
                {
                    double precio = nuevaFactura.reparacion.precio;
                    double precioAnyadido = precio * 21 / 100.0;
                    return precio + precioAnyadido;
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool guarda
        {
            get { return add(nuevaFactura); }
        }

        public bool edita
        {
            get 
            {
                CopiarFactura(nuevaFactura, facOriginal);
                return update(facOriginal); 
            }
        }

        public bool borra
        {
            get { return delete(FacturaSeleccionada); }
        }

        public bool EliminarFactura
        {
            get
            {
                bool permiso = false;
                if (emp != null && emp.rol != null)
                {
                    foreach (permiso p in emp.rol.permiso)
                    {
                        if (p.idPermiso == 5) permiso = true;
                    }
                }

                return permiso;
            }
        }

        public String nombreCompletoCliente(cliente cli)
        {
            String cadena = cli.nombre + " " + cli.apellidos;
            return cadena;
        }

        public String FiltroId
        {
            get { return id; }
            set { id = value; NotifyPropertyChanged(nameof(FiltroId)); }
        }

        public DateTime? FiltroFechaEmision
        {
            get { return fechaEmision; }
            set { fechaEmision = value; NotifyPropertyChanged(nameof(FiltroFechaEmision)); }
        }

        public String FiltroCliente
        {
            get { return cliente; }
            set { cliente = value; NotifyPropertyChanged(nameof(FiltroCliente)); }
        }

        public String FiltroImporte
        {
            get { return importe; }
            set { importe = value; NotifyPropertyChanged(nameof(FiltroImporte)); }
        }

        public String FiltroConcepto
        {
            get { return concepto; }
            set { concepto = value; NotifyPropertyChanged(nameof(FiltroConcepto)); }
        }

        public void filtra()
        {
            addCriterios();
            ListaFacturas.Filter = filtroPredicados;
        }

        public void quitarFiltros()
        {
            FiltroId = "";
            FiltroFechaEmision = null;
            FiltroCliente = "";
            FiltroImporte = "";
            FiltroConcepto = "";
            ListaFacturas.Filter = null;
        }

        private void addCriterios()
        {
            listaCriterios.Clear();
            if (!String.IsNullOrEmpty(FiltroId)) listaCriterios.Add(criterioId);
            if (FiltroFechaEmision != null) listaCriterios.Add(criterioFechaEmi);
            if (!String.IsNullOrEmpty(FiltroCliente)) listaCriterios.Add(criterioCliente);
            if (!String.IsNullOrEmpty(FiltroImporte)) listaCriterios.Add(criterioImporte);
            if (!String.IsNullOrEmpty(FiltroConcepto)) listaCriterios.Add(criterioConcepto);
        }

        private bool filtroCombinadoCriterios(object item)
        {
            bool correcto = true;
            factura f = (factura)item;
            if (listaCriterios.Count() != 0)
            {
                correcto = listaCriterios.TrueForAll(x => x(f));
            }
            return correcto;
        }
    }
}
