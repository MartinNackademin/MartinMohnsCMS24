namespace Shared.Models;

public class Product
{
    public string Id { get; set; } = Guid.NewGuid().ToString(); // Make a factory that creates the Product Object
    public string Name { get; set; } = null!;
    public string Price { get; set; } = null!;
    public string Category { get; set; } = null!;
}
