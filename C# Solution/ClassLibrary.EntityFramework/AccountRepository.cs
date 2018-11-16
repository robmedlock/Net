using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ClassLibrary.Entity;
using ClassLibrary.RepositoryInterfaces;
using System.Threading.Tasks;
using System;

namespace ClassLibrary.EntityFramework 
{
    public class AccountRepository : IAccountRepository
    {
        private EcommerceContext context;

        public AccountRepository(EcommerceContext context)
        {
            this.context = context;
        }

        //This method is not used. Instead, adding an Order with the Account property set
        //causes a row to be added to the the Accounts table
        public bool Create(Account account)
        {
            EntityEntry<Account> accountEntry = context.Accounts.Add(account);
            try {
                return context.SaveChanges() == 1;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public Account SelectById(string id)
        {
            return context.Accounts.Find(id);
        }

        public bool Delete(string accountId)
        {
            Account account = context.Accounts.Find(accountId);
            if (account == null)
            {
                return false;
            }
            context.Remove(account);
            return context.SaveChanges() == 1;
        }

        public bool Update(Account modifiedAccount)
        {
            Account account = context.Accounts.Find(modifiedAccount.Id);
            if (account == null)
            {
                return false;
            }
            account.Name = modifiedAccount.Name;
            return context.SaveChanges() == 1;
        }
    }
}