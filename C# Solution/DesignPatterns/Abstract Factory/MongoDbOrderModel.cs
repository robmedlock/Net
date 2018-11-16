using System;
using System.Collections.Generic;

namespace DesignPatterns.Abstract_Factory
{
    public class MongoDbOrderModel : IOrderModel
    {
        public Order this[int id]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<Order> Orders
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Create(Order order)
        {
            throw new NotImplementedException();
        }
    }
}