using System.Collections.Generic;

namespace DesignPatterns.Abstract_Factory
{
    public interface IAccountModel
    {
        ICollection<Account> Accounts { get; }
        Account this[string id] { get; }
        ICollection<Account> SelectByName(string partOfName);
        bool Create(Account account);
        bool Delete(string id);
        bool Update(Account account);
    }
}
