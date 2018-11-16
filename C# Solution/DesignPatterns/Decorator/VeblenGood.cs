namespace DesignPatterns.Decorator
{
    public class VeblenGood : Product
    {
        public override double RetailPrice
        {
            get
            {
                return CostPrice * 4;
            }
        }
    }
}
