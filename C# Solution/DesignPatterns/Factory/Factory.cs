using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public class Factory
    {
        public static IProductModel ProductModel
        {
            get
            {
                return new SqlProductModel();
            }
        }
    }
}
