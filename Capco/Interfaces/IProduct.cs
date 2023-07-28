namespace Capco.Interfaces;

public interface IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal ShippingCost { get; set; }
}