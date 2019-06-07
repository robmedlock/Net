using System.Runtime.Serialization;

namespace WcfService1
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double CostPrice { get; set; }
        public virtual double RetailPrice { get; set; }

        public Product()
        {

        }
        public Product(string id, string name, double costPrice, double retailPrice)
        {
            Id = id;
            Name = name;
            CostPrice = costPrice;
            RetailPrice = retailPrice;
        }
        public override bool Equals(object obj)
        {
            return (obj as Product) != null && (obj as Product).Id == Id;
        }
    }
}