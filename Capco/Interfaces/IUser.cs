namespace Capco.Interfaces;

public interface IUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public List<(IProduct Product, int quantity)> Orders { get; set; }
}