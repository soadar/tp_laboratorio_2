using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public class DAO
    {
        string connectionString = "Server = DESKTOP-QVMCMIQ;Database=Cerveceria;Trusted_Connection=True";
        private SqlConnection sqlConnection;
        public DAO()
        {
            this.sqlConnection = new SqlConnection(connectionString);
        }
        /// <summary>
        /// realiza un insert en la bd
        /// </summary>
        /// <param name="producto"></param>
        public void InsertarProducto(Producto producto)
        {
            try
            {
                if (producto is Cerveza)
                {
                    Cerveza cerveza = (Cerveza)producto;
                    string command = "INSERT INTO Cervezas(Estilo, Alcohol, Precio, Stock) " + "VALUES(@Estilo, @Alcohol, @Precio, @Stock)";
                    SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Estilo", cerveza.Estilo);
                    sqlCommand.Parameters.AddWithValue("Alcohol", cerveza.Alochol);
                    sqlCommand.Parameters.AddWithValue("Precio", cerveza.Precio);
                    sqlCommand.Parameters.AddWithValue("Stock", cerveza.Stock);
                    this.sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                else if (producto is Gaseosa)
                {
                    Gaseosa gaseosa = (Gaseosa)producto;
                    string command = "INSERT INTO Cervezas(Estilo, Precio, Stock) " + "VALUES(@Estilo, @Precio, @Stock)";
                    SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Estilo", gaseosa.Marca);
                    sqlCommand.Parameters.AddWithValue("Precio", gaseosa.Precio);
                    sqlCommand.Parameters.AddWithValue("Stock", gaseosa.Stock);
                    this.sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new ExcepcionDAO("Ocurrio un error al agregar datos a la BD", ex);
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }
            }
        }
        /// <summary>
        /// borra un elemento de la bd
        /// </summary>
        /// <param name="inventario"></param>
        /// <returns></returns>
        public bool DeleteProducto(int inventario)
        {
            int cambios;
            try
            {
                string command = "delete from Cervezas where Inventario = @inventario";
                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("inventario", inventario);
                this.sqlConnection.Open();
                cambios = sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (sqlConnection != null &&
                    sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }
            }
            if (cambios == 0)
                return false;
            else
                return true;
        }
        /// <summary>
        /// trae todos los elementos de la bd
        /// </summary>
        /// <param name="inv"></param>
        /// <returns></returns>
        public List<Cerveza> ListarProductos()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
                {
                    this.sqlConnection.Open();
                    string command = "select * from Cervezas order by Stock";
                    SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    List<Cerveza> productos = new List<Cerveza>();
                    while (reader.Read())
                    {
                        int inventario = (int)reader["Inventario"];
                        string estilo = (string)reader["Estilo"];
                        double alcohol = 0;
                        if (reader["Alcohol"] != DBNull.Value)
                            alcohol = (double)Convert.ToDouble(reader["Alcohol"]);
                        double precio = (double)Convert.ToDouble(reader["Precio"]);
                        int stock = (int)reader["Stock"];
                        Cerveza producto = new Cerveza(inventario, estilo, alcohol, precio, stock);
                        productos.Add(producto);
                    }
                    return productos;
                }
            }
            catch(InvalidCastException ex)
            {
                throw new ExcepcionDAO("Ocurrio un error al leer datos de la BD", ex);
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }
            }
        }
    }
}