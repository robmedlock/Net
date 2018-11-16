using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{
    class Class1
    {
        static void Main(string[] args)
        {
            VeblenGood veblenGood = new VeblenGood {CostPrice = 500 };
            Console.WriteLine($"Retail price £{veblenGood.RetailPrice}");

            Post p = new Post(veblenGood);
            Console.WriteLine($"Retail price including postage £{p.RetailPrice}");

            Courier c = new Courier(veblenGood);
            c.DeliveryInstructions = "Leave by back door";
            Console.WriteLine($"Retail price including courier £{c.RetailPrice}, {c.DeliveryInstructions}");

            FileStream fileStream = new FileStream(@"C:\Users\User\Documents\file1.bin", FileMode.Create);
            BufferedStream bufferedStream = new BufferedStream(fileStream);
            byte[] bytes = {10,20,127};
            bufferedStream.Write(bytes, 0, 3);
            bufferedStream.Close();
            fileStream.Close();

            Console.ReadKey();
        }
    }
}
