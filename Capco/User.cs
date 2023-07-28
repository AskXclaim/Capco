using Capco.Interfaces;

namespace Capco;

public class User:IUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public List<(IProduct Product, int quantity)> Orders { get; set; }

    public User(int id, string name, decimal balance)
    {
        Id = id;
        Name = name;
        Balance = balance;
        Orders = new List<(IProduct Product, int quantity)>();
    }
}