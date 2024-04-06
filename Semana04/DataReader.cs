using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Semana04
{
    public class DataReader
    {
        private string connectionString;

        public DataReader(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Producto> ListarProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("USP_ListarProductos", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto();
                        producto.IdProducto = Convert.ToInt32(reader["idproducto"]);
                        producto.NombreProducto = Convert.ToString(reader["nombreProducto"]);
                        producto.CantidadPorUnidad = Convert.ToString(reader["cantidadPorUnidad"]);
                        producto.PrecioUnidad = Convert.ToDecimal(reader["precioUnidad"]);
                        productos.Add(producto);
                    }
                }
            }

            return productos;
        }

        public List<Categoria> ListarCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("USP_listaCategorias", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Categoria categoria = new Categoria();
                        categoria.IdCategoria = Convert.ToInt32(reader["idcategoria"]);
                        categoria.NombreCategoria = Convert.ToString(reader["nombrecategoria"]);
                        categoria.Descripcion = Convert.ToString(reader["descripcion"]);
                        categoria.Activo = Convert.ToBoolean(reader["Activo"]);
                        categorias.Add(categoria);
                    }
                }
            }

            return categorias;
        }
    }
}
