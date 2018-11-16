using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Abstract_Factory
{
    class Class1
    {
        static void Main(string[] args)
        {
            IAbstractEcommerceFactory factory = new SqlServerEcommerceFactory();

            IAccountModel accountModel = factory.AccountModel;
            accountModel.Create(new Account());

            IProductModel productModel = factory.ProductModel;
            productModel.Create(new Product());

            IOrderModel orderModel = factory.OrderModel;
            orderModel.Create(new Order());

        }
    }
}
