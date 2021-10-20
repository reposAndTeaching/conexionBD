using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexionBD
{
    class Data
    {
        private string cadenaConexion;
        private SqlConnection sql;
        private SqlCommand comando;
        private SqlDataReader response;

        public Data(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public List<Jugador> GetPuntajes()
        {
            List<Jugador> lista = new List<Jugador>();
            Jugador j;
            string consulta = "SELECT * FROM jugador;";
            sql = new SqlConnection(cadenaConexion);
            sql.Open();
            SqlCommand comando = new SqlCommand(consulta, sql);
            SqlDataReader response = comando.ExecuteReader();
            while (response.Read())
            {
                int idActual = response.GetInt32(0);
                string rutActual = response.GetString(1);
                string nombreActual = response.GetString(2);
                int puntajeActual = response.GetInt32(3);
                j = new Jugador(idActual, rutActual, nombreActual, puntajeActual);
                lista.Add(j);
            }
            sql.Close();
            return lista;
        }

        public List<Jugador> GetPuntajesv2()//usando estructura recomendada por la documentación
        {
            List<Jugador> lista = new List<Jugador>();
            Jugador j;
            string consulta = "SELECT * FROM jugador;";
            using(sql = new SqlConnection(cadenaConexion))
            {
                sql.Open();
                using(SqlCommand comando = new SqlCommand(consulta, sql))
                {
                    SqlDataReader response = comando.ExecuteReader();//Ejecutamos la consulta
                    while (response.Read())
                    {
                        int idActual = response.GetInt32(0);
                        string rutActual = response.GetString(1);
                        string nombreActual = response.GetString(2);
                        int puntajeActual = response.GetInt32(3);
                        j = new Jugador(idActual, rutActual, nombreActual, puntajeActual);
                        lista.Add(j);
                    }
                }

            }
            return lista;
        }

        public Jugador GetJugadorById(int id)
        {
            Jugador j = null;
            string consulta = "select * from jugador where id = "+id+";";
            using(sql = new SqlConnection(cadenaConexion))
            {
                sql.Open();
                using(SqlCommand comando = new SqlCommand(consulta, sql))
                {
                    SqlDataReader response = comando.ExecuteReader();//Ejecutamos la consulta
                    if (response.Read())
                    {
                        int idActual = response.GetInt32(0);
                        string rutActual = response.GetString(1);
                        string nombreActual = response.GetString(2);
                        int puntajeActual = response.GetInt32(3);
                        j = new Jugador(idActual, rutActual, nombreActual, puntajeActual);
                    }
                    else
                    {
                        throw new NullReferenceException();
                    }
                }
            }

            return j;
        }

        public void InsertarJugador(Jugador jugador)
        {
            string consulta = "insert into jugador values('"+jugador.Rut+"', '"+jugador.Nombre+"', "+jugador.Puntaje+");";
            //consulta = String.Format("insert into jugador values('{0}', '{1}', {2});", jugador.Rut, jugador.Nombre, jugador.Puntaje);
            using(sql = new SqlConnection(cadenaConexion))
            {
                sql.Open();
                using(SqlCommand comando = new SqlCommand(consulta, sql))
                {
                    int response = comando.ExecuteNonQuery();//Ejecutamos la consulta
                    if (response == 1)
                    {
                        Console.WriteLine("El Jugador {0} fue insertado exitosamente!", jugador.Nombre);
                    }else if(response == 0)
                    {
                        Console.WriteLine("Existió un error al tratar de ejecutar la consulta.");
                    }
                }
            }//sql.Close();
        }

        public void UpdateJugadorById(Jugador jugador)
        {
            string consulta = "UPDATE jugador SET rut = '"+jugador.Rut+"', nombre = '"+jugador.Nombre+"', puntaje = "+jugador.Puntaje+" WHERE id = "+jugador.Id+";";
            using (sql = new SqlConnection(cadenaConexion))
            {
                sql.Open();
                using (SqlCommand comando = new SqlCommand(consulta, sql))
                {
                    int response = comando.ExecuteNonQuery();//Ejecutamos la consulta
                    if (response == 1)
                    {
                        Console.WriteLine("El Jugador {0} fue actualizado exitosamente!", jugador.Nombre);
                    }
                    else if (response == 0)
                    {
                        Console.WriteLine("Existió un error al tratar de ejecutar la consulta.");
                    }
                }
            }//sql.Close();
        }

        public void DeleteJugador(int id)
        {
            string consulta = "DELETE FROM jugador WHERE id = "+id+";";
            using (sql = new SqlConnection(cadenaConexion))
            {
                sql.Open();
                using (SqlCommand comando = new SqlCommand(consulta, sql))
                {
                    int response = comando.ExecuteNonQuery();//Ejecutamos la consulta
                    if (response == 1)
                    {
                        Console.WriteLine("El Jugador fue borrado exitosamente!");
                    }
                    else if (response == 0)
                    {
                        Console.WriteLine("Existió un error al tratar de ejecutar la consulta.");
                    }
                }
            }//sql.Close();
        }
    }
}
