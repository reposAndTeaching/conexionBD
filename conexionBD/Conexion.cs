using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexionBD
{
    class Conexion
    {
        private string servidor;
        private string bd;
        private string usuario;
        private string password;

        private SqlConnectionStringBuilder conexion; //using System.Data.SqlClient;

        public Conexion(string servidor, string bd)
        {
            this.servidor = servidor;
            this.bd = bd;
        }

        public Conexion(string servidor, string bd, string usuario, string password)
        {
            this.servidor = servidor;
            this.bd = bd;
            this.usuario = usuario;
            this.password = password;
        }

        public SqlConnectionStringBuilder inicializarConexion()
        {
            conexion = new SqlConnectionStringBuilder();
            conexion.DataSource = servidor;
            conexion.InitialCatalog = bd;
            if (usuario == null)
            {
                conexion.IntegratedSecurity = true;
            }else if (usuario != null && password != null)
            {
                conexion.UserID = usuario;
                conexion.Password = password;
            }
            return conexion;
        }

        public string Servidor { get => servidor; set => servidor = value; }
        public string Bd { get => bd; set => bd = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Password { get => password; set => password = value; }
    }
}
