using LabaForSanya;
using System;

class Program
{
    static void Main()
    {

        Console.WriteLine("Старт программы, введите число для выбора\n");
        Print.PrintMenu();
        string name;
        string check = Console.ReadLine();
        while (check != "exit")
        {
            switch (check)
            {
                case "1":
                    name = Print.GetInput("Введите название продукта");
                    ProductManager.AddProduct(name);
                    break;

                case "2":
                    Print.PrintAllProducts();
                    name = Print.GetInput("Введите название продукта для удаления");
                    ProductManager.RemoveProduct(name);
                    break;

                case "3":
                    name = Print.GetInput("Введите название продукта для редактирования");
                    ProductManager.UpdateProduct(name);
                    break;
                case "4":
                    ProductManager.SearchMenu();
                    break;
                case "5":
                    Print.PrintAllProducts();
                    break;
                case "6":
                    name = Print.GetInput("Введите название продукта для поиска");
                    Print.PrintProducts(name);
                    break;
                default:
                    Console.WriteLine("print exit for exit");
                    break;
            }
            Print.PrintMenu();
            Console.WriteLine("print exit for exit");
            check = Console.ReadLine();
            check.ToLower();
            Console.Clear();

        }
    }
}