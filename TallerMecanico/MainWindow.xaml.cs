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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TallerMecanico.Backend.Modelo;
using TallerMecanico.Frontend.ControlUsuario;
using TallerMecanico.Frontend.Dialogos;
using TallerMecanico.MVVM;

namespace TallerMecanico
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private mydbEntities tallerEnt;
        private empleado emp;
        private MVEmpleado mvEmp;

        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(mydbEntities tallerEnt, empleado emp)
        {
            this.tallerEnt = tallerEnt;
            this.emp = emp;
            mvEmp = new MVEmpleado(tallerEnt,emp);
            DataContext = mvEmp;
            InitializeComponent();
        }

        private void listaEmpleados_Selected(object sender, RoutedEventArgs e)
        {
            UCEmpleado uc = new UCEmpleado(tallerEnt, emp);
            if(gridCentral.Children != null) { gridCentral.Children.Clear(); }
            gridCentral.Children.Add(uc);
        }

        private async void AddEmpleado_Selected(object sender, RoutedEventArgs e)
        {
            if (mvEmp.GestionarEmpleados(emp))
            {
                Image fondo = new Image();
                BitmapImage im = new BitmapImage(new Uri("Recursos/Imagenes/TallerFondoMain.jpeg", UriKind.Relative));
                fondo.Source = im;
                fondo.Stretch = Stretch.Fill;
                if (gridCentral.Children != null) { gridCentral.Children.Clear(); }
                gridCentral.Children.Add(fondo);
                DialogoEmpleadoMVVM dial = new DialogoEmpleadoMVVM(tallerEnt, emp);
                dial.ShowDialog();
            }
            else
            {
                await this.ShowMessageAsync("GESTIÓN EMPLEADO", "No tiene permisos para añadir un empleado");
            }
        }

        private void listaReparaciones_Selected(object sender, RoutedEventArgs e)
        {
            UCReparaciones uc = new UCReparaciones(tallerEnt, emp);
            if (gridCentral.Children != null) { gridCentral.Children.Clear(); }
            gridCentral.Children.Add(uc);
        }

        private void anyadirReparacion_Selected(object sender, RoutedEventArgs e)
        {
            Image fondo = new Image();
            BitmapImage im = new BitmapImage(new Uri("Recursos/Imagenes/TallerFondoMain.jpeg", UriKind.Relative));
            fondo.Source = im;
            fondo.Stretch = Stretch.Fill;
            if (gridCentral.Children != null) { gridCentral.Children.Clear(); }
            gridCentral.Children.Add(fondo);
            DialogoReparacionMVVM dial = new DialogoReparacionMVVM(tallerEnt, emp);
            dial.ShowDialog();
        }

        private async void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MessageDialogResult message = await this.ShowMessageAsync("CERRAR SESIÓN", "¿Está seguro de cerrar la sesión?", MessageDialogStyle.AffirmativeAndNegative);
            if (message == MessageDialogResult.Affirmative)
            {
                Login ventanaPrincipal = new Login();
                ventanaPrincipal.Show();
                this.Close();
            }
        }

        private void listadoInventario_Click(object sender, RoutedEventArgs e)
        {
            UCPiezas uc = new UCPiezas(tallerEnt, emp);
            if (gridCentral.Children != null) { gridCentral.Children.Clear(); }
            gridCentral.Children.Add(uc);
        }

        private void anyadirPieza_Click(object sender, RoutedEventArgs e)
        {
            Image fondo = new Image();
            BitmapImage im = new BitmapImage(new Uri("Recursos/Imagenes/TallerFondoMain.jpeg", UriKind.Relative));
            fondo.Source = im;
            fondo.Stretch = Stretch.Fill;
            if (gridCentral.Children != null) { gridCentral.Children.Clear(); }
            gridCentral.Children.Add(fondo);
            DialogoPiezaMVVM dial = new DialogoPiezaMVVM(tallerEnt);
            dial.ShowDialog();
        }

        private void listadoClientes_Click(object sender, RoutedEventArgs e)
        {
            UCCliente uc = new UCCliente(tallerEnt,emp);
            if (gridCentral.Children != null) { gridCentral.Children.Clear(); }
            gridCentral.Children.Add(uc);
        }

        private async void anyadirCliente_Click(object sender, RoutedEventArgs e)
        {
            if (mvEmp.IntroducirClientes(emp))
            {
                Image fondo = new Image();
                BitmapImage im = new BitmapImage(new Uri("Recursos/Imagenes/TallerFondoMain.jpeg", UriKind.Relative));
                fondo.Source = im;
                fondo.Stretch = Stretch.Fill;
                if (gridCentral.Children != null) { gridCentral.Children.Clear(); }
                gridCentral.Children.Add(fondo);
                DialogoClienteMVVM dial = new DialogoClienteMVVM(tallerEnt);
                dial.ShowDialog();
            }
            else
            {
                await this.ShowMessageAsync("GESTIÓN CLIENTE", "No tiene permisos para añadir un cliente");
            }
        }

        private void listadoFacturas_Click(object sender, RoutedEventArgs e)
        {
            UCFactura uc = new UCFactura(tallerEnt,emp);
            if (gridCentral.Children != null) { gridCentral.Children.Clear(); }
            gridCentral.Children.Add(uc);
        }

        private void graficoRep_Click(object sender, RoutedEventArgs e)
        {
            UCGraficoReparaciones uc = new UCGraficoReparaciones();
            if (gridCentral.Children != null) { gridCentral.Children.Clear(); }
            gridCentral.Children.Add(uc);
        }

        private async void realizarFactura_Click(object sender, RoutedEventArgs e)
        {
            if (mvEmp.IntroducirCobro(emp))
            {
                Image fondo = new Image();
                BitmapImage im = new BitmapImage(new Uri("Recursos/Imagenes/TallerFondoMain.jpeg", UriKind.Relative));
                fondo.Source = im;
                fondo.Stretch = Stretch.Fill;
                if (gridCentral.Children != null) { gridCentral.Children.Clear(); }
                gridCentral.Children.Add(fondo);
                DialogoFacturaMVVM dial = new DialogoFacturaMVVM(tallerEnt);
                dial.ShowDialog();
            }
            else
            {
                await this.ShowMessageAsync("GESTIÓN FACTURA", "No tiene permisos para añadir una factura");
            }
        }
    }
}
