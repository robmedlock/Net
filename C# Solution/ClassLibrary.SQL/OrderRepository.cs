using System;
using ClassLibrary.RepositoryInterfaces;
using ClassLibrary.Entity;
using System.Data.SqlClient;
using System.Data;

namespace ClassLibrary.SQL
{
    public class OrderRepository : IOrderRepository
    {
        private string connectionString;

        public OrderRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int Create(Order order)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                    //add a row to the Orders table
                    string sql = "insert into orders(date, orderStatus, accountId) values(@date, @orderStatus, @accountId) select scope_identity()";
                    using (SqlCommand cmd = new SqlCommand(sql, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("date", order.Date);
                        cmd.Parameters.AddWithValue("orderStatus", order.OrderStatus);
                        cmd.Parameters.AddWithValue("accountId", order.AccountId);
                        int orderId = Convert.ToInt32(cmd.ExecuteScalar());
                        return orderId;
                    }
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
        }

        public bool Delete(int orderId)
        {
            throw new NotImplementedException();
        }

        public Order SelectByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }

        public Order SelectProvisionalOrderByAccountId(string accountId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
