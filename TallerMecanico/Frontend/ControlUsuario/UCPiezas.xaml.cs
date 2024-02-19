using Microsoft.Reporting.WinForms;
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
using TallerMecanico.Backend.Servicios;
using TallerMecanico.Frontend.Dialogos;
using TallerMecanico.MVVM;

namespace TallerMecanico.Frontend.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UCPiezas.xaml
    /// </summary>
    public partial class UCPiezas : UserControl
    {
        private mydbEntities tallerEnt;
        private MVPieza mvPie;

        public UCPiezas(mydbEntities ent, empleado empLogin)
        {
            tallerEnt = ent;
            mvPie = new MVPieza(tallerEnt, empLogin);
            DataContext = mvPie;
            InitializeComponent();
        }

        private void BtnQuitarFiltros_Click(object sender, RoutedEventArgs e)
        {
            mvPie.quitarFiltros();
        }

        private void nItemEditar_Click(object sender, RoutedEventArgs e)
        {
            if (mvPie.ModificarEliminarPieza)
            {
                DialogoPiezaMVVM dial = new DialogoPiezaMVVM(tallerEnt, mvPie.PiezaSeleccionada);
                if ((bool)dial.ShowDialog()) dgListaPiezas.Items.Refresh();
            }
            else
            {
                MessageBox.Show("No tienes permiso para editar una pieza", "EDITAR PIEZA", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void nItemBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (mvPie.ModificarEliminarPieza)
            {
                MessageBoxResult mensaje = MessageBox.Show("¿Está seguro de querer borrar la pieza?", "BORRAR PIEZA", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (mensaje == MessageBoxResult.Yes)
                {
                    if (mvPie.borra)
                    {
                        MessageBox.Show("Pieza borrada correctamente", "BORRAR PIEZA", MessageBoxButton.OK, MessageBoxImage.Information);
                        mvPie.ListaPiezas = mvPie.refresca;

                    }
                    else
                    {
                        MessageBox.Show("Error al intenter borrar la pieza. Intentelo de nuevo", "BORRAR PIEZA", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No tienes permiso para borrar una pieza", "BORRAR PIEZA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FiltroId_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvPie.filtra();
        }

        private void FiltroNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvPie.filtra();
        }

        private void FiltroTipo_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvPie.filtra();
        }

        private void FiltroPrecio_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvPie.filtra();
        }

        private void FiltroCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvPie.filtra();
        }
    }
}
