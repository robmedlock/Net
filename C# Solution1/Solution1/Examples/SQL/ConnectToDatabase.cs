using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.SQL
{
    public class ConnectToDatabase
    {
        public static void Main()
        {
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog = ecommerce; User ID = sa; Password = carpond";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "insert into accounts (id, name) values ('acc1', 'John Smith'); ";
            int rowsInserted = cmd.ExecuteNonQuery();
            connection.Close();
        }
    }

}
