using Capco.Interfaces;

namespace Capco;

public class Company : ICompany
{
    public List<(IProduct product, int quantity)> Products { get; set; }
    public List<IUser> Users { get; set; }

    public Company()
    {
        Products = new List<(IProduct product, int quantity)>();
        Users = new List<IUser>();
    }

    public void MakeOrder(List<IProduct> products, IUser user)
    {
        //Can be used depending on the business rules for example:
        //to check late to know what orders arent shipped
        //or to stop orders from being processed 
        var checks = new List<(int productId, bool isOrderPossible)>();
        var highestShippingCost = Decimal.Zero;
        var totalCost = Decimal.Zero;
        var orderableProducts = new List<(IProduct product, int quantity)>();

        foreach (var product in products)
        {
            var wantedProduct = Products.Find(
                p => p.product.Id == product.Id);

            if (wantedProduct.quantity == 0) checks.Add((product.Id, false));
            else
            {
                if (product.ShippingCost > highestShippingCost)
                    highestShippingCost = wantedProduct.product.ShippingCost;

                totalCost += wantedProduct.product.Price;

                var orderableProduct = orderableProducts.First(
                    o => o.product.Id == product.Id);
                orderableProducts.Add((orderableProduct.product, orderableProduct.quantity + 1));
                orderableProducts.Remove(orderableProduct);

                var updatedWantedProduct = (wantedProduct.product, wantedProduct.quantity - 1);
                Products.Remove(wantedProduct);
                Products.Add(updatedWantedProduct);
            }
        }

        if (user.Balance < totalCost + highestShippingCost) return;
        user.Balance -= totalCost + highestShippingCost;
        user.Orders.AddRange(orderableProducts);
    }

    public void AddProduct(IProduct product, int quantity)
    {
        if (quantity >= 0) Products.Add((product, quantity));
        else
            throw new ArgumentException($"{nameof(quantity)} cannot be less than zero");
    }

    public void AddUser(int id, string name, decimal balance)
    {
        if (!string.IsNullOrWhiteSpace(name)) Users.Add(new User(id, name, balance));
        else
            throw new ArgumentException($"{nameof(name)} cannot be null, empty or whitespace");
    }
}