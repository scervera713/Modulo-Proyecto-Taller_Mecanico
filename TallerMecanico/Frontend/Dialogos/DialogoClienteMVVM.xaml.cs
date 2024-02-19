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
    /// Lógica de interacción para DialogoClienteMVVM.xaml
    /// </summary>
    public partial class DialogoClienteMVVM : MetroWindow
    {
        private mydbEntities tallerEnt;
        private MVCliente mvCli;
        private bool editar;

        public DialogoClienteMVVM(mydbEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvCli = new MVCliente(tallerEnt);
            DataContext = mvCli;
            editar = false;
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvCli.OnErrorEvent));
            mvCli.btnGuardar = BtnGuardar;
        }

        public DialogoClienteMVVM(mydbEntities ent, cliente cli)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvCli = new MVCliente(tallerEnt,cli);
            DataContext = mvCli;
            editar = true;
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvCli.OnErrorEvent));
            mvCli.btnGuardar = BtnGuardar;
        }

        private async void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            bool operacion = true;

            if (mvCli.IsValid(this))
            {
                if (editar)
                {
                    operacion = mvCli.edita;
                }
                else
                {
                    operacion = mvCli.guarda;
                }

                if (operacion)
                {
                    await this.ShowMessageAsync("GESTIÓN CLIENTE", "TODO CORRECTO. El cliente se ha guardado correctamente en la BD");
                    DialogResult = true;
                }
                else
                {
                    await this.ShowMessageAsync("GESTIÓN CLIENTE", "ERROR!!. PROBLEMAS PARA GUARDAR EN LA BD");
                }
            }
            else
            {
                await this.ShowMessageAsync("GESTIÓN CLIENTE", "ERROR!!. HAY CAMPOS OBLIGATORIOS SIN RELLENAR");
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
