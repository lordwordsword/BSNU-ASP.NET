public static class ProductRepository
{
    static List<Product> Products = new List<Product>();

    public static IList<Product> GetProductList() => Products;

    public static bool AddProduct(Product? product)
    {
        if (product == null) {
            return false;
        }
        Products.Add(product);
        return true;
    }

    public static void init(){
        Products = new List<Product> {
            new Product("Смажені цвяхи", 99.99m, DateTime.Today.AddDays(-10)),
            new Product("Позавчорашній суп", 10.49m, DateTime.Today.AddDays(-2)),
            new Product("Вчорашній суп", 11.99m, DateTime.Today.AddDays(-1)),
            new Product("Фібоначі суп", 11.24m, DateTime.Today), 
        }; 
    }
}

