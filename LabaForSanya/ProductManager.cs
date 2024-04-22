using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaForSanya
{
    class ProductManager
    {
        private static List<Product> _products = new List<Product>();
        public static void AddProduct(string name)
        {
            string discr = Print.GetInput("Введите описание продукта");
            double price = Print.GetDoubleInput("Введите стоимость продукта");
            string quant = Print.GetInput("Введите колличество продукта");
            int row = Print.GetIntInput("Введите колличество элементов состава продукта");
            Product prod = new Product(name, row);
            prod.Name = name;
            prod.Description = discr;
            prod.Price = price;
            prod.Quantity = Convert.ToInt32(quant);
            InputProductSturcture(prod, row);


            _products.Add(prod);
        }

        public static void InputProductSturcture(Product prod, int row)
        {
            Console.WriteLine("Состав : ");
            for (int i = 0; i < row; ++i)
            {
                Console.Write($"{i + 1}. :");
                string str = Console.ReadLine();
                prod[i] = str;
            }
        }

        public static List<Product> GetProducts()
        {
            return _products;
        }

        public static void RemoveProduct(string name)
        {

            Product productToRemove = _products.FirstOrDefault(x => x.Name == name);
            if (productToRemove != null)
            {
                _products.Remove(productToRemove);

            }
        }

        public static Product FindProductByName(string name)
        {
            return _products.FirstOrDefault(x => x.Name == name);
        }

        public static void UpdateProduct(string name)
        {
            Product current_product = _products.FirstOrDefault(x => x.Name == name);
            if (current_product != null)
            {
                Console.WriteLine("Текущая информация о продукте :");
                Print.PrintProducts(current_product.Name);
                int lenght_current_product = Product.GetLenghtStructure(current_product.Name);

                Console.WriteLine("Выберите номер поля, которое вы хотите изменить:");
                Console.WriteLine("1. Описание");
                Console.WriteLine("2. Цена");
                Console.WriteLine("3. Количество");
                Console.WriteLine("4. Состав");

                int choice = Print.GetIntInput("");

                Print.CurrentPointMenupdate(choice, current_product, lenght_current_product);

                Console.WriteLine("Продукт успешно обновлен");
            }
            else
            {
                Console.WriteLine("Продукт не найден");
            }
        }

        public static void SearchMenu()
        {
            Console.WriteLine("Выберите номер поля, в котором вы хотите осуществить поиск : ");
            Console.WriteLine("1. Название");
            Console.WriteLine("2. Описание");
            Console.WriteLine("3. Цена");
            Console.WriteLine("4. Количество");
            Console.WriteLine("5. Состав");

            int choice = Print.GetIntInput("");

            IEnumerable<Product> current_product;
            switch (choice)
            {
                case 1:
                    string current_name = Print.GetInput("Введи название, которое искать");
                    current_product = _products.Where(x => x.Name.ToLower() == current_name.ToLower());
                    if (current_product.Count() > 0)
                    {
                        int count = 1;
                        foreach (Product name in current_product)
                        {
                            Console.Write($"{count++} :");
                            Print.PrintProducts(name.Name);
                        }
                        Console.WriteLine($"Всего совпадений : {current_product.Count()}");
                    }
                    else
                    {
                        Console.WriteLine("Ничего не найдено");
                    }

                    break;
                case 2:
                    string current_description = Print.GetInput("Введи строку для поиска в описании");
                    current_product = _products.Where(x => x.Description.ToLower().Contains(current_description.ToLower()));
                    if (current_product.Count() > 0)
                    {
                        int count = 1;
                        foreach (Product name in current_product)
                        {
                            Console.Write($"{count++} :");
                            Print.PrintProducts(name.Name);
                        }
                        Console.WriteLine($"Всего совпадений : {current_product.Count()}");
                    }
                    else
                    {
                        Console.WriteLine("Ничего не найдено");
                    }
                    break;
                case 3:
                    double currnet_price = Print.GetDoubleInput("Введи цену, по которой искать");
                    current_product = _products.Where(x => x.Price == currnet_price);
                    if (current_product.Count() > 0)
                    {
                        int count = 1;
                        foreach (Product name in current_product)
                        {
                            Console.WriteLine($"{count++} :");
                            Print.PrintProducts(name.Name);
                        }
                        Console.WriteLine($"Всего совпадений : {current_product.Count()}");
                    }
                    else
                    {
                        Console.WriteLine("Ничего не найдено");
                    }
                    break;
                case 4:
                    int currnet_quantuty = Print.GetIntInput("Введи колличество, по которому искать");
                    current_product = _products.Where(x => x.Quantity == currnet_quantuty);
                    if (current_product.Count() > 0)
                    {
                        int count = 1;
                        foreach (Product name in current_product)
                        {
                            Console.WriteLine($"{count++} :");
                            Print.PrintProducts(name.Name);
                        }
                        Console.WriteLine($"Всего совпадений : {current_product.Count()}");
                    }
                    else
                    {
                        Console.WriteLine("Ничего не найдено");
                    }
                    break;
                case 5:
                    string current_structure = Print.GetInput("Введите элемент состава продукта по которому искать совпадения");
                    int i = 0;
                    int couner_equaly = 0;
                    foreach (Product product in ProductManager.GetProducts())
                    {
                        int lenght = Product.GetLenghtStructure(product.Name);
                        for (int k = 0; k < lenght; ++k)
                        {
                            if (product[k].ToLower() == current_structure.ToLower())
                            {
                                Print.PrintProducts(product.Name);
                                ++couner_equaly;
                            }

                        }
                    }
                    if (couner_equaly > 0)
                    {
                        Console.WriteLine($"Всего совпадений : {couner_equaly}");
                    }
                    else
                    {
                        Console.WriteLine("Совпадений не найдено");
                    }
                    break;
                default:
                    Console.WriteLine("Некорректный ввод");
                    break;
            }
        }
    }
}
