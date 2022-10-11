using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace CRUDWEBAPI.Model
{
    public class ProductRepository
    {
        private string connectionString;

        public ProductRepository()
        {
            connectionString = @"server=AMIT\SQLEXPRESS;database=StudentDB;Integrated Security=True;";
        }

        public IDbConnection Connection
        {
            get 
            {
                return new SqlConnection(connectionString); ; }
        }

        public void Add(Product prod)
        {
            using (IDbConnection dbConnection =Connection)
            {
                String sQuery = @"INSERT INTO Products (Name,Quantity,Price) VALUES(@Name,@Quantity,@Price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, prod);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                String sQuery = @"select * from Products";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery);
            }
        }

        public Product GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                String sQuery = @"select * from Products where ProductId=@Id";
                dbConnection.Open();
                var data = dbConnection.Query<Product>(sQuery, new { Id = id }).FirstOrDefault();
                return data;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    String sQuery = @"Delete from Products where ProductId=@Id";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, new { Id = id });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Update(Product prod)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    String sQuery = @"UPDATE Products SET Name=@Name,Quantity=@Quantity,Price=@Price where ProductId=@ProductId";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, prod);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
