using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUsuarios
{
    internal class DBConnection
    {
        private string ConnectionString = "Data Source= localhost;" +
            "Initial Catalog=GestionUsuarios;" +
            "User=sa;Password=Admin_250817";

        public SqlConnection ObtenerConexion()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            return connection;
        }
    }
}