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
using Regata.Negocio;
using System.Data;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void VerRegatas_Click(object sender, RoutedEventArgs e)
        {
           // var resultados = ObtenerClasificacion();
           // this.vistaClasificacion.ItemsSource = resultados.AsDataView();
           //// this.vistaClasificacion.ItemsSource = resultados.;
           // this.vistaClasificacion.UpdateLayout();
        }
        private DataTable ObtenerClasificacion()
        {
            //Regata.Negocio.Regata r = new Regata.Negocio.Regata();
            //Clase c = new Clase();
            //c.Nombre = "Prueba";
            //r.Clases = new List<Clase>();
            //r.Clases.Add(c);
            //Embarcacion e1 = GenerarEmbarcacion();
            //Embarcacion e2 = GenerarEmbarcacion();
            //e2.NumeroVela = "ESP-11";
            //Embarcacion e3 = GenerarEmbarcacion();
            //e3.NumeroVela = "ESP-22";

            //Manga m = new Manga(c, DateTime.Now);
            //Resultado r1 = new Resultado();
            //r1.Embarcacion = e1;
            //r1.HoraLlegada = DateTime.Now.AddMinutes(35);
            //Resultado r2 = new Resultado();
            //r2.Embarcacion = e2;
            //r2.HoraLlegada = DateTime.Now.AddMinutes(45);
            //Resultado r3 = new Resultado();
            //r3.Embarcacion = e3;
            //r3.HoraLlegada = DateTime.Now.AddMinutes(50);
            //m.AñadirResultado(r1);
            //m.AñadirResultado(r2);
            //m.AñadirResultado(r3);
            //r.AñadirManga(m);


            //Manga m2 = new Manga(c, DateTime.Now);
            //Resultado r21 = new Resultado();
            //r21.Embarcacion = e1;
            //r21.HoraLlegada = DateTime.Now.AddMinutes(35);
         
            //Resultado r22 = new Resultado();
            //r22.Embarcacion = e2;
            //r22.HoraLlegada = DateTime.Now.AddMinutes(45);
           
            //Resultado r23 = new Resultado();
            //r23.Embarcacion = e3;
            //r23.HoraLlegada = DateTime.Now.AddMinutes(50);
           
            //m2.AñadirResultado(r22);
            //m2.AñadirResultado(r23);
            //m2.AñadirResultado(r21);
            //r.AñadirManga(m2);

            //DataTable t = new DataTable();
            //DataColumn columna = new DataColumn();
            //columna.ColumnName = "Embarcacion";
            //t.Columns.Add(columna);
            //Datos.DARegata rDA = new Datos.DARegata();
            //rDA.Guardar(r);
            //Regata.Negocio.Regata regatadeBD = rDA.ObtenerRegata();

            //var mangas = r.ObtenerMangas();
            //Dictionary<Clase, Puntuacion> puntuacion = new Dictionary<Clase, Puntuacion>();
            //puntuacion.Add(c,new PuntuacionBaja(3,null));
            //r.SistemaPuntuacion = puntuacion;
            //Clasificacion clasificacion = r.ObtenerClasificacionClase(c);
            //Dictionary<Embarcacion, Dictionary<Manga, double>> puntuacionesMangas = clasificacion.PuntuacionesMangas();
            // var genral = clasificacion.ObtenerClasificacionGeneral();

            //foreach (Embarcacion e in puntuacionesMangas.Keys)
            //{
            //    DataRow fila= t.Rows.Add();
            //    fila["Embarcacion"] = e.NumeroVela;
            //    int cont =1;
            //    foreach(Manga man in puntuacionesMangas[e].Keys)
            //    {
            //        string nombreColumna= string.Concat("Manga",cont);
            //        if (!t.Columns.Contains(nombreColumna))
            //        {
            //            columna = new DataColumn();
            //            columna.ColumnName = nombreColumna;
            //            t.Columns.Add(columna);
            //        }
            //        fila[nombreColumna]=puntuacionesMangas[e][man];
            //        cont++;
            //    }
            //    if (!t.Columns.Contains("Total"))
            //    {
            //        columna = new DataColumn();
            //        columna.ColumnName = "Total";
            //        t.Columns.Add(columna);
            //    }
            //    fila["Total"] = genral[e];
                
            //}

                       
            //.OrderBy(clas => clas.Value).ToDictionary();
            return null;
        }
        //private Embarcacion GenerarEmbarcacion()
        //{
        //    Embarcacion embarcacion = new Embarcacion();
        //    embarcacion.Clase = new Clase();
        //    embarcacion.NumeroVela = String.Concat("ESP-", new Random(34).Next(1, 100));
        //    return embarcacion;
        //}
    }
}
