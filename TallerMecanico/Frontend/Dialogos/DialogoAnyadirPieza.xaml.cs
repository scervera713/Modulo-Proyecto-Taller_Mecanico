using MahApps.Metro.Controls;
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
    /// Lógica de interacción para DialogoAnyadirPieza.xaml
    /// </summary>
    public partial class DialogoAnyadirPieza : MetroWindow
    {
        private mydbEntities tallerEnt;
        private MVPieza mvPieza;
        private MVReparacion mvRep;
        private DataGrid dgPiezas;

        public DialogoAnyadirPieza(mydbEntities tallerEnt, reparacion rep, DataGrid dgPiezas)
        {
            this.tallerEnt = tallerEnt;
            this.dgPiezas = dgPiezas;
            mvRep = new MVReparacion(tallerEnt);
            mvRep.nuevaReparacion = rep;
            mvPieza = new MVPieza(tallerEnt);
            DataContext = mvPieza;
            InitializeComponent();
        }

        private void dgListaPiezas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (mvPieza.PiezaSeleccionada.cantidad > 0)
            {
                mvPieza.PiezaSeleccionada.cantidad = mvPieza.PiezaSeleccionada.cantidad - 1;
                mvRep.nuevaReparacion.pieza.Add(mvPieza.PiezaSeleccionada);
                mvPieza.ListaPiezas.Refresh();
                dgPiezas.Items.Refresh();
            }
            else
            {
                MessageBox.Show("No queda más stock de la pieza seleccionada");
            }
        }
    }
}
