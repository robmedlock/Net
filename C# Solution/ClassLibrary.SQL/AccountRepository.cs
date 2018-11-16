using System;
using System.Data.SqlClient;
using System.Diagnostics;
using ClassLibrary.Entity;
using ClassLibrary.RepositoryInterfaces;

namespace ClassLibrary.SQL
{
    public class AccountRepository : IAccountRepository
    {
        private string connectionString;

        public AccountRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Create(Account account)
        {
            using (SqlConnection connection =
                                  new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "insert into Accounts (id, name) values (@id, @name)";
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("id", account.Id);
                    cmd.Parameters.AddWithValue("name", account.Name);
                    try
                    {
                        return cmd.ExecuteNonQuery() == 1;
                    }
                    catch (SqlException e)
                    {
                        Debug.WriteLine(e.Message);
                        return false;
                    }
                }
            }
        }

        public Account SelectById(string id)
        {
            using (SqlConnection connection =
                      new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "select * from accounts where id = @id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("id", id);
                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        return new Account
                        {
                            Id = (string)dataReader["id"],
                            Name = (string)dataReader["name"]
                        };
                    }
                }
                return null;
            }
        }

        public bool Update(Account account)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.CommandText = "update accounts set name = @name where id = @id";
                        cmd.Connection = connection as SqlConnection;
                        cmd.Parameters.AddWithValue("id", account.Id);
                        cmd.Parameters.AddWithValue("name", account.Name);
                        int rowsUpdated = cmd.ExecuteNonQuery();
                        return rowsUpdated == 1;
                    }
                    catch (SqlException e)
                    {
                        Debug.WriteLine(e.Message);
                        return false;
                    }
                }
            }
        }

        public bool Delete(string accountId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "delete from accounts where id = @id";
                    cmd.Parameters.AddWithValue("id", accountId);
                    cmd.Connection = connection;
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }
    }
}