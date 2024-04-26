using static Events.Program;

namespace Events
{
    internal class Program
    {//События сигнализируют системе о том, что произошло определенное действие.
     //И если нам надо отследить эти действия, то как раз мы можем применять события.

        //События объявляются в классе с помощью ключевого слова event,
        //после которого указывается тип делегата, который представляет событие:
        //В данном случае вначале определяется делегат AccountHandler,
        //который принимает один параметр типа string.
        //Затем с помощью ключевого слова event определяется событие с именем Notify,
        //которое представляет делегат AccountHandler.
        static void Main(string[] args)
        {
            Account account = new Account(100);
            account.NotifyRed += DisplayMessage;
            account.NotifyRed += DisplayRedMessage;
            account.Put(20);    // добавляем на счет 20
            Console.WriteLine($"Сумма на счете: {account.Sum}");
            account.Take(70);   // пытаемся снять со счета 70
            Console.WriteLine($"Сумма на счете: {account.Sum}");
            account.NotifyRed -= DisplayRedMessage;
            account.Take(180);  // пытаемся снять со счета 180
            Console.WriteLine($"Сумма на счете: {account.Sum}");

            //В качестве обработчиков могут использоваться не только обычные методы,
            //но также делегаты, анонимные методы и лямбда-выражения. Использование делегатов и методов:
            Account acc = new Account(100);
            // установка делегата, который указывает на метод DisplayMessage
            acc.NotifyRed += new Account.AccountHandler(DisplayMessage);
            // установка в качестве обработчика метода DisplayMessage

            acc.NotifyRed += DisplayMessage;// добавляем обработчик DisplayMessage

            acc.Put(20);// добавляем на счет 20

            //Установка в качестве обработчика анонимного метода:
            //Account acc = new Account(100);
            //acc.Notify += delegate (string mes)
            //{
            //    Console.WriteLine(mes);
            //};
            //acc.Put(20);

            //Установка в качестве обработчика лямбда - выражения:
            //Account account = new Account(100);
            //account.Notify += message => Console.WriteLine(message);
            //account.Put(20);

            //В данном случае в качестве обработчика используется метод DisplayMessage,
            //который соответствует по списку параметров и возвращаемому типу делегату AccountHandler.
            //В итоге при вызове события Notify?.Invoke() будет вызываться метод DisplayMessage,
            //которому для параметра message будет передаваться строка, которая передается в Notify?.Invoke().
            //В DisplayMessage просто выводим полученное от события сообщение, но можно было бы определить любую логику.
            void DisplayMessage(string message) => Console.WriteLine(message);

            void DisplayRedMessage(string message)
            {
                // Устанавливаем красный цвет символов
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                // Сбрасываем настройки цвета
                Console.ResetColor();
            }

            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("\nПередача данных события\n");

            Account_two account_Two = new Account_two(200);
            account_Two.Notify += NewDisplayMessage;
            account_Two.Put(20);
            account_Two.Take(200);
            account_Two.Take(30);

            void NewDisplayMessage(Account_two sender, AccountEventArgs e)
            {
                Console.WriteLine($"Сумма транзакции: {e.Sum}");
                Console.WriteLine(e.Message);
                Console.WriteLine($"Текущая сумма на счете: {sender.Sum}");
            }
            
        }
        //Например, возьмем следующий класс, который описывает банковский счет:
        public class Account
        {
            public delegate void AccountHandler(string message);
            //public event AccountHandler Notify;// 1.Определение события
            //Теперь опредление события разбивается на две части.
            //Вначале просто определяется переменная делегата,
            //через которую мы можем вызывать связанные обработчики:
            AccountHandler? Notify;
            public event AccountHandler NotifyRed
            {
                add
                {// при операции +=. Добавляемый обработчик доступен через ключевое слово value.
                    Notify += value;
                    Console.WriteLine($"{value.Method.Name} добавлен");
                    //Здесь мы можем получить информацию об обработчике (например, имя метода через value.Method.Name)
                    // и определить некоторую логику
                }
                remove
                {//Блок remove вызывается при удалении обработчика.
                 //Аналогично здесь можно задать некоторую дополнительную логику:
                    Notify -= value;
                    Console.WriteLine($"{value.Method.Name} удален");
                }
            }
            // сумма на счете
            public int Sum { get; private set; }
            // в конструкторе устанавливаем начальную сумму на счете
            public Account(int sum) => Sum = sum;
            // добавление средств на счет
            public void Put(int value)
            {
                Sum += value;
                Notify?.Invoke($"На счет поступило {value}");// 2.Вызов события 

            }

            // списание средств со счета
            public void Take(int value)
            {
                if (Sum >= value)
                {
                    Sum -= value;
                    Notify?.Invoke($"Со счета снято: {value}");// 2.Вызов события
                }
                else
                {
                    Notify?.Invoke($"Недостаточно денег на счете. Текущий баланс: {Sum}");
                }
            }
        }


        public class Account_two
        {
            public delegate void AccountHandler(Account_two message, AccountEventArgs args);
            public event AccountHandler? Notify;


            public int Sum { get; private set; }

            public Account_two(int sum) => this.Sum = sum;

            public void Put(int value)
            {
                Sum += value;
                Notify?.Invoke(this, new AccountEventArgs($"На счет поступило {value}", value));
            }

            public void Take(int value)
            {
                if (Sum >= value)
                {
                    Sum -= value;
                    Notify?.Invoke(this, new AccountEventArgs($"Сумма {value} снята со счета", value));
                }
                else
                {
                    Notify?.Invoke(this, new AccountEventArgs("Недостаточно денег на счете", value));
                }
            }
        }
        public class AccountEventArgs
        {
            // Сообщение
            public string Message { get; }
            // Сумма на которую изменился счет
            public int Sum { get; }
            //Данный класс имеет два свойства:
            //Message - для хранения выводимого сообщения и
            //Sum - для хранения суммы, на которую изменился счет.
            public AccountEventArgs(string message, int sum)
            {
                Message = message;
                Sum = sum;
            }
        }
    }
}
