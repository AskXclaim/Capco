namespace Capco.Interfaces;

public interface ICompany
{
    public List<(IProduct product, int quantity)> Products { get; set; }
    public List<IUser> Users { get; set; }
    public void MakeOrder(List<IProduct> products, IUser user);
    void AddProduct(IProduct product, int quantity);
    void AddUser(int id, string name, decimal balance);
}