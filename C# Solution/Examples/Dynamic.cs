using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public class Dynamic
    {
        public static void Main()
        {
            //let the compiler determine the type
            var v = GetSomeObject();
            //Console.WriteLine(v.Year);

            //resolved at runtime 
            dynamic d = GetSomeObject();
            Console.WriteLine(d.Year);
            Console.ReadKey();
        }

        public static object GetSomeObject()
        {
            return DateTime.Now;
        }
    }
}
