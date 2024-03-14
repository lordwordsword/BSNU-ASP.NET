public class Product
{
    static int productId = 0;
    public int Id {get;}
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public Product(string name, decimal price, DateTime createdDateTime)
    {
        Id = productId++;
        Name = name;
        Price = price;
        CreatedDateTime = createdDateTime;
    }
}

