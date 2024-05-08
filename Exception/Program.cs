namespace Exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LessonExOne();
            Console.WriteLine("\n\n");
            LessonExTwo();
            Console.WriteLine("\n\n");
            LessonExThree();
            Console.WriteLine("\n\n");
            SquareLessonTryParse("12");
            SquareLessonTryParse("abc");
            Console.WriteLine("\n\n");
            LessonCatchOne();
            Console.WriteLine("\n\n");
            LessonCatchTwo();
            Console.WriteLine("\n\n");
            Console.WriteLine("Фильтры исключений");
            Console.WriteLine("\n\n");
            FilterException();
            Console.WriteLine("\n\n");
            TypeException();
            Console.WriteLine("\n\n");
            ThrowLessonOne();
            Console.WriteLine("\n\n");
            LessonForRegisterPerson();
            RegisterWorkerTwo();
            Console.WriteLine("\n\n");
        }

        static void LessonExOne()
        {
            try
            {
                Console.WriteLine("Блок try");
                int x = 5;
                int y = 0;
                int result = x / y;
                Console.WriteLine($"reslt = {result}");
            }
            catch
            {
                Console.WriteLine("Возникло исключение");
            }
            finally
            {
                Console.WriteLine("Блок finaly");
            }
            Console.WriteLine("Конец программы");

        }
        static void LessonExTwo()
        {
            try
            {
                Console.WriteLine("Блок try");
                int x = 5;
                int y = 0;
                int result = x / y;
                Console.WriteLine($"reslt = {result}");
            }
            catch
            {
                Console.WriteLine("Возникло исключение");

            }
            Console.WriteLine("Конец программы");
        }
        static void LessonExThree()
        {
            try
            {
                Console.WriteLine("Блок try");
                int x = 5;
                int y = 10;
                int result = x / y;
                Console.WriteLine($"reslt = {result}");
            }
            finally
            {
                Console.WriteLine("Блок finaly");
            }
            Console.WriteLine("Конец программы");
        }

        static void SquareLessonTryParse(string data)
        {//Метод int.TryParse() возвращает true,
         //если преобразование можно осуществить,
         //и false - если нельзя.
            if (int.TryParse(data, out int result))
            {
                Console.WriteLine($"Квадрат числа {result}: {result * result}");
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
            }
        }

        static void LessonCatchOne()
        {
            try
            {
                Console.WriteLine("Блок try");
                int x = 5;
                int y = 0;
                int result = x / y;
                Console.WriteLine($"reslt = {result}");
            }
            catch (DivideByZeroException)
            {//обработаем только исключения типа DivideByZeroException
                //Однако если в блоке try возникнут исключения каких-то других типов,
                //отличных от DivideByZeroException, то они не будут обработаны.
                Console.WriteLine("Возникло исключение DivideByZeroException");
            }
        }

        static void LessonCatchTwo()
        {
            try
            {
                Console.WriteLine("Блок try");
                int x = 5;
                int y = 0;
                int result = x / y;
                Console.WriteLine($"reslt = {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Возникло исключение, сообщение : {ex.Message}");
            }
        }

        static void FilterException()
        {
            int x = 5;
            int y = 0;
            try
            {
                Console.WriteLine("Блок try");
                int result = x / y;
                Console.WriteLine($"reslt = {result}");
            }
            catch (DivideByZeroException) when (y == 0)
            {
                Console.WriteLine("y не должен быть равен 0");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void TypeException()
        {
            int x = 5;
            int y = 0;
            try
            {
                Console.WriteLine("Блок try");
                int result = x / y;
                Console.WriteLine($"reslt = {result}");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Исключение : {ex.Message}");
                Console.WriteLine($"Метод : {ex.TargetSite}");
                Console.WriteLine($"Трассировка стека : {ex.StackTrace}");
            }
        }

        static void ThrowLessonOne()
        {
            try
            {

                Console.WriteLine("Введите имя");
                string? name = "dd";
                Console.WriteLine(name);
                if (name == null || name.Length < 3)
                {
                    throw new System.Exception("Длина имени меньше 2 символов");
                }
                else
                {
                    Console.WriteLine($"Ваше имя : {name}");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Ошибка : {ex.Message}");
            }
        }

        static void LessonForRegisterPerson()
        {
            try
            {
                Person person = new Person { Name = "Dima", Age = 16 };
            }
            catch (PersonException ex)
            {
                Console.WriteLine($"Ошибка : {ex.Message}");
            }


        }
        class PersonException : System.Exception
        {
            public PersonException(string message) : base(message) { }
        }
        class Person
        {
            int age;
            public string Name { get; set; }
            public int Age
            {
                get => age;
                set
                {
                    if (18 > value)
                    {
                        throw new PersonException("Лицам до 18 регистрация запрещена");
                    }
                    else
                    {
                        age = value;
                    }
                }
            }
        }

        class Worker
        {
            private int age;
            public string Name { get; set; } = "";
            public int Age
            {
                get => age;
                set
                {
                    if (value < 18)
                        throw new WorkerException("Лицам до 18 регистрация запрещена", value);
                    else
                        age = value;
                }
            }
        }
        class WorkerException : ArgumentException
        {
            public int Value { get; set; }
            public WorkerException(string message, int value) : base(message)
            {
                this.Value = value;
            }
        }
        static void RegisterWorkerTwo()
        {
            try
            {
                Worker person = new Worker { Name = "Dima", Age = 16 };
            }
            catch (WorkerException ex)
            {
                Console.WriteLine($"Ошибка : {ex.Message}");
                Console.WriteLine($"Недопустимый возраст : {ex.Value}");
            }


        }
    }
}
