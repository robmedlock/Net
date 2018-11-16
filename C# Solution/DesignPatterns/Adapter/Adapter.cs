using System;


namespace DesignPatterns.Adapter
{
    public class Adapter : ITarget
    {
        private Adaptee adaptee;

        public void addProduct(Product p)
        {
            adaptee.Create(p);
        }

        public void removeProduct(Product p)
        {
            adaptee.Delete(p.Id);
        }
    }
}
