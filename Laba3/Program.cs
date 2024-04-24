namespace Laba3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name_shop = Print.GetInput("Введите название вашего магазина");
            Product.DiscountAmount = Print.GetIntInput("Введите сегодняшнию сумму скидки на все товары");
            List<Product> products = new List<Product>();
            string input_check = string.Empty;
            while (input_check != "exit")
            {

                Console.Clear();
                Print.PrintCountAllDepartamentProduct();
                Print.PrintMenu(name_shop);
                int choice = Print.GetIntInput("Выберите пункт меню");
                Product curentProduct;
                List<Product> selectedProductDepartamentd;
                switch (choice)
                {
                    case 1:
                        Print.CreatedSelectedProduct(products);
                        Product.IncreaseProductCount();
                        Console.WriteLine("Продукт успешно добавлен");
                        break;
                    case 2:
                        if (Product.CounterProduct > 0)
                        {
                            Console.WriteLine("В каком отделе произвести поиск?");
                            selectedProductDepartamentd = Product.GetProductBySelectedDepartament(products);
                            Product.RemoveProduct(selectedProductDepartamentd);
                            Console.WriteLine("Продукт успешно удален");
                            Product.DecreaseProductCount();
                        }
                        break;
                    case 3:
                        Console.WriteLine("В каком отделе произвести поиск?");
                        selectedProductDepartamentd = Product.GetProductBySelectedDepartament(products);
                        curentProduct = Product.SearchSelectedProduct(products);
                        if (curentProduct != null)
                        {
                            Console.WriteLine($"Товар из отдела {Print.GetDepartamentByProduct(curentProduct)}");
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
                        Console.WriteLine("В каком отделе произвести поиск?");
                        selectedProductDepartamentd = Product.GetProductBySelectedDepartament(products);
                        curentProduct = Product.SearchSelectedProduct(selectedProductDepartamentd);
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
