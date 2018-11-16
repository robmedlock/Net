using ClassLibrary.Entity;
using System.Threading.Tasks;

namespace ClassLibrary.RepositoryInterfaces
{
    public interface IAccountRepositoryAsync
    {
        Task<bool> CreateAsync(string accountId);
    }
}