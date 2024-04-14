using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GestionUsuarios
{
    internal class PaisDao
    {
        public List<PaisDto> Obtener()
        {
            DBConnection conn = new DBConnection();
            List<PaisDto> paises = new List<PaisDto>();
            string query = "SELECT * FROM paises";
            using (SqlConnection connection = conn.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        PaisDto pais = new PaisDto();
                        pais.Id = reader.GetInt32(0);
                        pais.Nombre = reader.GetString(1);
                        paises.Add(pais);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
            return paises;
        }
    }
}