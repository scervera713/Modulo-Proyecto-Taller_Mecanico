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
    public class MVPieza : MVBaseCRUD<pieza>
    {
        private mydbEntities tallerEnt;
        private pieza p;
        private pieza piezaOriginal;
        private pieza pieSel;
        private empleado emp;
        private PiezaServicio pieSerV;
        private ListCollectionView lista;
        private String id;
        private String nombre;
        private String tipo;
        private String precio;
        private String cantidad;

        private List<Predicate<pieza>> listaCriterios;
        private Predicate<pieza> criterioId;
        private Predicate<pieza> criterioNombre;
        private Predicate<pieza> criterioTipo;
        private Predicate<pieza> criterioPrecio;
        private Predicate<pieza> criterioCantidad;
        private Predicate<object> filtroPredicados;

        public MVPieza(mydbEntities tallerEnt)
        {
            this.tallerEnt = tallerEnt;
            p = new pieza();
            inicializar();
        }

        public MVPieza(mydbEntities tallerEnt, empleado e)
        {
            this.tallerEnt = tallerEnt;
            p = new pieza();
            emp = e;
            inicializar();
        }

        public MVPieza(mydbEntities tallerEnt, pieza pz)
        {
            this.tallerEnt = tallerEnt;
            piezaOriginal = pz;
            p = new pieza();
            CopiarPieza(piezaOriginal, p);
            inicializar();
        }

        public void inicializar()
        {
            pieSerV = new PiezaServicio(tallerEnt);
            servicio = pieSerV;
            lista = new ListCollectionView(servicio.getAll().ToList());

            listaCriterios = new List<Predicate<pieza>>();
            criterioId = new Predicate<pieza>(p => p.idPieza.ToString().Contains(FiltroId));
            criterioNombre = new Predicate<pieza>(p => !String.IsNullOrEmpty(p.descripcion) && p.descripcion.ToUpper().Contains(FiltroNombre.ToUpper()));
            criterioTipo = new Predicate<pieza>(p => !String.IsNullOrEmpty(p.tipo) && p.tipo.ToUpper().Contains(FiltroTipo.ToUpper()));
            criterioPrecio = new Predicate<pieza>(p => p.precio.ToString().Contains(FiltroPrecio));
            criterioCantidad = new Predicate<pieza>(p => p.cantidad.ToString().Contains(FiltroCantidad));
            filtroPredicados = new Predicate<object>(filtroCombinadoCriterios);
        }

        public void CopiarPieza(pieza fuente, pieza destino)
        {
            if (destino != null)
            {
                destino.descripcion = fuente.descripcion;
                destino.cantidad = fuente.cantidad;
                destino.tipo = fuente.tipo;
                destino.precio = fuente.precio;
                destino.reparacion = fuente.reparacion;
            }
        }

        public ListCollectionView ListaPiezas
        {
            get { return lista; }
            set { lista = value; NotifyPropertyChanged(nameof(ListaPiezas)); }
        }

        public ListCollectionView refresca
        {
            get { return new ListCollectionView(servicio.getAll().ToList()); }
        }

        public pieza PiezaSeleccionada
        {
            get { return pieSel; }
            set { pieSel = value; NotifyPropertyChanged(nameof(PiezaSeleccionada)); }
        }

        public pieza nuevaPieza
        {
            get { return p; }
            set { p = value; NotifyPropertyChanged(nameof(nuevaPieza)); }
        }

        public bool ModificarEliminarPieza
        {
            get
            {
                bool permiso = false;
                if (emp != null && emp.rol != null)
                {
                    foreach (permiso p in emp.rol.permiso)
                    {
                        if (p.idPermiso == 3) permiso = true;
                    }
                }

                return permiso;
            }
        }

        public bool guarda
        {
            get
            {
                return add(nuevaPieza);
            }
        }

        public bool edita
        {
            get
            {
                CopiarPieza(nuevaPieza, piezaOriginal);
                return update(piezaOriginal);
            }
        }

        public bool borra
        {
            get { return delete(PiezaSeleccionada); }
        }

        public String FiltroId
        {
            get { return id; }
            set { id = value; NotifyPropertyChanged(nameof(FiltroId)); }
        }

        public String FiltroNombre
        {
            get { return nombre; }
            set { nombre = value; NotifyPropertyChanged(nameof(FiltroNombre)); }
        }

        public String FiltroTipo
        {
            get { return tipo; }
            set { tipo = value; NotifyPropertyChanged(nameof(FiltroTipo)); }
        }

        public String FiltroPrecio
        {
            get { return precio; }
            set { precio = value; NotifyPropertyChanged(nameof(FiltroPrecio)); }
        }

        public String FiltroCantidad
        {
            get { return cantidad; }
            set { cantidad = value; NotifyPropertyChanged(nameof(FiltroCantidad)); }
        }

        public void filtra()
        {
            addCriterios();
            ListaPiezas.Filter = filtroPredicados;
        }

        public void quitarFiltros()
        {
            FiltroId = "";
            FiltroNombre = "";
            FiltroPrecio = "";
            FiltroTipo = "";
            FiltroCantidad = "";
            ListaPiezas.Filter = null;
        }

        private void addCriterios()
        {
            listaCriterios.Clear();
            if (!String.IsNullOrEmpty(FiltroId)) listaCriterios.Add(criterioId);
            if (!String.IsNullOrEmpty(FiltroNombre)) listaCriterios.Add(criterioNombre);
            if (!String.IsNullOrEmpty(FiltroTipo)) listaCriterios.Add(criterioTipo);
            if (!String.IsNullOrEmpty(FiltroPrecio)) listaCriterios.Add(criterioPrecio);
            if (!String.IsNullOrEmpty(FiltroCantidad)) listaCriterios.Add(criterioCantidad);
        }

        private bool filtroCombinadoCriterios(object item)
        {
            bool correcto = true;
            pieza p = (pieza)item;
            if (listaCriterios.Count() != 0)
            {
                correcto = listaCriterios.TrueForAll(x => x(p));
            }
            return correcto;
        }
    }
}
