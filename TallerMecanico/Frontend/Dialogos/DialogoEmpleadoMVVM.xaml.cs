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
    /// Lógica de interacción para DialogoEmpleadoMVVM.xaml
    /// </summary>
    public partial class DialogoEmpleadoMVVM : MetroWindow
    {
        private mydbEntities tallerEnt;
        private MVEmpleado mvEmp;
        private bool editar;

        public DialogoEmpleadoMVVM(mydbEntities tallerEnt, empleado empLogin)
        {
            InitializeComponent();
            this.tallerEnt = tallerEnt;
            mvEmp = new MVEmpleado(tallerEnt);
            DataContext = mvEmp;
            editar = false;
            if (empLogin != null && empLogin.rol != null && (empLogin.rol.idRol == 2 || empLogin.rol.idRol == 3)) CBRol.IsEnabled = false;
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvEmp.OnErrorEvent));
            mvEmp.btnGuardar = BtnGuardar;
        }

        public DialogoEmpleadoMVVM(mydbEntities tallerEnt, empleado empSel, empleado empLogin)
        {
            InitializeComponent();
            this.tallerEnt = tallerEnt;
            mvEmp = new MVEmpleado(tallerEnt,empSel);
            DataContext = mvEmp;
            editar = true;
            if (empLogin != null && empLogin.rol != null && (empLogin.rol.idRol == 2 || empLogin.rol.idRol == 3)) CBRol.IsEnabled = false;
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvEmp.OnErrorEvent));
            mvEmp.btnGuardar = BtnGuardar;
        }

        private async void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            bool operacion = true;
            bool usuUnico = true;

            if (mvEmp.IsValid(this) && !String.IsNullOrEmpty(TxtConstrasenya.Text))
            {
                if (!editar)
                {
                    usuUnico = mvEmp.userValido;
                }

                if (usuUnico)
                {
                    if (editar)
                    {
                        operacion = mvEmp.edita;
                    }
                    else
                    {
                        operacion = mvEmp.guarda;
                    }

                    if (operacion)
                    {
                        await this.ShowMessageAsync("GESTIÓN EMPLEADO", "TODO CORRECTO. El empleado se ha guardado correctamente en la BD");
                        DialogResult = true;
                    }
                    else
                    {
                        await this.ShowMessageAsync("GESTIÓN EMPLEADO", "ERROR!!. PROBLEMAS PARA GUARDAR EN LA BD");
                    }
                }
                else
                {
                    await this.ShowMessageAsync("GESTIÓN EMPLEADO", "Nombre de usuario no válido\n +Introduzca uno nuevo");
                    TxtUsuario.Focus();
                }
            }
            else
            {
                await this.ShowMessageAsync("GESTIÓN EMPLEADO", "ERROR!!. HAY CAMPOS OBLIGATORIOS SIN RELLENAR");
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
