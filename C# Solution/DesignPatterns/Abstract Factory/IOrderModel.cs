using System.Collections.Generic;

namespace DesignPatterns.Abstract_Factory
{
    public interface IOrderModel
    {
        int Create(Order order);
        Order this[int id] { get; }
        ICollection<Order> Orders { get; }
    }
}