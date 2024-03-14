using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GestionUsuarios
{
    internal class UsuarioDao
    {
        public List<UsuarioDto> Obtener()
        {
            DBConnection conn = new DBConnection();
            List<UsuarioDto> usuarios = new List<UsuarioDto>();
            string query = "SELECT * FROM usuarios";
            using (SqlConnection connection = conn.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        UsuarioDto usuario = new UsuarioDto();
                        usuario.Id = reader.GetInt32(0);
                        usuario.Nombre = reader.GetString(1);
                        usuario.Apellido = reader.GetString(2);
                        usuario.Email = reader.GetString(3);
                        usuario.Pais = reader.GetString(4);
                        usuarios.Add(usuario);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
            return usuarios;
        }

        public UsuarioDto Obtener(int? Id)
        {
            DBConnection conn = new DBConnection();
            string query = "SELECT * FROM usuarios " +
                           "WHERE usr_id=@id";
            using (SqlConnection connection = conn.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", Id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                    UsuarioDto usuario = new UsuarioDto();
                    usuario.Id = reader.GetInt32(0);
                    usuario.Nombre = reader.GetString(1);
                    usuario.Apellido = reader.GetString(2);
                    usuario.Email = reader.GetString(3);
                    usuario.Pais = reader.GetString(4);

                    reader.Close();
                    connection.Close();

                     return usuario;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
        }

        public void Agregar(string Nombre, string Apellido, string Email, string Pais)
        {
            DBConnection conn = new DBConnection();
            string query = "INSERT INTO usuarios(" +
                "usr_nombre,usr_apellido,usr_email,usr_pais) " +
                "VALUES (@nombre,@apellido,@email,@pais)";

            using (SqlConnection connection = conn.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@apellido", Apellido);
                command.Parameters.AddWithValue("@email", Email);
                command.Parameters.AddWithValue("@pais", Pais);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
        }

        public void Actualizar(string Nombre, string Apellido, string Email, string Pais, int Id)
        {

            DBConnection conn = new DBConnection();
            string query = "UPDATE usuarios SET usr_nombre=@nombre, usr_apellido=@apellido," +
                           "usr_email=@email,usr_pais=@pais " +
                           "WHERE usr_id=@id";

            using (SqlConnection connection = conn.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@apellido", Apellido);
                command.Parameters.AddWithValue("@email", Email);
                command.Parameters.AddWithValue("@pais", Pais);
                command.Parameters.AddWithValue("@id", Id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
        }

        public void Eliminar(int  Id)
        {
            DBConnection conn = new DBConnection();
            string query = "DELETE FROM usuarios WHERE usr_id=@id";

            using (SqlConnection connection = conn.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                { 
                    throw new Exception("Error: " + ex.Message); 
                }
            }
        }
    }
}