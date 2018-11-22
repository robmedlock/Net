using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Examples
{
    public class ConnectToDatabase
    {
        public static void UnmanagedResources()
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



        public static void FinallyBlock()
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

        public static void UsingBlock()
        {
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=ecommerce;User ID=sa;Password=carpond";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "insert into account (id, name) values('acc1', 'John Smith'); ";
                    try
                    {
                        int rowsInserted = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        public static void Transactions()
        {
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=ecommerce;User ID=sa;Password=carpond";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    try
                    {
                        //valid expression
                        cmd.CommandText = "insert into accounts (id, name) values('acc1', 'John Smith'); ";
                        int rowsInserted = cmd.ExecuteNonQuery();
                        //invalid expression
                        cmd.CommandText = "update account set name = 'Jane Smith' where id = 'acc1'; ";
                        int rowsUpdated = cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (SqlException e)
                    {
                        transaction.Rollback();
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
