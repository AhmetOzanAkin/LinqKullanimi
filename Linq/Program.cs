List<Category> categories = new List<Category>
{
    new Category{CategoryId=1, CategoryName="Bilgisayar"},
    new Category{CategoryId=2, CategoryName="Telefon"}
};

List<Product> products = new List<Product> {

        new Product{ProductId=1,CategoryId=1, ProductName="Acer Laptop", QuantityPerUnit="32 GB Ram", UnitPrice = 12000, UnitsInStock = 5},
        new Product{ProductId=2,CategoryId=1, ProductName="Asus Laptop", QuantityPerUnit="16 GB Ram", UnitPrice = 8000, UnitsInStock = 15},
        new Product{ProductId=3,CategoryId=1, ProductName="Hp Laptop", QuantityPerUnit="8 GB Ram", UnitPrice = 4000, UnitsInStock = 25},
        new Product{ProductId=4,CategoryId=2, ProductName="Samsung Telefon", QuantityPerUnit="4 GB Ram", UnitPrice = 5000, UnitsInStock = 35},
        new Product{ProductId=5,CategoryId=2, ProductName="Apple Telefon", QuantityPerUnit="16 GB Ram", UnitPrice = 10000, UnitsInStock = 5}
};

//AnyTest(products);

//LinqTest(products);

//FindTest(products);

//FindAllTest(products);
//AscDescTest(products);

//ClassicLinqTest(products);

//JoinTest(categories, products);

static List<Product> GetProducts(List<Product> products)
{
    List<Product> filteredProducts = new List<Product>();

    foreach (var product in products)
    {
        if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
        {
            Console.WriteLine(product.ProductName);
        }
    }
    return filteredProducts;
}

static List<Product> GetProductsLinq(List<Product> products)
{
    return products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3).ToList();

}

static void AnyTest(List<Product> products)
{
    var result = products.Any(p => p.ProductName == "Acer Laptop"); // Acer laptop var mı yok mu diye sorgular true ya da false döndürür
    Console.WriteLine(result);
}

static void LinqTest(List<Product> products)
{
    Console.WriteLine("--------------------------");
    Console.WriteLine("Algoritmik Kullanım");
    Console.WriteLine("--------------------------");
    foreach (var product in products)
    {
        if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
        {
            Console.WriteLine(product.ProductName);
        }
    }
    Console.WriteLine("--------------------------");
    Console.WriteLine("Linq Kullanımı");
    Console.WriteLine("--------------------------");
    var result = products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3);
    foreach (var product in result)
    {
        Console.WriteLine(product.ProductName);
    }
}

static void FindTest(List<Product> products)
{
    var result = products.Find(p => p.ProductId == 3); // id'si 3 olan product'u verir
    Console.WriteLine(result.ProductName);
}

static void FindAllTest(List<Product> products)
{
    var result = products.FindAll(p => p.ProductName.Contains("top")); // içerisinde top geçen productları listeler
    Console.WriteLine(result);
}

static void AscDescTest(List<Product> products)
{
    var result = products.Where(p => p.ProductName.Contains("top")).OrderByDescending(p => p.UnitPrice).ThenByDescending(p => p.ProductName); // içerisinde top olan ürünleri azalan fiyata doğru sırala
    foreach (var product in result)
    {
        Console.WriteLine(product.ProductName);
    }
}

static void ClassicLinqTest(List<Product> products)
{
    var result = from p in products
                 where p.UnitPrice > 6000
                 orderby p.UnitPrice descending, p.ProductName ascending
                 select p;
    foreach (var product in result)
    {
        Console.WriteLine(product.ProductName);
    }
}

static void JoinTest(List<Category> categories, List<Product> products)
{
    var result = from p in products
                 join c in categories
                 on p.CategoryId equals c.CategoryId
                 where p.UnitPrice > 5000
                 orderby p.UnitPrice descending
                 select new ProductDto { ProductId = p.ProductId, CategoryName = c.CategoryName, ProductName = p.ProductName, UnitPrice = p.UnitPrice };
    foreach (var productDto in result)
    {
        Console.WriteLine("{0} --- {1}", productDto.ProductName, productDto.CategoryName);
    }
}

class ProductDto
{
    public int ProductId { get; set; }
    public string CategoryName { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }

}
class Product
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string ProductName { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }

}

class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}