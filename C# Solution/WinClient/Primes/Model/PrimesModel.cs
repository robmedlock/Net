using System;
using System.Linq;
using System.Threading.Tasks;

namespace WinClient.Primes.Model
{
    public class PrimesModel : IPrimesModel
    {
        public int Count(int max)
        {
            return (from n in Enumerable.Range(2, max)
                    where Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)
                    select n).Count();
        }

        public async Task<int> CountAsync(int max)
        {
            Func<int> func = () => (from n in Enumerable.Range(2, max)//.AsParallel()
                                    where Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)
                                    select n).Count();
            int result = await Task.Run(func);
            return result;
        }
    }
}
