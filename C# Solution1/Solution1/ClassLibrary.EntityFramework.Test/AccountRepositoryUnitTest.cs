using ClassLibrary.Entity;
using ClassLibrary.Repository.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ClassLibrary.EntityFramework.Test
{
    public class AccountRepositoryUnitTest
    {
        protected EcommerceContext context;
        public AccountRepositoryUnitTest()
        {
            string dbname = Guid.NewGuid().ToString();
            context = new EcommerceContext(new DbContextOptionsBuilder<EcommerceContext>()
                              .UseInMemoryDatabase(dbname)
                              .Options);
        }

        ~AccountRepositoryUnitTest() => context.Dispose();

        [Fact]
        public void Create_Should_Add_Account()
        {
            Account account = new Account("acc1", "John Smith");
            var accountRepository = new AccountRepository(context);
            bool created = accountRepository.Create(account);
            Assert.Single(context.Accounts);
        }

        [Fact]
        public void SelectById_Should_Return_Correct_Account()
        {
            SeedDatabase(context);
            var accountRepository = new AccountRepository(context);
            Account account = accountRepository.SelectById("acc1");
            Assert.Equal("John Smith", account.Name);
        }

        [Fact]
        public void Update_Should_Update_Account()
        {
            SeedDatabase(context);
            Account account = new Account { Id = "acc1", Name = "Jim Smith" };
            var accountRepository = new AccountRepository(context);
            accountRepository.Update(account);
            Account updatedAccount = context.Accounts.Find("acc1");
            Assert.Equal("Jim Smith", updatedAccount.Name);
        }

        [Fact]
        public void Delete_Should_Remove_Account()
        {
            SeedDatabase(context);
            var accountRepository = new AccountRepository(context);
            accountRepository.Delete("acc1");
            Assert.Single(context.Accounts);
        }


        private void SeedDatabase(EcommerceContext context)
        {
            context.Accounts.Add(new Account { Id = "acc1", Name = "John Smith" });
            context.Accounts.Add(new Account { Id = "acc2", Name = "Jane Jones" });
            context.SaveChanges();
        }

    }
}
