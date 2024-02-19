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
    /// Lógica de interacción para DialogoPiezaMVVM.xaml
    /// </summary>
    public partial class DialogoPiezaMVVM : MetroWindow
    {
        private mydbEntities tallerEnt;
        private MVPieza mvPieza;
        private bool editar;

        public DialogoPiezaMVVM(mydbEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvPieza = new MVPieza(tallerEnt);
            editar = false;
            DataContext = mvPieza;
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvPieza.OnErrorEvent));
            mvPieza.btnGuardar = BtnGuardar;
        }

        public DialogoPiezaMVVM(mydbEntities ent, pieza p)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvPieza = new MVPieza(tallerEnt,p);
            editar = true;
            DataContext = mvPieza;
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvPieza.OnErrorEvent));
            mvPieza.btnGuardar = BtnGuardar;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private async void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            bool operacion = true;

            if (mvPieza.IsValid(this))
            {
                if (editar)
                {
                    operacion = mvPieza.edita;
                }
                else
                {
                    operacion = mvPieza.guarda;
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
    }
}
