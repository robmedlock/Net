namespace DesignPatterns.Decorator
{

    public class Product : IPackage
    {  
        public string Name { get; set; }
        public double CostPrice { get; set; }
        public virtual double RetailPrice { get; }        
    }
}
