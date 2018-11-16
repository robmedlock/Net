using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    class OutExample
    {
        static void Method(out int i)
        {
            i = 10;
        }

        static void Main(string[] args)
        {
            int val;
            Method(out val);
            Console.WriteLine(val);
            Console.ReadKey();
        }
    }
}
