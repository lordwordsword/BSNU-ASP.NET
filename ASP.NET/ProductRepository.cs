using System.Collections.Generic;

public static class ProductRepository
{
    private static List<Product> _products = new List<Product>
    {
        new Product { Name = "Pizza 1", Price = 10.99m },
        new Product { Name = "Pizza 2", Price = 20.49m },
        new Product { Name = "Pineapple Pizza", Price = 25.49m },
    };

    public static IReadOnlyList<Product> Products => _products.AsReadOnly();
}