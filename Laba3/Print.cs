namespace Laba3
{
    internal class Print
    {
        public static void PrintMenuDepartament()
        {
            Console.WriteLine("1. Отдел электроники");
            Console.WriteLine("2. Отдел вещей");
            Console.WriteLine("3. Отдел игрушек");
            Console.WriteLine("4. Вернуться назад");
        }
        public static void PrintMenu(string name_shop)
        {
            Console.WriteLine($"Магазин : " + name_shop);
            Console.WriteLine("\n\n1. Добавить продукт");
            Console.WriteLine("2. удалить продукт");
            Console.WriteLine("3. Изменить объект");
            Console.WriteLine("4. Поиск объектов по полю");
            Console.WriteLine("5. Показать все продукты");
            Console.WriteLine("6. Показать информацию об одном объекте");
            Console.WriteLine("7. Выход");
        }

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
        public static string GetInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static void WaitingForClick(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey(true);// параметр true скрывает вводимые символы
        }
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
        public static double GetDoubleInput(string message)
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
