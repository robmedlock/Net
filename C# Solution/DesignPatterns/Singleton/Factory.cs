using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    public class Factory
    {
        private static IProductModel productModel;
        private Factory()
        {
        }

        public static IProductModel ProductModel
        {
            get
            {
                if (productModel==null)
                    productModel = new SqlProductModel();
                return productModel;
            }
        }
    }
}
