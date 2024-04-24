using System.Diagnostics;
using System.Security;

namespace Laba3
{
    internal class Print
    {
        /// <summary>Печатает меню выбора отдела и ожидает ввод от 1 до 3, в случае неудачи повторяет запрос, возвращает номер выбранного отдела</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public static int PrintMenuDepartament()
        {
            Console.WriteLine("1. Отдел электроники");
            Console.WriteLine("2. Отдел вещей");
            Console.WriteLine("3. Отдел игрушек");
            int choice;
            bool isValidValue = false;
            do
            {
                choice = Print.GetIntInput("Выберите отдел магазина");
                if (choice > 0 && choice <= 3)
                {
                    isValidValue = true;
                }

            } while (isValidValue == false);
            return choice;
        }
        /// <summary> Принимает строку с названием магазина и выводи меню для управления</summary>
        /// <param name="name_shop">The name shop.</param>
        public static void PrintMenu(string name_shop)
        {
            Console.WriteLine($"Магазин : " + name_shop);
            Console.WriteLine($"Скидка дня : {Product.DiscountAmount}%");
            Console.WriteLine("\n\n1. Добавить продукт");
            Console.WriteLine("2. удалить продукт");
            Console.WriteLine("3. Изменить объект");
            Console.WriteLine("4. Поиск объектов по полю");
            Console.WriteLine("5. Показать все продукты");
            Console.WriteLine("6. Показать информацию об одном объекте");
            Console.WriteLine("7. Выход");
        }

        /// <summary>Получается объект, получает его отдел и в зависимости от отдела, возвращает строку с названием отдела</summary>
        /// <param name="currentProduct">The current product.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static string GetDepartamentByProduct(Product currentProduct)
        {
            int checkNumberDepartament = (int)currentProduct.Departament;
            string currentDepartamnet = "";
            switch (checkNumberDepartament)
            {
                case 1:
                    currentDepartamnet = "Electronics";
                    break;
                case 2:
                    currentDepartamnet = "Clothing";
                    break;
                case 3:
                    currentDepartamnet = "Toy";
                    break;
            }
            return currentDepartamnet;
        }

        /// <summary>В форме диалога опрашивает в какой отдел добавить продукт и запускает диалог для создания</summary>
        /// <param name="products">The products.</param>
        public static void CreatedSelectedProduct(List<Product> products)
        {
            Console.WriteLine("В какой отдел добавить продукт?");
            int selectedDepartambet = Print.PrintMenuDepartament();
            switch (selectedDepartambet)
            {
                case 1:
                    products.Add(Electronics.AddElectronics());
                    break;
                case 2:
                    products.Add(Clothing.AddClothing());
                    break;
                case 3:
                    products.Add(Toy.AddToy());
                    break;
            }
        }
        /// <summary>Производит нужный опрос и ожидает ответ да или нет, если да, то true, иначе false</summary>
        /// <param name="message">The message.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static bool SurveyIsBoolean(string message)
        {
            bool result = false;
            string answer;
            do
            {
                answer = GetInput(message);
                if (answer.ToLower() == "Да".ToLower())
                {
                    result = true;
                }
                if ((answer != "Да") || (answer != "Нет"))
                {
                    Console.WriteLine("Ответить надо Да/нет, попробуйте снова");
                }
            } while (answer.ToLower() != "да" && answer.ToLower() != "нет");
            return result;
        }
        /// <summary>Получает сообщение, которое необходимо вывести и ждет ввода именно строки, проверяет на валидность данных, в случае не валидности повторяет запрос</summary>
        /// <param name="message">The message.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static string GetInput(string message)
        {
            string inputUser;
            do
            {//Проверка валидности лишней никогда не бывает =))
                Console.WriteLine(message);
                inputUser = Console.ReadLine() ?? string.Empty;
            } while (string.IsNullOrWhiteSpace(inputUser));
            return inputUser;
        }

        /// <summary>Получает строку для вывода и ожидает нажатия клавиши</summary>
        /// <param name="message">The message.</param>
        public static void WaitingForClick(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey(true);// параметр true скрывает вводимые символы
        }
        /// <summary>Печатает меню для выбора параметра в котором необходимо производить поиск, возвращает номер меню</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public static int PrintMenuForSearch()
        {
            int selected = 0;
            Console.WriteLine("Выберите номер поля по которым хотите искать:");
            Console.WriteLine("1. Название");
            Console.WriteLine("2. Описание");
            Console.WriteLine("3. Цена");
            Console.WriteLine("4. Количество");
            Console.WriteLine("5. Состав");
            selected = GetIntInput("");
            return selected;

        }
        /// <summary>Выводи колличество продуктов в магазине и в каждом отделе</summary>
        public static void PrintCountAllDepartamentProduct()
        {
            Console.WriteLine($"Всего продуктов в магазине {Product.CounterProduct}");
            Console.WriteLine($"В отделе электроники {Electronics.Counter}");
            Console.WriteLine($"В отделе вещей {Clothing.Counter}");
            Console.WriteLine($"В отделе игрушек {Toy.Counter}");

        }
        /// <summary>Печатает меню выбора поля, по которому необходимо производить поиск</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public static int PrintMenuForSelectedUpdateProduct()
        {
            int selected = 0;
            Console.WriteLine("Выберите номер поля, которое вы хотите изменить:");
            Console.WriteLine("1. Описание");
            Console.WriteLine("2. Цена");
            Console.WriteLine("3. Количество");
            Console.WriteLine("4. Состав");
            selected = GetIntInput("");
            return selected;
        }
        /// <summary>Получает строку с сообщением и ожидает ввода строки, конвертирует ее в double и возвращает, в случае неудачи повторяет запрос на ввод именно double</summary>
        /// <param name="message">The message.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static double GetDoubleInput(string message)
        {
            bool isValidInput = false;
            int userInput = 0;

            do
            {
                Console.WriteLine(message);
                string input = Console.ReadLine() ?? string.Empty;

                isValidInput = int.TryParse(input, out userInput);

                if (!isValidInput)
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите число.");
                }
            } while (!isValidInput);
            return userInput;
        }
        /// <summary>Получает строку с сообщением и ожидает ввода строки, конвертирует ее в int и возвращает, в случае неудачи повторяет запрос на ввод именно int</summary>
        /// <param name="message">The message.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static int GetIntInput(string message)
        {
            bool isValidInput = false;
            int userInput = 0;

            do
            {
                Console.WriteLine(message);
                string input = Console.ReadLine() ?? string.Empty;

                isValidInput = int.TryParse(input, out userInput);

                if (!isValidInput)
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите целое положительное число.");
                }
                if (userInput <= 0)
                {
                    Console.WriteLine("Ввод должен быть больше 0");
                }

            } while (!isValidInput || userInput <= 0);

            return userInput;
        }
    }
}
