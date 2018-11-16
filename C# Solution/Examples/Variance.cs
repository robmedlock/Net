using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples
{
    class Variance
    {
        static void Main(string[] args)
        {
            Func<Product, Product> func = new Func<Product, Product>(Target);
        }

        private static VeblenGood Target(Object arg)
        {
            throw new NotImplementedException();
        }
    }
}
