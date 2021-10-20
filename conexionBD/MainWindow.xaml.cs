using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace conexionBD
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnectionStringBuilder conexion;
        private List<Jugador> listaPuntajes = new List<Jugador>(); //lista para guardar la consulta
        Data d;
        public MainWindow()
        {
            InitializeComponent();
            Conexion c = new Conexion("LAPTOP-PC8SL5H1", "registroPuntaje");
            SqlConnectionStringBuilder conexionActual = c.inicializarConexion();
            labelCadena.Content = conexionActual.ConnectionString;
            d = new Data(conexionActual.ConnectionString);
            foreach(Jugador j in d.GetPuntajesv2())
            {
                string registro = String.Format("Id: {0} // Rut: {1} // Nombre: {2} // Puntaje: {3}\n", j.Id, j.Rut, j.Nombre, j.Puntaje);
                labelBD.Content += registro;
            }
            
            /*
            //con esta clase generamos en base a propiedades, la cadena de conexión

            //nombre del servidor:LAPTOP-PC8SL5H1
            conexion = new SqlConnectionStringBuilder();
            conexion.DataSource = "LAPTOP-PC8SL5H1";
            conexion.InitialCatalog = "registroPuntaje";
            conexion.IntegratedSecurity = true;
            labelCadena.Content = conexion.ConnectionString;

            
            Jugador j;

            string consulta = "SELECT * FROM jugador;";

            SqlConnection sql = new SqlConnection(conexion.ConnectionString);
            sql.Open();
            SqlCommand comando = new SqlCommand(consulta, sql);
            SqlDataReader response = comando.ExecuteReader();//acá se ejecuta definitivamente la consulta

            while (response.Read())
            {
                int idActual = response.GetInt32(0);
                string rutActual = response.GetString(1);
                string nombreActual = response.GetString(2);
                int puntajeActual = response.GetInt32(3);
                j = new Jugador(idActual, rutActual, nombreActual, puntajeActual);
                listaPuntajes.Add(j);
            }
            sql.Close();
            /*
            var respuesta = "";
            response.Read();
            respuesta += response.GetInt32(0).ToString();
            respuesta += " - ";
            respuesta += response.GetString(1);
            respuesta += " - ";
            respuesta += response.GetString(2);
            respuesta += " - ";
            respuesta += response.GetInt32(3);
            respuesta += "\n";
            response.Read();
            respuesta += response.GetInt32(0).ToString();
            respuesta += " - ";
            respuesta += response.GetString(1);
            respuesta += " - ";
            respuesta += response.GetString(2);
            respuesta += " - ";
            respuesta += response.GetInt32(3);
            labelBD.Content = respuesta;
            */
        }



        private void buttonPruebas_Click(object sender, RoutedEventArgs e)
        {
            /*
            d.DeleteJugador(1);

            /*
            List<Jugador> miLista = d.GetPuntajesv2();
            Jugador miJugador = miLista[1];
            miJugador.Rut = "2323";
            miJugador.Nombre = "John Doe";
            miJugador.Puntaje = 1000;
            d.UpdateJugadorById(miJugador);


            /*
            Jugador j = new Jugador("Ben", "123456789", 10);
            d.InsertarJugador(j);
            /*try
            {
                Jugador miJugador = d.GetJugadorById(5);
                Console.WriteLine(miJugador.Id);
                Console.WriteLine(miJugador.Nombre);
                Console.WriteLine(miJugador.Rut);
                Console.WriteLine(miJugador.Puntaje);
            }catch(NullReferenceException ex)
            {
                Console.WriteLine("No existe el registro!");
                Console.WriteLine(ex.Message);
            }

            /*
            foreach (Jugador jugador in d.GetPuntajes())
            {
                Console.WriteLine("***");
                Console.WriteLine(jugador.Id);
                Console.WriteLine(jugador.Nombre);
                Console.WriteLine(jugador.Rut);
                Console.WriteLine(jugador.Puntaje);
                Console.WriteLine("***");
            }
            /*
            Console.WriteLine("**********************");
            foreach(Jugador jugador in listaPuntajes)
            {
                Console.WriteLine(jugador.Id);
                Console.WriteLine(jugador.Nombre);
                Console.WriteLine(jugador.Rut);
                Console.WriteLine(jugador.Puntaje);
                Console.WriteLine("*********************");
            }
            */
        }
    }
}
