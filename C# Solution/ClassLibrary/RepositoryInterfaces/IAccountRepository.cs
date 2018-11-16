using ClassLibrary.Entity;
using System.Collections.Generic;

namespace ClassLibrary.RepositoryInterfaces
{
    public interface IAccountRepository
    {
        bool Create(Account account);
        Account SelectById(string id);
        bool Update(Account account);
        bool Delete(string accountId);
    }
}