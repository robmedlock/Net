using ClassLibrary.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Xunit;

namespace ClassLibrary.SQL.Test
{
    [Collection("Collection 1")]
    public class OrderRepositoryIntegrationTest
    {
        private string connectionString;

        public OrderRepositoryIntegrationTest()
        {
            string outputDirectory = Directory.GetCurrentDirectory();//JSON file, select CopyToOutputDirectory
            connectionString = new ConfigurationBuilder()
            .SetBasePath(outputDirectory)
            .AddJsonFile("appsettings.json")
            .Build().GetConnectionString("Db1Connection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = File.ReadAllText(@"..\..\..\setup.sql");
                cmd.ExecuteNonQuery();
            }
        }
        [Fact]
        public void Create_ReturnsGeneratedOrderId()
        {
                var orderRepository = new OrderRepository(connectionString);
                Order order = new Order { AccountId = "acc1" };
                int orderId1 = orderRepository.Create(order);
                int orderId2 = orderRepository.Create(order);
                Assert.True(orderId2 > orderId1);
        }
    }
}
