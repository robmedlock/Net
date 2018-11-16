using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Examples
{
    public class ConnectToDatabase
    {
        public static void Main()
        {
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=ecommerce;User ID=sa;Password=carpond";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from INFORMATION_SCHEMA.TABLES";
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Console.WriteLine(dataReader["TABLE_NAME"]);
            }
            connection.Close();
        }



        public static void Main2()
        {
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=ecommerce;User ID=sa;Password=carpond";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from INFORMATION_SCHEMA.TABLES";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader["TABLE_NAME"]);
                }
            }
            finally
            {
                connection.Close();
            }
            
        }
    }
}
