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
    /// Lógica de interacción para UCReparaciones.xaml
    /// </summary>
    public partial class UCReparaciones : UserControl
    {
        private mydbEntities tallerEnt;
        private empleado emp;
        private MVReparacion mvRep;


        public UCReparaciones(mydbEntities ent, empleado e)
        {
            tallerEnt = ent;
            emp = e;
            mvRep = new MVReparacion(tallerEnt,e);
            DataContext = mvRep;
            InitializeComponent();
        }

        private void BtnQuitarFiltros_Click(object sender, RoutedEventArgs e)
        {
            mvRep.quitarFiltros();
        }

        private void nItemEditar_Click(object sender, RoutedEventArgs e)
        {
            DialogoReparacionMVVM dial = new DialogoReparacionMVVM(tallerEnt, mvRep.ReparacionSeleccionada,emp);
            if ((bool)dial.ShowDialog()) dgListaReparaciones.Items.Refresh();
        }

        private void nItemBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (mvRep.EliminarReparaciones)
            {
                if (mvRep.ReparacionSeleccionada.factura.Count() <= 0)
                {
                    MessageBoxResult mensaje = MessageBox.Show("¿Está seguro de querer borrar la reparación?", "BORRAR REPARACIÓN", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (mensaje == MessageBoxResult.Yes)
                    {
                        if (mvRep.ReparacionSeleccionada != null) mvRep.ReparacionSeleccionada.pieza.Clear();

                        if (mvRep.borra)
                        {
                            MessageBox.Show("Reparación borrada correctamente", "BORRAR REPARACIÓN", MessageBoxButton.OK, MessageBoxImage.Information);
                            mvRep.ListaReparaciones = mvRep.refresca;
                        }
                        else
                        {
                            MessageBox.Show("Error al intenter borrar la reparación. Intentelo de nuevo", "BORRAR REPARACIÓN", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No puedes borrar una reparacion con una factura asociada. Primero, borra la factura", "BORRAR REPARACIÓN", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("No tienes permiso para borrar una reparación", "BORRAR REPARACIÓN", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FiltroId_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvRep.filtra();
        }

        private void FiltroTipo_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvRep.filtra();
        }

        private void FiltroEstado_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvRep.filtra();
        }

        private void FiltroPrecio_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvRep.filtra();
        }

        private void FiltroEmpleado_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvRep.filtra();
        }

        private void FiltroDescripcion_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvRep.filtra();
        }

        private void FiltroCliente_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvRep.filtra();
        }

        private void FiltroFechaRecepcion_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            mvRep.filtra();
        }

        private void FiltroFechaResolución_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            mvRep.filtra();
        }
    }
}
