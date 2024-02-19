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
    /// Lógica de interacción para UCCliente.xaml
    /// </summary>
    public partial class UCCliente : UserControl
    {
        private mydbEntities tallerEnt;
        private MVCliente mvCli;

        public UCCliente(mydbEntities ent, empleado empLogin)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvCli = new MVCliente(tallerEnt,empLogin);
            DataContext = mvCli;
        }

        private void BtnQuitarFiltros_Click(object sender, RoutedEventArgs e)
        {
            mvCli.quitarFiltros();
        }

        private void nItemEditar_Click(object sender, RoutedEventArgs e)
        {
            if (mvCli.GestionarClientes)
            {
                DialogoClienteMVVM dial = new DialogoClienteMVVM(tallerEnt, mvCli.ClienteSeleccionado);
                if ((bool)dial.ShowDialog()) dgListaClientes.Items.Refresh();
            }
            else
            {
                MessageBox.Show("No tienes permiso para editar clientes", "EDITAR CLIENTE", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void nItemBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (mvCli.GestionarClientes)
            {
                MessageBoxResult mensaje = MessageBox.Show("¿Está seguro de querer borrar el cliente?", "BORRAR CLIENTE", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (mensaje == MessageBoxResult.Yes)
                {
                    if (mvCli.borra)
                    {
                        MessageBox.Show("Cliente borrado correctamente", "BORRAR CLIENTE", MessageBoxButton.OK, MessageBoxImage.Information);
                        mvCli.ListaClientes = mvCli.refresca;
                    }
                    else
                    {
                        MessageBox.Show("Error al intenter borrar el cliente. Intentelo de nuevo", "BORRAR CLIENTE", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No tienes permiso para borrar clientes", "BORRAR CLIENTE", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FiltroId_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvCli.filtra();
        }

        private void FiltroNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvCli.filtra();
        }

        private void FiltroEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvCli.filtra();
        }

        private void FiltroDNI_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvCli.filtra();
        }

        private void FiltroTelefono_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvCli.filtra();
        }
    }
}
