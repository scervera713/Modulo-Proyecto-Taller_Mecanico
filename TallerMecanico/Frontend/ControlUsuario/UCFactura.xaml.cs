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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TallerMecanico.Backend.Modelo;
using TallerMecanico.Frontend.Dialogos;
using TallerMecanico.MVVM;

namespace TallerMecanico.Frontend.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UCFactura.xaml
    /// </summary>
    public partial class UCFactura : UserControl
    {
        private mydbEntities tallerEnt;
        private MVFactura mvFac;

        public UCFactura(mydbEntities ent, empleado empLogin)
        {
            tallerEnt = ent;
            mvFac = new MVFactura(tallerEnt, empLogin);
            DataContext = mvFac;
            InitializeComponent();
        }

        private void BtnQuitarFiltros_Click(object sender, RoutedEventArgs e)
        {
            mvFac.quitarFiltros();
        }

        private void FiltroId_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvFac.filtra();
        }

        private void FiltroFechaEmision_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            mvFac.filtra();
        }

        private void FiltroCliente_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvFac.filtra();
        }

        private void FiltroImporte_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvFac.filtra();
        }

        private void FiltroConcepto_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvFac.filtra();
        }

        private void nItemEditar_Click(object sender, RoutedEventArgs e)
        {
            DialogoFacturaMVVM dial = new DialogoFacturaMVVM(tallerEnt, mvFac.FacturaSeleccionada, true);
            if ((bool)dial.ShowDialog()) dgListaFacturas.Items.Refresh();
        }

        private void nItemBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (mvFac.EliminarFactura)
            {
                MessageBoxResult mensaje = MessageBox.Show("¿Está seguro de querer borrar la factura?", "BORRAR FACTURA", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (mensaje == MessageBoxResult.Yes)
                {
                    if (mvFac.borra)
                    {
                        MessageBox.Show("Factura borrada correctamente", "BORRAR FACTURA", MessageBoxButton.OK, MessageBoxImage.Information);
                        mvFac.ListaFacturas = mvFac.refresca;
                    }
                    else
                    {
                        MessageBox.Show("Error al intenter borrar la factura. Intentelo de nuevo", "BORRAR FACTURA", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No tienes permiso para borrar una factura", "BORRAR FACTURA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
