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
    /// Lógica de interacción para DialogoFacturaMVVM.xaml
    /// </summary>
    public partial class DialogoFacturaMVVM : MetroWindow
    {
        private mydbEntities tallerEnt;
        private MVFactura mvFac;
        private bool editar;
        private double importeTotal;

        public DialogoFacturaMVVM(mydbEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvFac = new MVFactura(ent);
            DataContext = mvFac;
            editar = false;
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvFac.OnErrorEvent));
            mvFac.btnGuardar = BtnGuardar;
        }

        public DialogoFacturaMVVM(mydbEntities ent, factura f, bool soloVerFactura)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvFac = new MVFactura(ent, f);
            DataContext = mvFac;
            editar = true;
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvFac.OnErrorEvent));
            mvFac.btnGuardar = BtnGuardar;

            if (soloVerFactura)
            {
                BtnGuardar.IsEnabled = false;
                txtConcepto.IsEnabled = false;
                dpFechaEmison.IsEnabled = false;
                //CBCliente.IsEnabled = false;
                CBReparacion.IsEnabled = false;
            }
        }

        private async void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            bool operacion = true;

            if (mvFac.IsValid(this))
            {
                if (editar)
                {
                    operacion = mvFac.edita;
                }
                else
                {
                    if (mvFac.nuevaFactura != null) mvFac.nuevaFactura.importeTotal = importeTotal;
                    operacion = mvFac.guarda;
                }

                if (operacion)
                {
                    await this.ShowMessageAsync("GESTIÓN FACTURA", "TODO CORRECTO. La factura se ha guardado correctamente en la BD");
                    DialogResult = true;
                }
                else
                {
                    await this.ShowMessageAsync("GESTIÓN FACTURA", "ERROR. PROBLEMAS PARA GUARDAR EN LA BD");
                }
            }
            else
            {
                await this.ShowMessageAsync("GESTIÓN FACTURA", "ERROR. HAY CAMPOS OBLIGATORIOS SIN RELLENAR");
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        //private void CBCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    txtNombreCli.Text = mvFac.nuevaFactura.cliente.nombre;
        //    txtApellidosCli.Text = mvFac.nuevaFactura.cliente.apellidos;
        //    txtDNICli.Text = mvFac.nuevaFactura.cliente.dni;
        //    txtTelefonoCli.Text = mvFac.nuevaFactura.cliente.telefono;
        //    txtEmailCli.Text = mvFac.nuevaFactura.cliente.email;
        //    txtPoblacionCli.Text = mvFac.nuevaFactura.cliente.poblacion;
        //    txtDireccionCli.Text = mvFac.nuevaFactura.cliente.direccion;
        //}

        private void CBReparacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtPrecioRep.Text = mvFac.nuevaFactura.reparacion.precio.ToString();
            dgListaPiezas.ItemsSource = mvFac.nuevaFactura.reparacion.pieza;
            txtImporte.Text = mvFac.importeTotal.ToString();
            importeTotal = mvFac.importeTotal;

            mvFac.nuevaFactura.cliente = mvFac.nuevaFactura.reparacion.cliente;
            txtNombreCli.Text = mvFac.nuevaFactura.reparacion.cliente.nombre;
            txtApellidosCli.Text = mvFac.nuevaFactura.reparacion.cliente.apellidos;
            txtDNICli.Text = mvFac.nuevaFactura.reparacion.cliente.dni;
            txtTelefonoCli.Text = mvFac.nuevaFactura.reparacion.cliente.telefono;
            txtEmailCli.Text = mvFac.nuevaFactura.reparacion.cliente.email;
            txtPoblacionCli.Text = mvFac.nuevaFactura.reparacion.cliente.poblacion;
            txtDireccionCli.Text = mvFac.nuevaFactura.reparacion.cliente.direccion;
            
            //CBCliente.SelectedItem = mvFac.nuevaFactura.reparacion.cliente;
        }
    }
}
