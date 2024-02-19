using di.proyecto.clase.mahapps.correccion.Servicios;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace TallerMecanico.Frontend.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UCGraficoReparaciones.xaml
    /// </summary>
    public partial class UCGraficoReparaciones : UserControl
    {
        private ServicioSQL ser;
        public UCGraficoReparaciones()
        {
            InitializeComponent();
            ser = new ServicioSQL();
            loadChart();
        }

        private void loadChart()
        {
            DataTable dt = ser.getDatos("select monthname(fechaResolucion) as mes, count(*) as cantidad from mydb.reparacion group by month(fechaResolucion);");
            ChartValues<double> valores = new ChartValues<double>();
            List<String> etiquetas = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                valores.Add(double.Parse(dr[1].ToString()));
                if (dr[0].ToString().Equals(""))
                {
                    etiquetas.Add("Sin terminar");
                }
                else
                {
                    etiquetas.Add(dr[0].ToString());
                }
            }
                lvReparaciones.Series = new SeriesCollection
                {
                new ColumnSeries
                    {
                        Title = "Número de Reparaciones:", 
                        Values =  valores, 
                        DataLabels = true, 
                        Fill = Brushes.DeepSkyBlue,
                    }
                };

                lvReparaciones.AxisX.Add(new Axis
                {
                    Labels = etiquetas, 
                    Unit = 1 
                });
            

        }
    }
}
