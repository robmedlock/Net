namespace WebApiClient
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double CostPrice { get; set; }
        public double RetailPrice { get; set; }
        public byte[] RowVersion { get; set; }
    }
}