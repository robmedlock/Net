using ClassLibrary.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace ClassLibrary.SQL.Test
{
    [Collection("Collection 1")]
    public class AccountRepositoryIntegrationTest
    {
        private string connectionString;

        public AccountRepositoryIntegrationTest()
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
        public void Create_DuplicateAccount_ShouldReturnFalse()
        {
            //arrange
            AccountRepository accountRepository = new AccountRepository(connectionString);
            Account account = new Account("acc2", "Jane Jones");
            //act
            bool firstAccountCreated = accountRepository.Create(account);
            bool secondAccountCreated = accountRepository.Create(account);
            //assert
            Assert.True(firstAccountCreated);
            Assert.False(secondAccountCreated);
        }


        [Fact]
        public void SelectById_WhenPassedId_ShouldReturnAccount()
        {
            //arrange
            AccountRepository accountRepository = new AccountRepository(connectionString);
            
            //act
            Account account = accountRepository.SelectById("acc1");

            //assert
            Assert.Equal("John Smith", account.Name);
        }

        [Fact]
        public void Delete_WhenPassedId_ShouldRemoveAccount()
        {
            //arrange
            AccountRepository accountRepository = new AccountRepository(connectionString);

            //act
            bool deleted = accountRepository.Delete("acc1");

            //assert
            Assert.True(deleted);
            Assert.Null(accountRepository.SelectById("acc1"));
        }

        [Fact]
        public void Update_Account_ShouldUpdateAccount()
        {
            //arrange
            AccountRepository accountRepository = new AccountRepository(connectionString);
            Account account = new Account("acc1", "Jim Smith");
            //act
            bool updated = accountRepository.Update(account);
            //assert
            Assert.True(updated);
            Assert.Equal("Jim Smith", accountRepository.SelectById("acc1").Name);
        }

    }
}
