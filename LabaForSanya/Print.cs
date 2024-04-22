using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaForSanya
{
    internal class Print
    {
        public static void PrintMenu()
        {
            Console.WriteLine("\n\n1. Добавить продукт");
            Console.WriteLine("2. удалить продукт");
            Console.WriteLine("3. Изменить объект");
            Console.WriteLine("4. Поиск объектов по полю");
            Console.WriteLine("5. Показать все продукты");
            Console.WriteLine("6. Показать информацию об одном объекте");
        }

        public static string GetInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static double GetDoubleInput(string message) { 
            bool isValidInput = false;
            int userInput = 0;

            do
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                isValidInput = int.TryParse(input, out userInput);

                if (!isValidInput)
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите число.");
                }
            } while (!isValidInput);
            return userInput;
        }

        public static int GetIntInput(string message)
        {
            bool isValidInput = false;
            int userInput = 0;

            do
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                isValidInput = int.TryParse(input, out userInput);

                if (!isValidInput)
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите целое число.");
                }

            } while (!isValidInput);

            return userInput;
        }

        public static void PrintAllProducts()
        {
            int count = 1;
            foreach (Product product in ProductManager.GetProducts())
            {
                Console.WriteLine($"{count}. " + product.Name);
                count++;
            }

        }

        public static void PrintProducts(string name)
        {
            Product prod = ProductManager.FindProductByName(name);
            if (prod != null)
            {
                string product_name = prod.Name;
                Console.WriteLine($"Название продукта : " + product_name);
                string product_description = prod.Description;
                Console.WriteLine($"Описание продукта : " + product_description);
                double product_price = prod.Price;
                Console.WriteLine($"Стоимость продукта : " + product_price);
                int producnt_quantity = prod.Quantity;
                Console.WriteLine($"Всего продуктов : " + producnt_quantity);
                int lenght_current_product = Product.GetLenghtStructure(prod.Name);
                Console.WriteLine("Cостав :");
                for(int i = 0; i < lenght_current_product; ++i)
                {
                    Console.WriteLine($"{i}. " + prod[i]);
                }
            }
            else
            {
                Console.WriteLine("Продукт не найден");
            }
        }

        public static void CurrentPointMenupdate(int choice, Product current_product, int lenght_current_product)
        {
            switch (choice)
            {
                case 1:
                    current_product.Description = Print.GetInput("Введите новое описание продукта");
                    break;
                case 2:
                    current_product.Price = Convert.ToDouble(Print.GetInput("Введите новую цену продукта"));
                    break;
                case 3:
                    current_product.Quantity = Print.GetIntInput("Введите новое колличество продуктов");
                    break;
                case 4:
                    ProductManager.InputProductSturcture(current_product, lenght_current_product);
                    break;
                default:
                    Console.WriteLine("Некорректный ввод");
                    break;
            }
        }
    }
}
