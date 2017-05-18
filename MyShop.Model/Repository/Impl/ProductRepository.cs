using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MyShop.Model.Entities;
using System.Configuration;
using System.Data;

namespace MyShop.Model.Repository.Impl
{
    public class ProductRepository : IProductRepository
    {

        public List<MyShop.Model.Entities.Product> FindAll()
        {
            List<Product> lista = new List<Product>();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "SELECT id_Product,Title,Description , Url , Price ,Stars FROM Products";

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int idproduct = Convert.ToInt32(reader["id_Product"]);
                        string title = Convert.ToString(reader["Title"]);
                        string description = Convert.ToString(reader["Description"]);
                        string url = Convert.ToString(reader["Url"]);
                        decimal price = Convert.ToDecimal(reader["Price"]);
                        int stars = Convert.ToInt32(reader["Stars"]);

                        Product producto = new Product()
                        {
                            IdProduct = idproduct,
                            Title = title,
                            Description = description,
                            Url = url,
                            Price = price,
                            Stars = stars
                        };

                        lista.Add(producto);

                    }

                }
            }
            catch (Exception)
            {
            }

            return lista;
        }

        public DataTable GetAll()
        {
            DataTable dtData = new DataTable();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "SELECT id_Product,Title ,Description ,Url ,Price ,Stars FROM Products";

                    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(cmd);
                    objSqlDataAdapter.Fill(dtData);
                }
            }
            catch (Exception)
            {
            }

            return dtData;
        }

        public List<MyShop.Model.Entities.Product> FindByName(string sProductName)
        {
            List<Product> lista = new List<Product>();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = string.Format("SELECT id_Product, Title, Description ,Url ,Price ,Stars FROM Products WHERE Title LIKE '%{0}%'", sProductName);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string title = Convert.ToString(reader["Title"]);
                        string description = Convert.ToString(reader["Description"]);
                        string url = Convert.ToString(reader["Url"]);
                        decimal price = Convert.ToDecimal(reader["Price"]);
                        int stars = Convert.ToInt32(reader["Stars"]);

                        Product producto = new Product()
                        {
                            Title = title,
                            Description = description,
                            Url = url,
                            Price = price,
                            Stars = stars
                        };

                        lista.Add(producto);

                    }

                }
            }
            catch (Exception)
            {
            }

            return lista;
        }

        public void Add(Product objProduct)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = string.Format("INSERT INTO Products (Title, Description ,Url ,Price ,Stars) VALUES ('{0}','{1}','{2}',{3},{4})", objProduct.Title, objProduct.Description, objProduct.Url, objProduct.Price, objProduct.Stars);

                    SqlDataReader reader = cmd.ExecuteReader();
                }
            }
            catch (Exception)
            {
            }
        }

        public void Update(Product objProduct)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = string.Format("INSERT INTO Products (Title, Description ,Url ,Price ,Stars) VALUES ('{0}','{1}','{2}',{3},{4})", objProduct.Title, objProduct.Description, objProduct.Url, objProduct.Price, objProduct.Stars);

                    SqlDataReader reader = cmd.ExecuteReader();
                }
            }
            catch (Exception)
            {
            }
        }

        public void Remove(Product objProduct)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = string.Format("DELETE FROM Products WHERE id_Product = {0}", objProduct.IdProduct);

                    SqlDataReader reader = cmd.ExecuteReader();
                }
            }
            catch (Exception)
            {
            }
        }

    }
}
