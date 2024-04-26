using System.Threading.Channels;

namespace LessonDelegate
{
    internal class Program
    {
        enum OperationType
        {
            Add, Subtract, Multiply
        }

        /*Делегат Message в качестве возвращаемого типа имеет тип void (то есть ничего не возвращает) и не принимает никаких параметров. 
         * Это значит, что этот делегат может указывать на любой метод, который не принимает никаких параметров и ничего не возвращает.*/
        delegate void Message();// 1. Объявление делегата
        // по сути это указатель на функцию/метод, как в Си я передаю указатель на область памяти переменной

        delegate T GeneralizedDelegates<T, K>(K val); // объявление делегата с двумя обобщенными типами T и K

        delegate int Operation(int x, int y); // Объявляю делегат для работы с классом Math\
        /*В данном случае делегат Operation возвращает значение типа int и имеет два параметра типа int.
         * Поэтому этому делегату соответствует любой метод, который возвращает значение типа int 
         * и принимает два параметра типа int. В данном случае это методы Add и Multiply. 
         * То есть мы можем присвоить переменной делегата любой из этих методов и вызывать*/
        static void Main(string[] args)
        {
            // ВАЖНО
            // методы соответствуют делегату, если они имеют один и тот же возвращаемый тип и один и тот же набор параметров.
            // Делегат может указывать на множество методов, которые имеют туже сигнатуру и возвращаемый тип
            //  Все методы в делегате попадают в специальный список - список вызова или invocation list.
            // И при вызове делегата все методы из этого списка последовательно вызываются.
            // И можно добавлять в этот список не один, а несколько методов.
            // Для добавления методов в делегат применяется операция +=:
            Message mes;//2. Создаю переменную делегата

            mes = Hello; // 3. Присваиваю этой переменной адрес метода 

            mes(); // 4. Вызываю метод

            void Hello() => Console.WriteLine("Hello, World!");

            Message mes2;
            mes2 = Welcome.Print;// Присвоение переменной адреса статического метода Print из класса Welcome

            mes2();// Вызов статического метода Print через делегат

            Message mes3;

            mes3 = new Hello().Print; // Присвоение переменной адреса обычного метода Print из экземпляра класса Hello

            mes3(); //  Вызов обычного метода Print через делегат

            Console.WriteLine("\nДелегат Operation");

            Operation operation1 = new Math().Add;// Передаю указатель на метод Add класса Math

            int resultAdd = operation1(5, 5);

            Console.WriteLine(resultAdd);

            Operation operation2 = new Operation(Math.Multiply);// Передаю указатель на метод Multiply класса Math
            // Есть еще один способ - создание объекта делегата с помощью конструктора, в который передается нужный метод:
            int resultMultiply = operation2(5, 5);
            //Оба способа равноценны.
            Console.WriteLine(resultMultiply);

            Console.WriteLine("\nДобавление методов в делегат (invocation list)");

            Operation operationList = new Math().Add;

            operationList += Math.Multiply; // теперь operationList указывает на два метода
            //  стоит отметить, что в реальности будет происходить создание нового объекта делегата,
            //  который получит методы старой копии делегата и новый метод,
            //  и новый созданный объект делегата будет присвоен переменной operationList.

            int resultInvocedList = operationList(5, 5); // вызываются оба метода - Add и Multiply

            Console.WriteLine("результат последнего добавленного метода Multiply : " + resultInvocedList);
            // выведется результат последнего добавленного метода Multiply

            int[] resultDelegateList = new int[2];// Создаю массив для получения результатов функций из листа методов делегатов
            int count = 0;
            foreach (Operation res in operationList.GetInvocationList())
            {
                resultDelegateList[count++] = res(5, 5);//добавление результатов в int массив
            }

            foreach (int res in resultDelegateList)
            {
                Console.WriteLine(res);// вывод из массива результата методов делегаата
            }

            // Альтернативное решение и упрощенное
            Console.WriteLine("\nАльтернативное решение и упрощенное");
            Delegate[] invocedList = operationList.GetInvocationList();//Получаем из invoced List список вложенных в него методов
            Console.WriteLine($"Длина invoced List {invocedList.Length}");
            for (int i = 0; i < invocedList.Length; ++i)
            {
                Operation resus = (Operation)invocedList[i];
                if (resus is Operation)//Проверка, что полученный из листа делегат имеет тип Operation
                {
                    Console.WriteLine($"result {i + 1} : " + resus(5, 5));
                }
            }
            Console.WriteLine("\nДобавление методов в делегат mes3");
            //При добавлении делегатов следует учитывать, что мы можем добавить ссылку на один и тот же метод несколько раз,
            //и в списке вызова делегата тогда будет несколько ссылок на один и то же метод.
            //Соответственно при вызове делегата добавленный метод будет вызываться столько раз, сколько он был добавлен:
            mes3 += new Hello().Print;
            mes3 += Welcome.Print;
            mes3();

            Console.WriteLine("\nУдаляю один метод Welcome из делегата");
            //При удалении следует учитывать, что если делегат содержит несколько ссылок на один и тот же метод,
            //то операция -= начинает поиск с конца списка вызова делегата и удаляет только первое найденное вхождение.
            //Если подобного метода в списке вызова делегата нет, то операция -= не имеет никакого эффекта.
            mes3 -= Welcome.Print;
            //При удалении методов из делегата фактически будет создаваться новый делегат,
            //который в списке вызова методов будет содержать на один метод меньше.
            if (mes3 != null)
            {// Стоит отметить, что при удалении метода может сложиться ситуация,
             // что в делегате не будет методов, и тогда переменная будет иметь значение null.
                mes3();
            }

            Console.WriteLine("\nОбъединение делегатов mes2 и mes3");
            // В данном случае объект mes3 представляет объединение делегатов mes1 и mes2.
            // Объединение делегатов значит, что в список вызова делегата mes3 попадут все методы из делегатов mes1 и mes2.
            // И при вызове делегата mes3 все эти методы одновременно будут вызваны
            Message unificationDelegates = mes2 + mes3;// сначала в лист добавляется mes2, а потом mes3 в итоге 
            unificationDelegates();// последнее значение mes2 перед началом первого значения mes3

            Console.WriteLine("\nВызов делегата метод Invoke():");
            //Если делегат принимает параметры, то в метод Invoke передаются значения для этих параметров.
            mes -= Hello;// заведомо делаем делегат null
            mes?.Invoke();// ошибки нет, делегат просто не вызывается   
            Operation? delegatForInvoke = Math.Multiply;
            // сегда лучше проверять, не равен ли он null.
            // Либо можно использовать метод Invoke и оператор условного null
            delegatForInvoke -= Math.Multiply;
            Console.WriteLine(delegatForInvoke?.Invoke(5, 5));
            delegatForInvoke += Math.Multiply;
            Console.WriteLine(delegatForInvoke.Invoke(5, 5));

            Console.WriteLine("\nОбобщенные делегаты");
            //Здесь делегат Operation типизируется двумя параметрами типов.
            //Параметр T представляет тип возвращаемого значения.
            //А параметр K представляет тип передаваемого в делегат параметра.
            // delegate T GeneralizedDelegates<T, K>(K val)
            GeneralizedDelegates<decimal, int> squareGeneralizedDelegat = Square;
            decimal resultDelegateDecimal = squareGeneralizedDelegat(5);
            Console.WriteLine("Square : " + resultDelegateDecimal);

            GeneralizedDelegates<int, int> dobleGeneralizedDelegates = Double;
            int resultDelegateDouble = dobleGeneralizedDelegates(5);
            Console.WriteLine("Double : " + resultDelegateDouble);
            // Таким образом, этому делегату соответствует метод,
            // который принимает параметр любого типа и возвращает значение любого типа.
            decimal Square(int n) => n * n;
            int Double(int n) => n + n;

            Console.WriteLine("\nДелегаты как параметры методов");
            //При вызове метода DoOperation мы можем передать в него в качестве третьего параметра метод,
            //который соответствует делегату Operation.
            DoOperation(5, 4, new Math().Add);
            DoOperation(5, 4, Math.Multiply);
            DoOperation(5, 4, Subtract);
            // Здесь метод DoOperation в качестве параметров принимает два числа и некоторое действие в виде делегата
            // Operation. В внутри метода вызываем делегат Operation, передавая ему числа из первых двух параметров
            void DoOperation(int a, int b, Operation op)
            {
                Console.WriteLine("Функция делагата : " + op.Method.Name);
                Console.WriteLine($"на вход метода делегата пришло a ={a}, b={b}");
                Console.WriteLine(op(a, b));
            }

            int Subtract(int a, int b) => a - b;
            int Add(int a, int b) => a + b;
            int Multiply(int a, int b) => a * b;

            Console.WriteLine("\nВозвращение делегатов из метода");

            //При вызове метода SelecteOperation мы можем получить из него нужное действие
            //в переменную selectedOperationDelegate:
            Operation selectedOperationDelegate = SelecteOperation(OperationType.Add);
            Console.WriteLine("Selected Add : " + selectedOperationDelegate(5, 4));//9

            selectedOperationDelegate = SelecteOperation(OperationType.Subtract);
            Console.WriteLine("Selected Subtract : " + selectedOperationDelegate(5, 4));//1

            selectedOperationDelegate = SelecteOperation(OperationType.Multiply);
            Console.WriteLine("Selected Multiply : " + selectedOperationDelegate(5, 4));//20

            Operation SelecteOperation(OperationType opType)
            {//В данном случае метод SelectOperation() в качестве параметра
             //принимает перечисление типа OperationType
                switch (opType)
                {//Это перечисление хранит три константы,
                 //каждая из которых соответствует определенной арифметической операции.
                    case OperationType.Add: return Add;
                    //То есть если параметр метода SelectOperation равен OperationType.Add,
                    //то возвращается метод Add, который выполняет сложение двух чисел
                    case OperationType.Subtract: return Subtract;
                    default: return Multiply;

                }
            }
        }



    }
}

/*При этом делегаты необязательно могут указывать только на методы, которые определены в том же классе, 
 * где определена переменная делегата. Это могут быть также методы из других классов и структур.*/
class Welcome
{ // Класс Welcome содержит статический метод Print, который выводит "Welcome"  
    public static void Print() => Console.WriteLine("Welcome");
}
class Hello
{  // Класс Hello содержит метод Print, который выводит "Hello"
    public void Print() => Console.WriteLine("Hello");
}

class Math
{
    public int Add(int a, int b) => a + b;

    public static int Multiply(int a, int b) => a * b;
}

