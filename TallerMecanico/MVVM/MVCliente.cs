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
    public class MVCliente : MVBaseCRUD<cliente>
    {
        private mydbEntities tallerEnt;
        private cliente cli;
        private empleado empLogin;
        private cliente cliOriginal;
        private cliente cliSel;
        private ClienteServicio cliServ;
        private ListCollectionView lista;
        private String id;
        private String nombre;
        private String email;
        private String dni;
        private String tel;

        private List<Predicate<cliente>> listaCriterios;
        private Predicate<cliente> criterioId;
        private Predicate<cliente> criterioNombre;
        private Predicate<cliente> criterioEmail;
        private Predicate<cliente> criterioDNI;
        private Predicate<cliente> criterioTelefono;
        private Predicate<object> filtroPredicados;

        public MVCliente(mydbEntities tallerEnt)
        {
            this.tallerEnt = tallerEnt;
            cli = new cliente();
            inicializar();
        }

        public MVCliente(mydbEntities tallerEnt, empleado empL)
        {
            this.tallerEnt = tallerEnt;
            empLogin = empL;
            cli = new cliente();
            inicializar();
        }

        public MVCliente(mydbEntities tallerEnt, cliente c)
        {
            this.tallerEnt = tallerEnt;
            cliOriginal = c;
            cli = new cliente();
            CopiarCliente(cliOriginal, cli);
            inicializar();
        }

        public void inicializar()
        {
            cliServ = new ClienteServicio(tallerEnt);
            servicio = cliServ;
            lista = new ListCollectionView(servicio.getAll().ToList());

            listaCriterios = new List<Predicate<cliente>>();
            criterioId = new Predicate<cliente>(c => c.idCliente.ToString().Contains(FiltroId));
            criterioNombre = new Predicate<cliente>(c => !String.IsNullOrEmpty(c.nombre) && !String.IsNullOrEmpty(c.apellidos)
              && nombreCompletoCliente(c).ToUpper().Contains(FiltroNombre.ToUpper()));
            criterioEmail = new Predicate<cliente>(c => !String.IsNullOrEmpty(c.email) && c.email.ToUpper().Contains(FiltroEmail.ToUpper()));
            criterioDNI = new Predicate<cliente>(c => !String.IsNullOrEmpty(c.dni) && c.dni.ToUpper().Contains(FiltroDNI.ToUpper()));
            criterioTelefono = new Predicate<cliente>(c => !String.IsNullOrEmpty(c.telefono) && c.telefono.ToUpper().Contains(FiltroTelefono.ToUpper()));
            filtroPredicados = new Predicate<object>(filtroCombinadoCriterios);
        }

        public void CopiarCliente(cliente fuente, cliente destino)
        {
            if (destino != null)
            {
                destino.nombre = fuente.nombre;
                destino.apellidos = fuente.apellidos;
                destino.email = fuente.email;
                destino.direccion = fuente.direccion;
                destino.telefono = fuente.telefono;
                destino.dni = fuente.dni;
                destino.poblacion = fuente.poblacion;
                destino.factura = fuente.factura;
                destino.reparacion = fuente.reparacion;
            }
        }

        public ListCollectionView ListaClientes
        {
            get { return lista; }
            set { lista = value; NotifyPropertyChanged(nameof(ListaClientes)); }
        }

        public ListCollectionView refresca
        {
            get { return new ListCollectionView(servicio.getAll().ToList()); }
        }

        public cliente nuevoCliente
        {
            get { return cli; }
            set { cli = value; NotifyPropertyChanged(nameof(nuevoCliente)); }
        }

        public cliente ClienteSeleccionado
        {
            get { return cliSel; }
            set { cliSel = value; NotifyPropertyChanged(nameof(ClienteSeleccionado)); }
        }

        public String nombreCompletoCliente(cliente cli)
        {
            String cadena = cli.nombre + " " + cli.apellidos;
            return cadena;
        }

        public bool guarda
        {
            get
            {
                return add(nuevoCliente);
            }
        }

        public bool edita
        {
            get
            {
                CopiarCliente(nuevoCliente, cliOriginal);
                return update(cliOriginal);
            }
        }

        public bool GestionarClientes
        {
            get
            {
                bool permiso = false;
                if (empLogin != null && empLogin.rol != null)
                {
                    foreach (permiso p in empLogin.rol.permiso)
                    {
                        if (p.idPermiso == 8) permiso = true;
                    }
                }

                return permiso;
            }
        }

        public bool borra
        {
            get { return delete(ClienteSeleccionado); }
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

        public String FiltroEmail
        {
            get { return email; }
            set { email = value; NotifyPropertyChanged(nameof(FiltroEmail)); }
        }

        public String FiltroDNI
        {
            get { return dni; }
            set { dni = value; NotifyPropertyChanged(nameof(FiltroDNI)); }
        }

        public String FiltroTelefono
        {
            get { return tel; }
            set { tel = value; NotifyPropertyChanged(nameof(FiltroTelefono)); }
        }

        public void filtra()
        {
            addCriterios();
            ListaClientes.Filter = filtroPredicados;
        }

        public void quitarFiltros()
        {
            FiltroId = "";
            FiltroNombre = "";
            FiltroEmail = "";
            FiltroDNI = "";
            FiltroTelefono = "";
            ListaClientes.Filter = null;
        }

        private void addCriterios()
        {
            listaCriterios.Clear();
            if (!String.IsNullOrEmpty(FiltroId)) listaCriterios.Add(criterioId);
            if (!String.IsNullOrEmpty(FiltroNombre)) listaCriterios.Add(criterioNombre);
            if (!String.IsNullOrEmpty(FiltroEmail)) listaCriterios.Add(criterioEmail);
            if (!String.IsNullOrEmpty(FiltroDNI)) listaCriterios.Add(criterioDNI);
            if (!String.IsNullOrEmpty(FiltroTelefono)) listaCriterios.Add(criterioTelefono);
        }

        private bool filtroCombinadoCriterios(object item)
        {
            bool correcto = true;
            cliente c = (cliente)item;
            if (listaCriterios.Count() != 0)
            {
                correcto = listaCriterios.TrueForAll(x => x(c));
            }
            return correcto;
        }
    }
}
