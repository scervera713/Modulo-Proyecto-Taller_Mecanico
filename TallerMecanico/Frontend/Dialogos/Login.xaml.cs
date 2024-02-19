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
using TallerMecanico.Backend.Servicios;

namespace TallerMecanico.Frontend.Dialogos
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {

        private mydbEntities tallerEnt;
        private EmpleadoServicio empSer;

        public Login()
        {
            InitializeComponent();
            inicializar();
        }

        private void inicializar()
        {
            tallerEnt = new mydbEntities();
            empSer = new EmpleadoServicio(tallerEnt);
        }

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string usu = txtUsername.Text;
            string pswrd = txtPassword.Password;
            if (string.IsNullOrEmpty(usu) || string.IsNullOrEmpty(pswrd))
            {
                await this.ShowMessageAsync("LOGIN", "La contraseña o el usuario están vacios");
                txtUsername.Focus();
            } else if (empSer.login(usu, pswrd))
            {
                MainWindow ventanaPrincipal = new MainWindow(tallerEnt, empSer.empLogin);
                ventanaPrincipal.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("El usuario y/o la contraseña no coinciden", "LOGIN", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
