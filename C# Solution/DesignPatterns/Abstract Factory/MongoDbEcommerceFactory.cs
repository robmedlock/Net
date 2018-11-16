using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Abstract_Factory
{
    public class MongoDbEcommerceFactory : IAbstractEcommerceFactory
    {
        public IAccountModel AccountModel
        {
            get
            {
                return new MongoDbAccountModel();
            }
        }

        public IOrderModel OrderModel
        {
            get
            {
                return new MongoDbOrderModel();
            }
        }

        public IProductModel ProductModel
        {
            get
            {
                return new MongoDbProductModel();
            }
        }
    }
}
