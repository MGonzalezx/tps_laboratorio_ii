using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public class ClienteDAO
    {
        #region Atributos
        static string cadenaConexion;
        static SqlCommand comando;
        static SqlConnection conexion;
        public static event EventHandler ErrorBaseDeDatos;
        #endregion


        #region Constructor

        /// <summary>
        /// Contructor de ClienteDAO en donde se van a inicializar los atributos
        /// </summary>
        static ClienteDAO()
        {
            cadenaConexion = @"Server=.;Database=TP_4;Trusted_Connection=True;";
            comando = new SqlCommand();
            conexion = new SqlConnection(cadenaConexion);
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;

        }
        #endregion


        #region Métodos

       /// <summary>
       /// Iserta en la base de datos los datos del cliente que se recibe por parámetro
       /// </summary>
       /// <param name="cliente"></param>
        public static void Guardar(Cliente cliente)
        {
            try
            {
                

                comando.Parameters.Clear();
                conexion.Open();

               
                comando.CommandText = $"INSERT INTO CLIENTES (NUMERO_AFILIADO, NOMBRE, APELLIDO, REQUERIMIENTO) VALUES (@numeroAfiliado, @nombre, @apellido, @requerimiento)";

                comando.Parameters.AddWithValue("@numeroAfiliado", cliente.NumeroAfiliado);
                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@requerimiento", cliente.Requerimiento);



                comando.ExecuteNonQuery();




            }
            catch (Exception ex)
            {
                ErrorBaseDeDatos(ex.Message, new EventArgs());
            }
            finally
            {
                conexion.Close();
            }


        }

        /// <summary>
        /// Lee los datos de la base de datos y lo devuelve en una lista de clientes
        /// </summary>
        /// <returns>Retorna una lista de clientes con los datos leidos de la base de datos</returns>
        public static List<Cliente> Leer()
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
               
                comando.Parameters.Clear();
                conexion.Open();

                
                comando.CommandText = $"SELECT NUMERO_AFILIADO as NumeroAfiliado, NOMBRE as Nombre, APELLIDO as Apellido, " +
                    $"REQUERIMIENTO as Requerimiento FROM CLIENTES";



                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    while (dataReader.Read())
                    {



                        clientes.Add(new Cliente(dataReader["Nombre"].ToString(), dataReader["Apellido"].ToString(), dataReader["Requerimiento"].ToString(),
                           Convert.ToInt32(dataReader["NumeroAfiliado"]) ));
                            
                            
                         
                    }
                }


            }
            catch (Exception ex)
            {
                ErrorBaseDeDatos(ex.Message, new EventArgs());
            }
            finally
            {
                conexion.Close();
            }

            return clientes;
        }

        /// <summary>
        /// Elimina a un cliente de la base de datos si el numero de afiliado de este 
        /// es el mismo que el numero de afiliado que recibe como parámetro.
        /// </summary>
        /// <param name="numeroAfiliado"></param>
        public static void Eliminar(int numeroAfiliado)
        {
            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = $"DELETE FROM CLIENTES WHERE NUMERO_AFILIADO = @numeroAfiliado";
                comando.Parameters.AddWithValue("@numeroAfiliado", numeroAfiliado);
                comando.ExecuteNonQuery();




            }
            catch (Exception ex)
            {
                 ErrorBaseDeDatos(ex.Message, new EventArgs());
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Modifica al cliente que recibimos como parámetro de la base de datos si el numero 
        /// de afiliado de este es el mismo que recibimos como parámetro.
        /// </summary>
        /// <param name="cliente">Cliente a modificar</param>
        /// <param name="numeroAfiliado"></param>
        public static void Modificar(Cliente cliente, int numeroAfiliado)
        {
            try
            {
                

                comando.Parameters.Clear();
                conexion.Open();

                comando.CommandText = $"UPDATE CLIENTES SET NUMERO_AFILIADO = @numeroAfiliado, NOMBRE = @nombre, APELLIDO = @apellido, REQUERIMIENTO = @requerimiento WHERE NUMERO_AFILIADO = {numeroAfiliado}";

                comando.Parameters.AddWithValue("@numeroAfiliado", cliente.NumeroAfiliado);
                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@requerimiento", cliente.Requerimiento);



                comando.ExecuteNonQuery();




            }
            catch (Exception ex)
            {
                 ErrorBaseDeDatos(ex.Message, new EventArgs());
            }
            finally
            {
                conexion.Close();
            }
        }
         #endregion

    }
}
