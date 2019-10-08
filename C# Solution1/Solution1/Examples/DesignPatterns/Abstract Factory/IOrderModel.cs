using System.Collections.Generic;

namespace Examples.DesignPatterns.Abstract_Factory
{
    public interface IOrderModel
    {
        int Create(Order order);
        Order this[int id] { get; }
        ICollection<Order> Orders { get; }
    }
}