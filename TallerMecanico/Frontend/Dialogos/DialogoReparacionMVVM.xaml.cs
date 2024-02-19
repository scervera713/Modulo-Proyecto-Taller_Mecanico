using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TallerMecanico.Backend.Modelo;
using TallerMecanico.MVVM;

namespace TallerMecanico.Frontend.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DialogoReparacionMVVM.xaml
    /// </summary>
    public partial class DialogoReparacionMVVM : MetroWindow
    {
        private mydbEntities tallerEnt;
        private MVReparacion mvRep;
        private bool editar;
        private empleado emp;
        private List<pieza> lPz;

        public DialogoReparacionMVVM(mydbEntities tallerEnt, empleado empLogin)
        {
            InitializeComponent();
            this.tallerEnt = tallerEnt;
            mvRep = new MVReparacion(tallerEnt, empLogin);
            DataContext = mvRep;
            editar = false;
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvRep.OnErrorEvent));
            mvRep.btnGuardar = BtnGuardar;
        }

        public DialogoReparacionMVVM(mydbEntities ent, reparacion rep, empleado empLogin)
        {
            InitializeComponent();
            tallerEnt = ent;
            emp = empLogin;
            mvRep = new MVReparacion(tallerEnt,rep, emp);
            DataContext = mvRep;
            lPz = mvRep.nuevaReparacion.pieza.ToList();
            editar = true;
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvRep.OnErrorEvent));
            mvRep.btnGuardar = BtnGuardar;

            if (emp != null && emp.rol != null && emp.rol.idRol == 3)
            {
                CBEmpleado.IsEnabled = false;   
                CBCliente.IsEnabled = false;
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if(lPz != null && mvRep.nuevaReparacion.pieza.Count() != lPz.Count())
            {
                mvRep.nuevaReparacion.pieza.Clear();
                foreach (pieza p in lPz)
                {
                    mvRep.nuevaReparacion.pieza.Add(p);
                }
            }
            DialogResult = false;
        }

        private async void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {      
            bool operacion = true;

            if (mvRep.IsValid(this))
            {
                if (editar)
                {
                    operacion = mvRep.edita;
                }
                else
                {
                    operacion = mvRep.guarda;
                }

                if (operacion)
                {
                    await this.ShowMessageAsync("GESTIÓN REPARACIÓN", "TODO CORRECTO. La reparación se ha guardado correctamente en la BD");
                    DialogResult = true;
                }
                else
                {
                    await this.ShowMessageAsync("GESTIÓN REPARACIÓN", "ERROR!!. PROBLEMAS PARA GUARDAR EN LA BD");
                }
            }
            else
            {
                await this.ShowMessageAsync("GESTIÓN REPARACIÓN", "ERROR!!. HAY CAMPOS OBLIGATORIOS SIN RELLENAR");
            }
        }

        private void BtnAbrirListadoPiezas_Click(object sender, RoutedEventArgs e)
        {
            DialogoAnyadirPieza dial = new DialogoAnyadirPieza(tallerEnt, mvRep.nuevaReparacion, dgListaPiezas);
            dial.ShowDialog();
            txtPrecio.Text = mvRep.precioTotal.ToString();
        }
        private void TxtHoras_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtPrecio.Text = mvRep.precioTotal.ToString();
        }

        private async void btnVerFactura_Click(object sender, RoutedEventArgs e)
        {
            if (mvRep.nuevaReparacion.factura.Count > 0)
            {
                DialogoFacturaMVVM dial = new DialogoFacturaMVVM(tallerEnt, mvRep.nuevaReparacion.factura.FirstOrDefault(), true);
                dial.ShowDialog();
            }
            else
            {
                await this.ShowMessageAsync("GESTIÓN REPARACIÓN", "La reparación no tiene ninguna factura asociada");
            }
        }

        private void btnBorrarPieza_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaPiezas.SelectedItem != null && dgListaPiezas.SelectedItem is pieza)
            {
                pieza pi = (pieza)dgListaPiezas.SelectedItem;
                if (mvRep.nuevaReparacion.pieza.Remove(pi)) dgListaPiezas.Items.Refresh();
                txtPrecio.Text = mvRep.precioTotal.ToString();
            }
        }

        private void dpFechaResolucion_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpFechaResolucion.SelectedDate < mvRep.nuevaReparacion.fechaRecepcion)
            {
                MessageBox.Show("No se puede poner una fecha de resolución anterior a la fecha de recepción", "FECHA RESOLUCIÓN", MessageBoxButton.OK, MessageBoxImage.Warning);
                dpFechaResolucion.SelectedDate = null;
            }
        }
    }
}
