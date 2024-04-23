//Product product1 = new Product("Магазин 1", "Продукт 1", "Описание продукта 1", 10.0, 20, 5);
//Product product2 = new Product("Магазин 2", "Продукт 2", "Описание продукта 2", 15.0, 30, 3);
//Product product3 = new Product("Магазин 3", "Продукт 3", "Описание продукта 3", 20.0, 25, 4);

//Product.AddStructProduct(product1, new string[] { "Ингредиент 1", "Ингредиент 2", "Ингредиент 3", "Ингредиент 4", "Ингредиент 5" });
//Product.AddStructProduct(product2, new string[] { "Ингредиент A", "Ингредиент B", "Ингредиент C" });
//Product.AddStructProduct(product3, new string[] { "Ингредиент X", "Ингредиент Y", "Ингредиент Z", "Ингредиент W" });
namespace Laba3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name_shop = Print.GetInput("Введите название вашего магазина");
            List<Product> products = new List<Product>();

            string input_check = string.Empty;
            while (input_check != "exit")
            {
                Console.Clear();
                Console.WriteLine($"Всего продуктов в магазине {Product.CounterProduct}");
                Print.PrintMenu(name_shop);
                int choice = Print.GetIntInput("Выберите пункт меню");
                Product curentProduct;
                switch (choice)
                {
                    case 1:
                        products.Add(Product.AddProduct());
                        Product.IncreaseProductCount();
                        Console.WriteLine("Продукт успешно добавлен");
                        break;
                    case 2:
                        if (Product.CounterProduct > 0)
                        {
                            Product.RemoveProduct(products);
                            Console.WriteLine("Продукт успешно удален");
                            Product.DecreaseProductCount();
                        }
                        break;
                    case 3:
                        curentProduct = Product.SearchSelectedProduct(products);
                        if (curentProduct != null)
                        {
                            Product.UpdateCurrentProduct(curentProduct, Print.PrintMenuForSelectedUpdateProduct());
                        }
                        else
                        {
                            Console.WriteLine("Продукт не найден");
                        }
                        break;
                    case 4:
                        Product.SearchLinesInSelectedProduct(products, Print.PrintMenuForSearch());
                        break;
                    case 5:
                        Product.PrintAllProduct(products);
                        break;
                    case 6:
                        curentProduct = Product.SearchSelectedProduct(products);
                        if (curentProduct != null)
                        {
                            Product.PrintCurrentProduct(curentProduct);
                        }
                        else
                        {
                            Console.WriteLine("Продукт не найден");
                        }
                        break;
                    case 7:
                        input_check = "exit";
                        break;
                    case 8:
                        products[Product.CounterProduct] = Toy.AddToy();
                        break;
                    default:
                        Console.WriteLine("неверный пункт меню");
                        break;
                }
                Print.WaitingForClick("Нажмите любую клавишу для продолжения");
            }
            Console.WriteLine("Завершение работы прораммы...");
        }


    }
}
