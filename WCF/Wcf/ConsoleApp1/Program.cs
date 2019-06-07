using ConsoleApp1.ServiceReference1;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();
            Product[] products = client.SelectAll();
            foreach (Product product in products)
            {
                Console.WriteLine(product.Name);
            }
            Console.ReadKey();
        }
    }
}
