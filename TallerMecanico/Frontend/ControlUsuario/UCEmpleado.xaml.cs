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
    /// Lógica de interacción para UCEmpleado.xaml
    /// </summary>
    public partial class UCEmpleado : UserControl
    {
        private mydbEntities tallerEnt;
        private MVEmpleado mvEmp;
        private empleado emp;

        public UCEmpleado(mydbEntities tallerEnt, empleado e)
        {
            InitializeComponent();
            this.tallerEnt = tallerEnt;
            emp = e;
            mvEmp = new MVEmpleado(tallerEnt);
            DataContext = mvEmp;
            if (emp != null && emp.rol != null && (emp.rol.idRol == 2 || emp.rol.idRol == 3))
            {
                dgUsuario.Visibility = Visibility.Collapsed;
                FiltroUsuario.Visibility = Visibility.Collapsed;
                dgContrasenya.Visibility = Visibility.Collapsed;
                FiltroContrasenya.Visibility = Visibility.Collapsed;
            }
        }

        private void nItemEditar_Click(object sender, RoutedEventArgs e)
        {
            if (mvEmp.GestionarEmpleados(emp) || emp.idEmpleado == mvEmp.EmpleadoSeleccionado.idEmpleado)
            {
                DialogoEmpleadoMVVM dial = new DialogoEmpleadoMVVM(tallerEnt, mvEmp.EmpleadoSeleccionado, emp);
                if ((bool)dial.ShowDialog()) dgListaEmpleados.Items.Refresh();
            }
            else
            {
                MessageBox.Show("No tienes permiso para editar otros empleados", "EDITAR EMPLEADO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void nItemBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (mvEmp.GestionarEmpleados(emp))
            {
                MessageBoxResult mensaje = MessageBox.Show("¿Está seguro de querer borrar el empleado?", "BORRAR EMPLEADO", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (mensaje == MessageBoxResult.Yes)
                {
                    if (mvEmp.borra)
                    {
                        MessageBox.Show("Empleado borrado correctamente", "BORRAR EMPLEADO", MessageBoxButton.OK, MessageBoxImage.Information);
                        mvEmp.ListaEmpleados = mvEmp.refresca;
                    }
                    else
                    {
                        MessageBox.Show("Error al intenter borrar el empleado. Intentelo de nuevo", "BORRAR EMPLEADO", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No tienes permiso para borrar empleados", "BORRAR EMPLEADO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FiltroNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvEmp.filtra();
        }

        private void BtnQuitarFiltros_Click(object sender, RoutedEventArgs e)
        {
            mvEmp.quitarFiltros();
        }

        private void FiltroId_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvEmp.filtra();
        }

        private void FiltroUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvEmp.filtra();
        }

        private void FiltroContrasenya_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvEmp.filtra();
        }

        private void FiltroRol_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvEmp.filtra();
        }
    }
}
