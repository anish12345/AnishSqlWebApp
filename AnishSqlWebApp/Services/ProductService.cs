using AnishSqlWebApp.Models;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace AnishSqlWebApp.Services
{
    public class ProductService : IProductService
    {
        //private static string db_source = "anishwebappserver.database.windows.net";
        //private static string db_user = "anish";
        //private static string db_password = "Indu@123";
        //private static string db_database = "AnishWebAppDB";

        private readonly IConfiguration _configuration;

        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            //var _builder = new SqlConnectionStringBuilder();
            //_builder.DataSource = db_source;
            //_builder.UserID = db_user;
            //_builder.Password = db_password;
            //_builder.InitialCatalog = db_database;


            // return new SqlConnection(_builder.ConnectionString);

            // return new SqlConnection(_configuration.GetConnectionString("SqlConnection"));

            return new SqlConnection(_configuration["SqlConnection"]);
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<Product> _productList = new List<Product>();
            string statment = "SELECT ProductID, ProductName, Quantity from Products";
            conn.Open();
            SqlCommand cmd = new SqlCommand(statment, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)

                    };
                    _productList.Add(product);
                }
            }
            conn.Close();
            return _productList;
        }
    }
}
