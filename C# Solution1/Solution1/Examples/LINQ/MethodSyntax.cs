using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples
{
    public class MethodSyntax
    {
        public static void LambdaExpression()
        {
            //Data source

            int[] numbers = { 0, 1, 2, 3, 4, 5, 6 };

            Func<int, bool> predicate = i => i%2 == 0;
            IEnumerable<int> numQuery = numbers.Where(predicate);

            foreach (int num in numQuery)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine($"the last element in the sequence is {numQuery.Last()}");

        }

        public static void MethodSyntax1()
        {
            ICollection<Product> products = new List<Product> {
                new Product("p1", "Pedigree Chum", 0.70, 1.42),
                new Product("p2", "Knife", 0.60, 1.31),
                new Product("p3", "Fork", 0.75, 1.57),
                new Product("p4", "Spaghetti", 0.90, 1.92),
                new Product("p5", "Cheddar Cheese", 0.65, 1.47),
                new Product("p6", "Bean bag", 15.20, 32.20),
                new Product("p7", "Bookcase", 22.30, 46.32),
                new Product("p8", "Table", 55.20, 134.80),
                new Product("p9", "Chair", 43.70, 110.20),
                new Product("p10", "Doormat", 3.20, 7.40)
            };

            //the previous query, written using method syntax
            IEnumerable<string> result = products.Where(p => p.RetailPrice < 50).Select(p => p.Name);
            result.ToList().ForEach(n => Console.WriteLine(n));
            Console.WriteLine("------------------------------------------------------");

            //how many products have a retail price over 50 ?
            int count = products.Count(p => p.RetailPrice > 50);
            Console.WriteLine(count);
            Console.WriteLine("------------------------------------------------------");

            //what is the average percentage markup on the cost price ?
            double percent = products.Average(p => (p.RetailPrice / p.CostPrice) - 1) * 100;
            Console.WriteLine($"{percent:F1}%");
        }

        public static void AnonymousTypes()
        {
            ICollection<Product> products = new List<Product> {
                new Product("p1", "Pedigree Chum", 0.70, 1.42),
                new Product("p2", "Knife", 0.60, 1.31),
                new Product("p3", "Fork", 0.75, 1.57),
                new Product("p4", "Spaghetti", 0.90, 1.92),
                new Product("p5", "Cheddar Cheese", 0.65, 1.47),
                new Product("p6", "Bean bag", 15.20, 32.20),
                new Product("p7", "Bookcase", 22.30, 46.32),
                new Product("p8", "Table", 55.20, 134.80),
                new Product("p9", "Chair", 43.70, 110.20),
                new Product("p10", "Doormat", 3.20, 7.40)
            };

            var result = products.
                Where(p => p.RetailPrice < 50).
                Select(p => new { p.Id, p.Name });

            result.ToList().ForEach(x => Console.WriteLine(x.Name));
         }

        public static int PrimeCount(int max)
        {
            int result = (from n in Enumerable.Range(2, max).AsParallel()
                          where Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)
                          select n).Count();
            return result;
        }

        public async static Task<int> PrimeCountAsync(int max)
        {
            int result = await Task.Run(() => (from n in Enumerable.Range(2, max).AsParallel()
                                               where Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)
                                               select n).Count());
            return result;
        }


    }
}


