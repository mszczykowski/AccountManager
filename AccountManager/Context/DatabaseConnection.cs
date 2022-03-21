using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace AccountManager.Context
{
    internal class DatabaseConnection
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int ExecuteDML(string queryString)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString + "SELECT SCOPE_IDENTITY();", connection);

                try
                {
                    connection.Open();

                    object returnObj = command.ExecuteScalar();

                    if (returnObj != null)
                    {
                        int.TryParse(returnObj.ToString(), out id);
                    }

                    //id = command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return id;
        }

        public List<object[]> ExecuteDQL(string queryString)
        {
            List<object[]> values = new List<object[]>();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        Object[] row = new Object[reader.FieldCount];
                        
                        reader.GetValues(row);

                        values.Add(row);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return values;
        }
    }
}
