namespace DesignPatterns.Adapter
{
    public class Client
    {
        static ITarget target = new Adapter();
        static void Main(string[] args)
        {
            target.addProduct(new Product{ Id = "p1", Name="Pedigree chum" });
            target.removeProduct(new Product { Id = "p1" });
        }
    }
}
