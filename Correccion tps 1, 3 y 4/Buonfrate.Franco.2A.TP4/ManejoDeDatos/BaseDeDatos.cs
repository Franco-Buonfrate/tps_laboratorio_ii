using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ManejoDeDatos
{
    public static class BaseDeDatos
    {
        static string connectionString;
        static SqlConnection connection;
        static SqlCommand command;

        /// <summary>
        /// Constructor estatico
        /// </summary>
        static BaseDeDatos()
        {
            connectionString = @"Data Source=.;Initial Catalog=TP_04;Integrated Security=True";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }

        /// <summary>
        /// lee la base de datos
        /// </summary>
        /// <returns>retorna una lista de clientes almacenados en la base de datos</returns>
        public static async Task<List<Cliente>> Leer()
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                clientes = await Task.Run(() =>
                {
                try
                {
                    command.Parameters.Clear();
                        connection.Open();
                        command.CommandText = $"SELECT * FROM Datos_Clientes";
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Cliente cliente = new Cliente(dataReader["nombre"].ToString(),
                                                              dataReader["apellido"].ToString(),
                                                              long.Parse(dataReader["dni"].ToString()),
                                                              dataReader["celular"].ToString(),
                                                              dataReader["mail"].ToString(),
                                                              int.Parse(dataReader["ID"].ToString()));
                                clientes.Add(cliente);
                            }
                        }
                        return clientes;
                }
                catch (Exception)
                {
                    return null;
                }
                });
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return clientes;
        }
        /// <summary>
        /// busca un elemto en la base de datos con el id pasado por parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns>una nueva instacia de cliente con los datos de la bdd</returns>
        public static Cliente LeerId(int id)
        {
            Cliente cliente = null;

            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM Datos_Clientes where ID = @ID";
                command.Parameters.AddWithValue("@ID", id);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        cliente = new Cliente(dataReader["nombre"].ToString(),
                                                      dataReader["apellido"].ToString(),
                                                      long.Parse(dataReader["dni"].ToString()),
                                                      dataReader["celular"].ToString(),
                                                      dataReader["mail"].ToString(),
                                                      int.Parse(dataReader["ID"].ToString()));
                    }
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return cliente;
        }

        /// <summary>
        /// carga los datos de cliente pasasdo por parametro a la base de datos
        /// </summary>
        /// <param name="cliente"></param>
        public static void Guardar(Cliente cliente)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"Insert into Datos_Clientes (nombre,apellido,dni,celular,mail) values (@Nombre,@Apellido,@Dni,@Celular,@Mail)";
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                command.Parameters.AddWithValue("@Dni", cliente.Dni);
                command.Parameters.AddWithValue("@Celular", cliente.Celular);
                command.Parameters.AddWithValue("@Mail", cliente.Mail);

                int rows = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// sobreescribe en la base de datos los datos del cliente con el mismo id que el pasado por paramtro
        /// </summary>
        /// <param name="cliente"></param>
        public static void Modificar(Cliente cliente)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"Update Datos_Clientes Set nombre = @Nombre, apellido =@Apellido, dni = @Dni , celular = @Celular, mail = @Mail where ID = @id ";
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                command.Parameters.AddWithValue("@Dni", cliente.Dni);
                command.Parameters.AddWithValue("@Celular", cliente.Celular);
                command.Parameters.AddWithValue("@Mail", cliente.Mail);
                command.Parameters.AddWithValue("@id", cliente.IdCliente);
                int rows = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// elimina de la bdd el elemento con el id 
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"delete from Datos_Clientes where ID = @ID";
                command.Parameters.AddWithValue("@ID", id);
                int rows = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }



    }
}
