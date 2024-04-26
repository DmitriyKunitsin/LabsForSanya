using System.Threading.Channels;

namespace UsingDelegates
{
    delegate void MessageHandler(string message);

    delegate int Operation(int a, int b);
    //наиболее сильная сторона делегатов состоит в том, что они позволяют делегировать выполнение некоторому
    //коду извне. И на момент написания программы мы можем не знать, что за код будет выполняться.
    //Мы просто вызываем делегат. А какой метод будет непосредственно выполняться при вызове делегата,
    //будет решаться потом.
    internal class Program
    {
        static void Main(string[] args)
        {


            Account account = new Account(200);

            //Здесь через метод RegisterHandler переменной taken в классе Account передается ссылка на метод PrintSimpleMessage.
            //Этот метод соответствует делегату AccountHandler.
            //Соответственно там, где в классе Account вызывается делегат taken,
            //в реальности будет выполняться метод PrintSimpleMessage.
            account.RegisterHandler(PrintSimpleMessage);

            account.Take(100);

            account.Take(150);
            //Через параметр message метод PrintSimpleMessage получит переданное из делегата сообщение
            //и выведет его на консоль:
            void PrintSimpleMessage(string message) => Console.WriteLine(message);
            void PrintColorMessage(string message)
            {
                // Устанавливаем красный цвет символов
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                // Сбрасываем настройки цвета
                Console.ResetColor();
            }

            Console.WriteLine("\nДобавление и удаление методов в делегате\n");

            AccountAddAndRemoveDelegates account2 = new AccountAddAndRemoveDelegates(200);

            account2.RegisterHandler(PrintSimpleMessage);
            //В целях тестирования создал еще один метод - PrintColorMessage,
            //который выводит то же самое сообщение только красным цветом.
            //Ссылка на этот метод также передается в метод RegisterHandler,
            //и таким образом ее получит переменная taken
            account2.RegisterHandler(PrintColorMessage);

            account2.Take(100);
            account2.Take(150);

            account2.UnregisterHandler(PrintColorMessage);
            /*Этот метод удаляется из списка вызовов делегата, 
             * поэтому этот метод больше не будет срабатывать. */

            account2.Take(50);


            Console.WriteLine("\nАнонимные методы\n");
            //С делегатами тесно связаны анонимные методы.
            //Анонимные методы используются для создания экземпляров делегатов.
            //delegate(параметры)
            //{

            //}
            MessageHandler handler = delegate (string message)
            {
                Console.WriteLine(message);
            };
            handler("handler");

            Console.WriteLine("\nПередача в качестве аргумента для параметра\n");
            // Другой пример анонимных методов - передача в качестве аргумента для параметра, который представляет делегат:
            static void ShowMessage(string message, MessageHandler handler)
            {
                handler(message);
            }

            ShowMessage("Hello delegat", handler);


            MessageHandler handlerAnonimus = delegate
            {
                Console.WriteLine("\nАнонимный метод\n");
            };

            handlerAnonimus("Anonim method");// анонимный метод

            Console.WriteLine("\nВозвращение результата анонимным методом\n");

            Operation operation = delegate (int a, int b)
            {
                return a + b;
            };

            int resultAnonimReturnDelegate = operation(5, 5);
            Console.WriteLine($"Результат Возращенного значения ананонимного Делегата : {resultAnonimReturnDelegate}");

            int z = 8;

            Operation operationAddZ = delegate (int a, int b)
            {
                return (a + b + z);
            };
            int resultABZ = operationAddZ(5, 5);
            Console.WriteLine($"Результат возращенного значения ананонимного Делегата с дополнительной переменной +8: {resultABZ}");



        }

    }

    public delegate void AccountHandler(string message);
    //класс, описывающий счет в банке
    public class Account
    {
        /*Для делегирования действия здесь определен делегат AccountHandler. 
         * Этот делегат соответствует любым методам, которые имеют тип void и принимают параметр типа string.*/
        // Переменная для хранения суммы
        int sum;
        // Создаем переменную делегата
        AccountHandler? taken;
        // через конструктор устанавливается начальная сумма на счете
        public Account(int sum) => this.sum = sum;
        // Регистрируем делегат
        public void RegisterHandler(AccountHandler del) => this.taken = del;

        // добавить средства на счет
        public void Add(int value) => this.sum += value;
        // взять деньги с счета
        public void Take(int sum)
        {
            if (this.sum >= sum)
            {
                this.sum -= sum;
                // вызываем делегат, передавая ему сообщение
                taken?.Invoke($"Со счета списано {sum}y.e.");
            }
            else
            {
                taken?.Invoke($"Недостаточно средствю Баланс: {this.sum}y.e.");
            }
        }
    }

    public class AccountAddAndRemoveDelegates
    {
        int sum;

        AccountHandler? taken;

        public AccountAddAndRemoveDelegates(int sum) => this.sum = sum;
        // Регистрируем делегат
        public void RegisterHandler(AccountHandler del) => this.taken += del;

        // Отмена регистрации делегата
        public void UnregisterHandler(AccountHandler del) => this.taken -= del;

        public void Add(int sum) => this.sum += sum;
        public void Take(int sum)
        {
            if (this.sum >= sum)
            {
                this.sum -= sum;
                taken?.Invoke($"Со счета списано {sum} у.е.");
            }
            else
                taken?.Invoke($"Недостаточно средств. Баланс: {this.sum} у.е.");
        }
    }
}
