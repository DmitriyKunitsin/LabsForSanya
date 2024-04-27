namespace CovarianceAndContravarianceOfDelegates
{
    internal class Program
    {//Делегаты могут быть ковариантными и контравариантными.
     //Ковариантность делегата предполагает, что возвращаемым типом может быть производный тип.
     //Контрвариантность делегата предполагает, что типом параметра может быть более универсальный тип.

        /// <summary>delegate Message MessageBuilder(string text);</summary>
        /// <param name="text">The text.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        delegate Message MessageBuilder(string text);

        /// <summary>delegate void EmailReceiver(EmailMessage message);</summary>
        /// <param name="message">The message.</param>
        delegate void EmailReceiver(EmailMessage message);


        /// <summary>delegate T MessageBuilder&lt;out T&gt;(string message);</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">The message.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        delegate T MessageBuilder<out T>(string message);

        /// <summary>delegate void MessageReceiver&lt;in T&gt;(string message);</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">The message.</param>
        delegate void MessageReceiver<in T>(T message);

        delegate E MessageConverter<in M, out E>(M message);
        static void Main(string[] args)
        {
            Console.WriteLine("\nКовариантность\n");

            //Ковариантность позволяет передать делегату метод,
            //возвращаемый тип которого является производный от возвращаемого типа делегат.
            //То есть если возвращаемый тип делегата Message,
            //то у метод может иметь в качестве возвращаемого типа класс EmailMessage

            // делегату с базовым типом передаем метод с производным типом
            MessageBuilder messageBuilder = WriteEmailMessage; // ковариантность
            Message message = messageBuilder("Hello Ковариантность");
            message.Print(); // Email: Hello Ковариантность
            //Здесь делегат MessageBuilder возвращает объект Message.
            //Однако благодаря ковариантности данный делегат может указывать на метод,
            //который возвращает объект производного типа, например, на метод WriteEmailMessage.

            EmailMessage WriteEmailMessage(string text) => new EmailMessage(text);

            Console.WriteLine("\nКонтрвариантность\n");
            //Контрвариантность позволяет присваить делегату метод,
            //тип параметра которого является более универсальным по отношению
            //к типу параметра делегата. Например, возьмем выше определенные
            //классы Message и EmailMessage и используем их в следующем примере:
            EmailReceiver emailReceiver = ReceiverMessage;
            emailReceiver(new EmailMessage("Welcome Контрвариантность"));

            void ReceiverMessage(Message message) => message.Print();

            Console.WriteLine("\nКовариантность и контравариантность в обобщенных делегатах\n");
            //Обобщенные делегаты также могут быть ковариантными и контравариантными,
            //что дает нам больше гибкости в их использовании.
            Console.WriteLine("Ковариантность");
            //Ковариантность
            // Например, объявим и используем ковариантный обобщенный делегат:
            //delegate T MessageBuilder<out T>(string text);
            //Благодаря использованию out мы можем присвоить делегату типа MessageBuilder<Message> (более общий тип)
            //делегат типа MessageBuilder<EmailMessage> (более конкретный тип).

            // возвращает EmailMessage - более конкретный тип
            MessageBuilder<EmailMessage> emailMessageWriter = (string message) => new EmailMessage(message);

            // возвращает более общий тип Message
            MessageBuilder<Message> mesageBuilder = emailMessageWriter;// ковариантность

            Message message1 = mesageBuilder("Hello обощенный делегат");
            message1.Print();


            //Контравариантность
            //Рассмотрим контравариантный обобщенный делегат:
            Console.WriteLine("Контравариантность");

            // принимает объект более общего типа
            MessageReceiver<Message> messageReceiver = (Message mes) => mes.Print();
            // принимает объект более конкретного типа
            MessageReceiver<EmailMessage> emailMessageReceiver = messageReceiver;// контравариантность

            messageReceiver(new Message("Hello new Message"));// Message: Hello new Message!
            messageReceiver(new EmailMessage("Hello new EmailMEssage")); // Email: new EmailMEssage!
            //Использование ключевого слова in позволяет присвоить делегату
            //с производным типом (MessageReceiver<EmailMessage>)
            //делегат с базовым типом (MessageReceiver<Message>).


            //То есть, если грубо обобщить,
            //ковариантность - это от более производного к более общему типу (EmailMessage -> Message),
            //а контрвариантность - от более общего к более производному типу (Message -> EmailMessage).

            Console.WriteLine("\nСовмещение ковариантности и контрвариантности\n");

            //Причем делегат может одновременно использовать оба оператора: in и out. Например:

            // делегат может одновременно использовать оба оператора: in и out. Например:
            //delegate E MessageConverter<in M, out E>(M message);
            //- E - это тип данных, который будет возвращаться методом delegate после преобразования сообщения типа M.
            // -M - это тип данных сообщения, которое будет передаваться методу delegate для преобразования.

            MessageConverter<Message, EmailMessage> toEmailConverter = (Message mes1) => new EmailMessage(mes1.Text);

            MessageConverter<SmsMessage, Message> converter = toEmailConverter;
            Message message2 = converter(new SmsMessage("Hello SmsMessage"));
            message2.Print();// Email: Hello SmsMessage
            /*Здесь делегат MessageConverter представляет условное действие, которое конвертирует объект типа M в тип E.
            В программе определена переменная converter, которая представляет тип MessageConverter<SmsMessage, Message> - 
            то есть конвертер из типа SmsMessage в любой тип Message, 
            грубо говоря преобразует смс в любой другой тип сообщения.
            Этой переменной можно передать действие - toEmailConverter, 
            которое из сообщений любого типа создает объект Email-сообщения. 
            Здесь применяется контравариантность: для параметра вместо производного типа SmsMessage
            применяется базовый тип Message. И также есть ковариантность:
            вместо возвращаемого типа Message используется производный тип EmailMessage.*/

        }

        //Рассмотрим ковариантность и контравариантность на примере следующих классов:
        class Message
        {//класс Message представляет некоторое сообщение и определяет свойство Text для хранения текста сообщения,
         //который устанавливается через конструктор
            public string Text { get; }
            public Message(string text) => Text = text;
            public virtual void Print() => Console.WriteLine($"Message : {Text}");
        }

        class EmailMessage : Message
        {// Класс EmailMessage представляет email-сообщение
            public EmailMessage(string text) : base(text) { }

            public override void Print() => Console.WriteLine($"Email : {Text}");
        }

        class SmsMessage : Message
        {//SmsMessage - смс-сообщение
            public SmsMessage(string text) : base(text) { }

            public override void Print() => Console.WriteLine($"Sms : {Text}");
        }


    }
}
