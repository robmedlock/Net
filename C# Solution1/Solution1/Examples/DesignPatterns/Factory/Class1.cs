using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.DesignPatterns.Factory
{
    class Class1
    {
        static void Main(string[] args)
        {
            IProductModel productModel = Factory.ProductModel;
        }

    }
}
