using OrderTaker.SharedObjects;

namespace OrderTaker.Data;

public static class Products
{
    public static List<Product> GetProducts()
    {
        return new List<Product>()
        {
            new Product(1, "Universal Translator", 199.99M),
            new Product(2, "Captain's Chair (Vinyl)",549.99M),
            new Product(3, "Captain's Chair (Leather)", 2999.99M),
            new Product(4, "Laser Beacon", 99.95M),
            new Product(5, "Space Suit", 599.99M),
            new Product(6, "Warp Engine", 1599.99M),
            new Product(7, "Moonbase", 2999999.99M),
            new Product(8, "Starship", 5999999.99M),
            new Product(9, "Name Badge: John", 0.99M),
            new Product(10, "Name Badge: Dante", 0.99M),
            new Product(11, "Name Badge: Isaac", 0.99M),
        };
    }
}
