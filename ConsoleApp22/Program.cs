namespace ConsoleApp22
{
    public delegate List<Product> filterlist(List<Product> products);
    internal class Program
    {
        static void Main(string[] args)
        {
            #region declare
            //declare
            List<Product> catalog = new()
            {
                new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
                new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
                new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
                new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
                new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
                new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
                new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
                new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
                new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
                new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
            };
            #endregion
            #region task01
            //List<Product> result1 = new List<Product>();
            //List<Product> result2 = new List<Product>();
            //List<Product> result3 = new List<Product>();
            //List<Product> result4 = new List<Product>();
            //filterlist f1 = Product.Electronics;
            //result1 = Product.filteroption(catalog, f1);
            //f1 = Product.prices;
            //result2 = Product.filteroption(catalog, f1);
            //f1 = Product.stock;
            //result3 = Product.filteroption(catalog, f1);
            //f1 = Product.clothing;
            //result4 = Product.filteroption(catalog, f1);
            //Console.WriteLine("---------electronics-----------");
            //for (int i = 0; i < result1.Count; i++)
            //{
            //    Console.WriteLine($"category:{result1[i].Category}");
            //}
            //Console.WriteLine("---------prices-----------");
            //for (int i = 0; i < result2.Count; i++)
            //{
            //    Console.WriteLine($"price:{result2[i].Price}");
            //}
            //Console.WriteLine("----------stock------------");
            //for (int i = 0; i < result3.Count; i++)
            //{
            //    Console.WriteLine($"stock:{result3[i].Stock}");
            //}
            //Console.WriteLine("----------clothing------------");
            //for (int i = 0; i < result4.Count; i++)
            //{
            //    Console.WriteLine($"clothing:{result4[i].Category},,,,,price:{result4[i].Price}");
            //}
            #endregion

        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public static List<Product> filteroption(List<Product> products, filterlist del)
        {
            List<Product> result = new List<Product>();

            result = del.Invoke(products);
            return result;
        }
        public static List<Product> Electronics(List<Product> products)
        {
            List<Product> result = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Category == "Electronics")
                {
                    result.Add(products[i]);
                }
            }
            return result;
        }
        public static List<Product> prices(List<Product> products)
        {
            List<Product> result = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Price < 50)
                {
                    result.Add(products[i]);
                }
            }
            return result;
        }
        public static List<Product> stock(List<Product> products)
        {
            List<Product> result = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Stock > 0)
                {
                    result.Add(products[i]);
                }
            }
            return result;

        }
        public static List<Product> clothing(List<Product> products)
        {
            List<Product> result = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Category == "Clothing" && products[i].Price < 100)
                {
                    result.Add(products[i]);
                }
            }
            return result;
        }
        public static void printreport(List<Product> products, Action<Product> action)
        {
            for (int i = 0; i < products.Count; i++)
            {
                action.Invoke(products[i]);
            }
        }
        public static void printshort(Product p)
        {
            Console.WriteLine($"category:{p.Category},,,,price:{p.Price}");
        }
        public static void printDetailed(Product p)
        {
            Console.WriteLine($"[{p.Category}],,{p.Name}|pric:{p.Price}|stock:{p.Stock}");
        }
        public static List<string> TransformProducts(List<Product> products, Func<Product, string> transform)
        {
            List<string> result = new();
            //transform = Scenario3;

            foreach (Product p in products)
            {
                result.Add(transform.Invoke(p));
            }
            return result;
        }
        public static string Scenario3(Product p)
        {
            string message;
            message = $"{p.Name},,,$({p.Price})";
            return message;
        }
        public static string Scenario4(Product p)
        {

            if (p.Price > 100)
                return $"{p.Name}: (expensive)";
            return $"{p.Name}: (Affordable)";

        }
        public static List<Product> FilterProducts(List<Product> products, Predicate<Product> filter)
        {
            List<Product> result = new();
            foreach (Product p in products)
            {
                if (filter(p))
                {
                    result.Add(p);
                }
            }
            return result;
        }
        public static bool alert(Product p) => p.Stock < 20;



    }

}
