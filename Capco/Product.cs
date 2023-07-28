using Capco.Interfaces;

namespace Capco;

public class Product:IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal ShippingCost { get; set; }

    public Product(int id, string name, decimal price, decimal shippingCost)
    {
        Id = id;
        Name = name;
        Price = price;
        ShippingCost = shippingCost;
    }
}