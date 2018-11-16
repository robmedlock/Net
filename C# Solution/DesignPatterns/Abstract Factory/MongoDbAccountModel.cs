using System;
using System.Collections.Generic;

namespace DesignPatterns.Abstract_Factory
{
    public class MongoDbAccountModel : IAccountModel
    {
        public Account this[string id]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<Account> Accounts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Create(Account account)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Account> SelectByName(string partOfName)
        {
            throw new NotImplementedException();
        }

        public bool Update(Account account)
        {
            throw new NotImplementedException();
        }
    }
}