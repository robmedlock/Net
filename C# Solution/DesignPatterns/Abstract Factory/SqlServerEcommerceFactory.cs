using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Abstract_Factory
{
    public class SqlServerEcommerceFactory : IAbstractEcommerceFactory
    {
        public IAccountModel AccountModel
        {
            get
            {
                return new SqlAccountModel();
            }
        }

        public IOrderModel OrderModel
        {
            get
            {
                return new SqlOrderModel();
            }
        }

        public IProductModel ProductModel
        {
            get
            {
                return new SqlProductModel();
            }
        }
    }
}
