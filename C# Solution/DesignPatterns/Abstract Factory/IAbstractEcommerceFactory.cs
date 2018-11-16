using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Abstract_Factory
{
    public interface IAbstractEcommerceFactory
    {
        IAccountModel AccountModel { get;  }
        IProductModel ProductModel { get; }
        IOrderModel OrderModel { get;  }
    }
}
