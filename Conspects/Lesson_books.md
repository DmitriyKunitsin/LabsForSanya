# Шпаргалка по C#

# Методы класса System.String
| Метод                     | Описание                                      |
|---------------------------|-----------------------------------------------|
| Length                  | Возвращает количество символов в строке.     |
| Compare()| Сравнивает две строки. Статический метод|
| Contains() | Поиск подстроки в строке|
| Equals() | Поверяется являются ли две строки эквивалентными|
| Format() | Форматирование строки. Статический метод |
| Insert() | Позволяет вставить строку внутрь другой строки |
| PadLeft(), ParRight() | Позволяет подолнить строку какиеми-то символами |
| Remove() | Удаление СИМВОЛОВ из строки |
| Replace() | Замена символов в строке |
| Split()  | Разделение строк на подстроки |
| Trim() | Удаляет все вхождения определнного набора символов с начала и конца текущей строки | 
| Substring(int startIndex) | Возвращает подстроку, начиная с заданного индекса. |
| IndexOf(string value)   | Возвращает индекс первого вхождения указанной строки. |
| ToLower()               | Преобразует строку в нижний регистр.         |
| ToUpper()               | Преобразует строку в верхний регистр.        |


# Сравнение строк 
| Синтаксис | Описание |
|-----------------------|---------------------------|
| public override bool Equals(object obj)                                                 | Возвращает true, если вызывающая строка содержит ту же последовательность символов, что и строковое представление объекта obj. Порядковое сравнение с учетом регистра. |
| public bool Equals(string value)                                                         | Возвращает true, если вызывающая строка содержит ту же последовательность символов, что и строка value. Порядковое сравнение с учетом регистра.                      |
| public bool Equals(string value, StringComparison comparisonType)                       | Возвращает true, если вызывающая строка содержит ту же последовательность символов, что и строка value. Параметр comparisonType определяет способ сравнения.       |
| public static bool Equals(string a, string b)                                          | Возвращает true, если строка a содержит ту же последовательность символов, что и строка b. Порядковое сравнение с учетом регистра.                                 |
| public static bool Equals(string a, string b, StringComparison comparisonType)        | Возвращает true, если строка a содержит ту же последовательность символов, что и строка b. Параметр comparisonType определяет способ сравнения.                  |

## Замечания
- Все методы выполняют порядковое сравнение с учетом регистра.
- Параметры локализации не учитываются.
- Использование параметра comparisonType позволяет настроить способ сравнения строк (например, игнорирование регистра и т.д.).


# Поиск по строке 

| Метод                                                                                     | Описание                                                                                                                                                               |
|-------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| public bool Contains(string value)                                                     | Определяет, содержится ли подстрока value в вызывающей строке. Возвращает true, если подстрока найдена, иначе возвращает false.                                 |
| public bool StartsWith(string value)                                                   | Определяет, начинается ли вызывающая строка с подстроки value. Возвращает true, если начинается, иначе возвращает false.                                        |
| public bool StartsWith(string value, StringComparison comparisonType)                 | Определяет, начинается ли вызывающая строка с подстроки value, используя заданный способ сравнения.                                                                  |
| public bool EndsWith(string value)                                                     | Определяет, заканчивается ли вызывающая строка подстрокой value. Возвращает true, если заканчивается, иначе возвращает false.                                   |
| public bool EndsWith(string value, StringComparison comparisonType)                   | Определяет, заканчивается ли вызывающая строка подстрокой value, используя заданный способ сравнения.                                                               |
| public int IndexOf(char value)                                                         | Находит первое вхождение символа value в строке. Возвращает индекс первого вхождения или -1, если не найдено.                                                      |
| public int IndexOf(string value)                                                       | Находит первое вхождение подстроки value в строке. Возвращает индекс первого вхождения или -1, если не найдено.                                                    |
| public int IndexOf(char value, int startIndex)                                        | Находит первое вхождение символа value, начиная с позиции startIndex.                                                                                             |
| public int IndexOf(string value, int startIndex)                                      | Находит первое вхождение подстроки value, начиная с позиции startIndex.                                                                                           |
| public int IndexOf(char value, int startIndex, int count)                            | Находит первое вхождение символа value, начиная с позиции startIndex и охватывая количество элементов, определяемых параметром count.                           |
| public int IndexOf(string value, int startIndex, int count)                          | Находит первое вхождение подстроки value, начиная с позиции startIndex и охватывая количество элементов, определяемых параметром count.                         |
| public int LastIndexOf(char value)                                                     | Находит последнее вхождение символа value в строке.                                                                                                                |
| public int LastIndexOf(string value)                                                   | Находит последнее вхождение подстроки value в строке.                                                                                                              |
| public int LastIndexOf(char value, int startIndex)                                    | Находит последнее вхождение символа value, начиная с позиции startIndex.                                                                                         |
| public int LastIndexOf(string value, int startIndex)                                  | Находит последнее вхождение подстроки value, начиная с позиции startIndex.                                                                                        |
| public int IndexOfAny(char[] anyOf)                                                   | Находит первое вхождение любого из символов из массива anyOf в строке. Возвращает индекс первого вхождения или -1, если не найдено.                                |
| public int IndexOfAny(char[] anyOf, int startIndex)                                   | Находит первое вхождение любого из символов из массива anyOf, начиная с позиции startIndex.                                                                        |
| public int IndexOfAny(char[] anyOf, int startIndex, int count)                       | Находит первое вхождение любого из символов из массива anyOf, начиная с позиции startIndex и охватывая количество элементов, определяемых параметром count.     |
| **Поиск нескольких символов**                                                             | Для поиска первого вхождения одного из символов можно использовать метод с перебором или LINQ для определения первого вхождения любого из заданных символов.         |

## Замечания
- Все методы выполняют порядковое сравнение с учетом регистра.
- Параметры локализации не учитываются.
- Использование параметра comparisonType позволяет настроить способ сравнения строк (например, игнорирование регистра и т.д.).

# Конкатенация строк 

Переменные типа string можно соединить вместе, то есть выполнить конкатенацию. Для этого используется оператор +. Конмпилятор C# преобразует оператор + в вызов метода String.Concat(), поэтому можно использовать + или метод Concat() 

Метод Concat() объявлен так:
```
    public static string Concat(string str0, string str1);
    public static string Concat(params string[] values);
```
Пример использования
```
string s1 = "s1";
string s2 = "s2";
string s3 = s1 + s2;
string s4 = String.Concat(s1, s2);
Console.WriteLine(s3);
Console.WriteLine(s4);
```
```
string[] words = { "Солнце", "светит", "ярко", "сегодня." };

// Используем метод Concat для объединения массива строк
string result = string.Concat(words);// Вывод: Солнцесветитяркосегодня.

Console.WriteLine(result);
```
```
 string[] words = { "Солнце", "светит", "ярко", "сегодня." };
        
// Используем метод Join для объединения с пробелами
string result = string.Join(" ", words);
        
Console.WriteLine(result); // Вывод: Солнце светит ярко сегодня.
```

# Разделение и соединение строк
## Метод Split()
Представим, что есть строкаЮ содержащая какой-то разделитель (сепаратор). С помощью метода Split() можно разделить эту строку на подстроки.

Основные формы метода Split:
```
public string[] Split(params char[] separator);
public string[] Split(params char[] separator, int count);
```
- separator: массив символов, который используется для разделения строки.
- Если массив separator пуст или ссылается на пустую строку, в качестве разделителя используется пробел.
- Во второй форме возвращается количество подстрок, заданное параметром count.
### Пример 1: Использование Split с одним разделителем
```
using System;

class Program
{
    static void Main()
    {
        string text = "Привет, мир! Как дела?";
        char[] separators = { ' ', ',', '!' };
        
        // Разделяем строку на подстроки
        string[] result = text.Split(separators);
        
        foreach (var word in result)
        {
            Console.WriteLine(word);
        }
    }
}

```
### Пример 2: Использование Split с ограничением количества подстрок
```
using System;

class Program
{
    static void Main()
    {
        string text = "Раз, два, три, четыре, пять";
        char[] separators = { ',' };
        
        // Разделяем строку с ограничением на количество подстрок
        string[] result = text.Split(separators, 3);
        
        foreach (var part in result)
        {
            Console.WriteLine(part);
        }
    }
}
```

### Другие формы метода Split
```
public string[] Split(params char[] separator, StringSplitOptions options);
public string[] Split(string[] separator, StringSplitOptions options);
public string[] Split(params char[] separator, int count, StringSplitOptions options);
public string[] Split(string[] separator, int count, StringSplitOptions options);
```
- options: параметр типа StringSplitOptions, который может принимать значения:
- None: пустые строки включаются в результат.
- RemoveEmptyEntries: пустые строки исключаются из результата.

### Пример 3: Использование Split с опцией RemoveEmptyEntries
```
using System;

class Program
{
    static void Main()
    {
        string text = "A,,B,C,,D";
        char[] separators = { ',' };
        
        // Разделяем строку и исключаем пустые строки
        string[] result = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}
```

## Метод Join()
Метод Join используется для объединения массива строк в одну строку с указанным разделителем.

### Формы метода Join
```
public static string Join(string separator, string[] value);
public static string Join(string separator, string[] value, int startIndex, int count);
```
- separator: строка, которая будет использоваться как разделитель.
- value: массив строк, которые нужно объединить.
- Во второй форме также возвращается строка из определенного количества элементов массива value, начиная с элемента value[startIndex].

### Пример 4: Использование Join для объединения строк
```
using System;

class Program
{
    static void Main()
    {
        string[] words = { "Солнце", "светит", "ярко" };
        
        // Объединяем строки с пробелом как разделителем
        string result = string.Join(" ", words);
        
        Console.WriteLine(result); // Вывод: Солнце светит ярко
    }
}
```
### Пример 5: Использование Join с указанием индекса и количества
```
using System;

class Program
{
    static void Main()
    {
        string[] words = { "A", "B", "C", "D", "E" };
        
        // Объединяем только часть массива
        string result = string.Join(",", words, 1, 3);
        
        Console.WriteLine(result); // Вывод: B,C,D
    }
}
```

#  Заполнение и обрезка строк
## Обрезка строк 
## Метод Trim()
Метод Trim() позволяет удалять все вхождения определенного набора символов с начала и конца текущей строки.
### Синтаксис
```
public string Trim();
public string Trim(params char[] trimChars);
```
- Первая форма удаляет начальные и конечные пробелы.
- Вторая форма удаляет начальные и конечные вхождения символов из массива trimChars.

### Пример 1: Использование Trim()
```
using System;

class Program
{
    static void Main()
    {
        string text = "   Привет, мир!   ";
        
        // Удаляем пробелы
        string trimmedText = text.Trim();
        
        Console.WriteLine($"'{trimmedText}'"); // Вывод: 'Привет, мир!'
    }
}
```
### Пример 2: Использование Trim(char[])
```
using System;

class Program
{
    static void Main()
    {
        string text = "---Привет, мир!---";
        char[] trimChars = { '-', '!' };
        
        // Удаляем символы '-' и '!'
        string trimmedText = text.Trim(trimChars);
        
        Console.WriteLine($"'{trimmedText}'"); // Вывод: 'Привет, мир'
    }
}
```

## Метод PadLeft()
Метод PadLeft() позволяет дополнить строку символами слева.
### Синтаксис
```
public string PadLeft(int totalWidth);
public string PadLeft(int totalWidth, char paddingChar);
```
- Первая форма дополняет строку пробелами до указанной ширины totalWidth.
- Вторая форма позволяет указать символ заполнения.
### Пример 3: Использование PadLeft()
```
using System;

class Program
{
    static void Main()
    {
        string text = "42";
        
        // Дополняем строку пробелами до длины 5
        string paddedText = text.PadLeft(5);
        
        Console.WriteLine($"'{paddedText}'"); // Вывод: '   42'
    }
}
```
### Пример 4: Использование PadLeft(char)
```
using System;

class Program
{
    static void Main()
    {
        string text = "42";
        
        // Дополняем строку нулями до длины 5
        string paddedText = text.PadLeft(5, '0');
        
        Console.WriteLine($"'{paddedText}'"); // Вывод: '00042'
    }
}
```

## Метод PadRight()

! Метод PadRight() аналогичен PadLeft(), но добавляет символы справа.

# Вставка, удаление и замена строк
## Метод Insert() - Вставка строк
Метод Insert() позволяет вставить строку value в вызывающую строку по индексу startIndex.
### Синтаксис
```
public string Insert(int startIndex, string value);
```
- startIndex — индекс, по которому будет вставлена строка.
- value — строка, которую нужно вставить.
### Пример 1: Использование Insert()
```
using System;

class Program
{
    static void Main()
    {
        string original = "Привет, мир!";
        string toInsert = "доброе утро, ";
        
        // Вставляем строку
        string result = original.Insert(0, toInsert);
        
        Console.WriteLine(result); // Вывод: 'доброе утро, Привет, мир!'
    }
}
```

## Метод Remove() - Удаление строк 
Метод Remove() используется для удаления части строки.

### Синтаксис
```
public string Remove(int startIndex);
public string Remove(int startIndex, int count);
```
- Первая форма удаляет часть строки, начиная с индекса startIndex, до конца строки.
- Вторая форма удаляет count символов, начиная с позиции startIndex.

###  Пример 2: Использование Remove()

```
using System;

class Program
{
    static void Main()
    {
        string original = "Привет, мир!";
        
        // Удаляем часть строки с индекса 7 до конца
        string result1 = original.Remove(7);
        
        Console.WriteLine(result1); // Вывод: 'Привет, '
        
        // Удаляем 6 символов, начиная с индекса 0
        string result2 = original.Remove(0, 7);
        
        Console.WriteLine(result2); // Вывод: ', мир!'
    }
}
```
## Метод Replace() - Замена строк
Метод Replace() позволяет заменять подстроки в строке.
### Синтаксис 
```
public string Replace(char oldChar, char newChar);
public string Replace(string oldValue, string newValue);
```
- Первая форма заменяет все вхождения символа oldChar на символ newChar.
- Вторая форма заменяет все вхождения подстроки oldValue на newValue.
### Пример 3: Использование Replace()
```
using System;

class Program
{
    static void Main()
    {
        string original = "Привет, мир!";
        
        // Заменяем символ 'и' на 'е'
        string result1 = original.Replace('и', 'е');
        
        Console.WriteLine(result1); // Вывод: 'Превет, мир!'
        
        // Заменяем подстроку 'мир' на 'вселенная'
        string result2 = original.Replace("мир", "вселенная");
        
        Console.WriteLine(result2); // Вывод: 'Привет, вселенная!'
    }
}
```

# Управляющие последовательности символов
## Таблица управляющих последовательностей

| Последовательность | Описание                                            |
|--------------------|-----------------------------------------------------|
| `\'`               | Вставляет символ одинарной кавычки                 |
| `\"`               | Вставляет символ двойной кавычки                    |
| `\\`               | Вставляет символ обратной черты                     |
| `\a`               | Заставляет систему воспроизводить звуковой сигнал (beep) |
| `\n`               | Символ новой строки                                 |
| `\r`               | Возврат каретки                                     |
| `\t`               | Вставляет символ табуляции                          |

# Строки и равенство 
Операция равенства предусматривает посимвольную проверку строк с учетом регистра. Проверку равенства двух строк можно произвести или с помощью метода Equals() или с помощью оператора ==.
```
string s1_eq = "s1";
string s2_eq = "s2";
Console.WriteLine("s1 == s2: {0}", s1_eq == s2_eq); // False
Console.WriteLine("s1 == s2: {0}", String.Equals(s1_eq, s2_eq)); // False
```

# тип System.Text.StringBuilder
 System.Text. Внутри этого пространства имен находится класс по имени StringBuilder. В нем
содержатся методы, позволяющие заменять и форматировать сегменты.
- Для использования класса StringBuilder первым делом нужно подключить
пространство имен System.Text:
```using System.Text;```

При вызове членов StringBuilder производится непосредственное измене
ние внутренних символьных данных объекта, а не получение копии этих
данных в измененном формате. При создании экземпляра StringBuilder на
чальные значения для объекта можно задавать с помощью не одного, а не
скольких конструкторов. 
```
StringBuilder sb = new StringBuilder("Операционные системы");
sb.Append("\n");
sb.AppendLine("Windows");
sb.AppendLine("Linux");
sb.AppendLine("Mac OS x");
Console.WriteLine(sb.ToString());
Console.WriteLine("B sb {0} символов", sb.Length);
```

# Пространство имён System.IO ввод / вывод
##  Основные классы из пространства имен System.IO
| Класс                  | Описание                                                                                       |
|------------------------|------------------------------------------------------------------------------------------------|
| **BinaryReader**       | Позволяет читать элементарные типы данных (целочисленные, булевские, строковые и т.п.) в двоичном виде. |
| **BinaryWriter**       | Позволяет записывать элементарные типы данных в двоичном виде.                               |
| **BufferedStream**     | Предоставляет временное хранилище для потока байтов, которые могут быть перенесены в постоянные хранилища. |
| **Directory**          | Используется для манипуляций с каталогами.                                                   |
| **DirectoryInfo**      | Предоставляет информацию о каталоге и его содержимом.                                        |
| **DriveInfo**          | Предоставляет подробную информацию о дисковых устройствах.                                   |
| **File**               | Используется для манипуляций с файлами.                                                      |
| **FileInfo**           | Предоставляет информацию о файле и его свойствах.                                            |
| **FileStream**         | Обеспечивает произвольный доступ к файлу с данными, представленными в виде потока байтов.     |
| **MemoryStream**       | Обеспечивает произвольный доступ к данным, хранящимся в памяти, а не в физическом файле.      |
| **Path**               | Предоставляет информацию о пути к файлу/каталогу.                                            |
| **StreamReader**       | Используется для чтения текстовой информации из файла. Не поддерживает произвольный доступ к файлу. |
| **StreamWriter**       | Используется для записи текстовой информации в файл. Не поддерживает произвольный доступ к файлу. |
| **StringReader**       | Используется для чтения текстовой информации из строкового буфера.                           |
| **StringWriter**       | Используется для записи текстовой информации в строковый буфер.                               |


# Классы для манипуляции с файлами и каталогами
В пространстве имен System.IO определены четыре класса для работы с файлами и каталогами: File, FileInfo, Directory, и DirectoryInfo. Эти классы позволяют выполнять различные операции, такие как создание, удаление, копирование и перемещение файлов и каталогов.

## Классы
### 1. File
Используется для выполнения статических операций с файлами.
**Примеры:**
- Создание файла
- Удаление файла
- Копирование файла
- Перемещение файла
### 2. FileInfo
Предоставляет методы для манипуляций с файлом на уровне экземпляра. Необходимо создавать объект с помощью ключевого слова new.

**Пример**
```
FileInfo fileInfo = new FileInfo("example.txt");
if (fileInfo.Exists)
{
    Console.WriteLine($"File Name: {fileInfo.Name}, Size: {fileInfo.Length} bytes");
}
```
### 3. Directory
Используется для выполнения статических операций с каталогами.

**Примеры:**
- Создание каталога
- Удаление каталога
- Копирование каталога
- Перемещение 

### 4. DirectoryInfo
Предоставляет методы для манипуляций с каталогом на уровне экземпляра.
```
DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Temp");
if (!dirInfo.Exists)
{
    dirInfo.Create(); // Создание каталога
}
```
## Общие свойства класса FileSystemInfo

Классы FileInfo и DirectoryInfo наследуют функциональность от абстрактного базового класса FileSystemInfo. Некоторые полезные свойства:


- **Attributes**: Получает или устанавливает атрибуты файла (например, скрытый, системный).
- **CreationTime**: Время создания файла/каталога.
- **Exists**: Определяет, существует ли файл/каталог.
- **Extension**: Расширение файла.
- **FullName**: Полный путь к файлу/каталогу.
- **LastAccessTime**: Время последнего доступа к файлу/каталогу.
- **LastWriteTime**: Время последней записи в файл/каталог.
- **Name**: Имя файла/каталога.

### Использование класса DirectoryInfo

#### Основные методы:

- **Create()**: Создает каталог.
- **CreateSubdirectory()**: Создает подкаталог.
- **Delete()**: Удаляет каталог вместе с содержимым.
- **GetDirectories()**: Возвращает массив подкаталогов.
- **GetFiles()**: Извлекает массив файлов из текущего каталога.
- **CopyTo()**: Копирует каталог с содержимым.
- **MoveTo()**: Перемещает каталог.

## Классы Stream и FileStream
### Stream
- Абстрактный класс, представляющий поток данных.
- Предоставляет базовые методы для чтения и записи данных.
- Используется как базовый класс для других потоков.
### FileStream
- Наследник класса Stream.
- Используется для чтения и записи данных в файлы.
- Позволяет работать с файлами на диске.
```
using System.IO;

string path = @"C:\Work\example.txt";
using (FileStream fs = File.Open(path, FileMode.Create))
{
    byte[] data = new UTF8Encoding(true).GetBytes("Hello, FileStream!");
    fs.Write(data, 0, data.Length);
}
```

## Классы StreamWriter и StreamReader

### StreamWriter
- Используется для записи текста в поток.
- Кодирует символы в байты с использованием заданной кодировки.
```
using System.IO;

string path = @"C:\Work\output.txt";
using (StreamWriter writer = new StreamWriter(path))
{
    writer.WriteLine("Hello, StreamWriter!");
}
```

### StreamReader
- Используется для чтения текста из потока.
- Декодирует байты в символы с использованием заданной кодировки.
```
using System.IO;

string path = @"C:\Work\output.txt";
using (StreamReader reader = new StreamReader(path))
{
    string content = reader.ReadToEnd();
    Console.WriteLine(content);
}
```

## Классы BinaryWriter и BinaryReader

### BinaryWriter
- Используется для записи примитивных типов данных в двоичном формате.
- Позволяет записывать данные в файл или поток.
```
using System.IO;

string path = @"C:\Work\data.bin";
using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
{
    writer.Write(42); // Записываем целое число
    writer.Write(3.14); // Записываем число с плавающей точкой
}
```
### BinaryReader
- Используется для чтения примитивных типов данных из двоичного формата.
- Позволяет считывать данные из файла или потока.
```
using System.IO;

string path = @"C:\Work\data.bin";
using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
{
    int number = reader.ReadInt32(); // Читаем целое число
    double pi = reader.ReadDouble(); // Читаем число с плавающей точкой
    Console.WriteLine($"Number: {number}, Pi: {pi}");
}
```
# Модификаторы параметров методов

| Модификатор | Описание |
|--------------|----------|
| (отсутствует) | Если модификатор параметра не задан, считается, что он передается по значению. Вызываемый метод получает копию исходных данных. |
| out        | Выходные параметры, которые должны присваиваться вызываемым методом и передаются по ссылке. Если параметры с модификатором out не получают значения в методе, компилятор выдаст ошибку. |
| ref        | Значение первоначально присваивается вызывающим кодом и может быть повторно присвоено в вызываемом методе. Данные также передаются по ссылке. Если параметры с модификатором ref не получают значения в методе, компилятор не будет генерировать ошибку. |
| params     | Позволяет передавать переменное количество аргументов как один логический параметр. Может присутствовать только один модификатор params, который должен быть последним в списке параметров. Используется редко, но встречается в методах базовых классов. |

## 1. Без модификатора (по значению)
```
void ChangeValue(int number)
{
    number = 10; // Изменение не повлияет на исходное значение
}

int originalValue = 5;
ChangeValue(originalValue);
Console.WriteLine(originalValue); // Вывод: 5
```
## 2. Модификатор out
```
void GetValues(out int a, out int b)
{
    a = 1; // Обязательно присваиваем значения
    b = 2;
}

GetValues(out int x, out int y);
Console.WriteLine($"x: {x}, y: {y}"); // Вывод: x: 1, y: 2

```
## 3. Модификатор ref
```
void UpdateValue(ref int number)
{
    number = 20; // Изменение повлияет на исходное значение
}

int value = 5;
UpdateValue(ref value);
Console.WriteLine(value); // Вывод: 20
```
## 4. Модификатор params
```
void PrintNumbers(params int[] numbers)
{
    foreach (var number in numbers)
    {
        Console.WriteLine(number);
    }
}

PrintNumbers(1, 2, 3, 4); // Вывод: 1, 2, 3, 4
PrintNumbers(5, 6);      // Вывод: 5, 6
```

# Интерфейсы, реализуемые в коллекциях
| Интерфейс                       | Описание                                                                                                                                                   |
|----------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ICollection<T>                 | Интерфейс, реализованный классами обобщенных коллекций. Позволяет получить количество элементов в коллекции (свойство Count), копировать коллекцию в массив (метод CopyTo), а также добавлять и удалять элементы (методы Add(), Remove(), Clear()). |
| IEnumerable<T>                 | Необходим для использования оператора foreach. Определяет метод GetEnumerator(), возвращающий перечислитель, реализующий IEnumerator.               |
| ISet<T>                        | Впервые появился в версии .NET 4. Реализуется множествами. Позволяет комбинировать множества в объединения и проверять пересечения. Унаследован от ICollection<T>. |
| IList<T>                       | Предназначен для создания списков, элементы которых доступны по позициям. Определяет индексатор и методы вставки и удаления элементов (Insert(), Remove()). Унаследован от ICollection<T>. |
| IComparer<T>                   | Реализует компаратор и используется для сортировки элементов внутри коллекции с помощью метода Compare().                                               |
| IDictionary<TKey, TValue>      | Реализуется обобщенными классами коллекций, элементы которых состоят из ключа и значения. Позволяет получать доступ ко всем ключам и значениям, извлекать элементы по индексу типа ключа, а также добавлять и удалять элементы. |
| ILookup<TKey, TValue>          | Похож на IDictionary<TKey, TValue>, поддерживает ключи и значения, но может содержать множественные значения для одного ключа.                          |
| IProducerConsumerCollection<T> | Появился в .NET 4. Используется для поддержки новых потокобезопасных классов коллекций.                                                                    |
| IEqualityComparer<T>           | Реализует компаратор, который может быть применен к ключам словаря. Позволяет проверять объекты на эквивалентность друг другу. Поддерживается массивами и кортежами. |

## Пример использования ICollection<T>
```
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        ICollection<int> numbers = new List<int>();
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);
        
        Console.WriteLine("Count: " + numbers.Count); // Вывод: Count: 3
    }
}
```

## Пример использования IEnumerable<T>
```
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        IEnumerable<string> names = new List<string> { "Alice", "Bob", "Charlie" };
        
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
}
```

## Пример использования IDictionary<TKey, TValue>
```
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        IDictionary<int, string> dictionary = new Dictionary<int, string>();
        dictionary.Add(1, "One");
        dictionary.Add(2, "Two");
        
        Console.WriteLine(dictionary[1]); // Вывод: One
    }
}
```

## Пример использования ISet<T>
```
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        ISet<int> set = new HashSet<int>();
        set.Add(1);
        set.Add(2);
        set.Add(2); // Не добавит дубликат
        
        Console.WriteLine("Count: " + set.Count); // Вывод: Count: 2
    }
}
```

## Пример использования IComparer<T>
```
using System;
using System.Collections.Generic;

class StringLengthComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        return x.Length.CompareTo(y.Length);
    }
}

class Program
{
    static void Main()
    {
        List<string> words = new List<string> { "apple", "banana", "kiwi" };
        words.Sort(new StringLengthComparer());
        
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}
```

# Необобщеные коллекции

Такие коллекции представляют собой структуры данных общего назначения, **оперирующие ссылками на объекты**.
Позволяют манипулировать объектом любого типа, хотя и не типизированым способом.

## Интерфейсы, используемые в необобщенных коллекциях

| Интерфейс                       | Описание                                                                                                                                                   |
|----------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ICollection                      | Определяет элементы, которые должны иметь все необобщенные коллекции.                                                                                   |
| IComparer                        | Определяет метод Compare() для сравнения объектов, хранящихся в коллекции.                                                                              |
| IDictionary                      | Определяет коллекцию, состоящую из пар "ключ-значение" (словарь).                                                                                       |
| IDictionaryEnumerator             | Определяет перечислитель для коллекции, реализующей интерфейс IDictionary.                                                                             |
| IEnumerable                      | Определяет метод GetEnumerator(), предоставляющий перечислитель для любого класса коллекции.                                                            |
| Enumerator                       | Предоставляет методы, позволяющие получать содержимое коллекции по очереди.                                                                              |
| IEqualityComparer                | Сравнивает два объекта на предмет равенства.                                                                                                             |
| EqualityComparer<T>                |  предоставляет более гибкие и мощные средства для сравнения объектов и получения их хэш-кодов.                                                                                                        |
| IList                            | Определяет коллекцию, доступ к которой можно получить с помощью индексатора.                                                                              |
| IStructuralComparable             | Содержит метод CompareTo(), применяемый для структурного сравнения.                                                                                    |
| IStructuralEquatable             | Содержит метод Equals(), применяемый для выяснения структурного, а не ссылочного равенства. Кроме того, определяет метод GetHashCode().              |

## Классы необобщенных коллекций

| Класс        | Описание                                                                                           |
|--------------|----------------------------------------------------------------------------------------------------|
| **ArrayList**| Определяет динамический массив. Динамические массивы могут увеличивать свой размер при необходимости. |
| **Hashtable**| Используется для работы с хеш-таблицами для пар "ключ-значение".                                 |
| **Queue**    | Очередь или список, построенный по принципу FIFO (первым зашел — первым вышел).                    |
| **SortedList**| Отсортированный список пар "ключ-значение".                                                      |
| **Stack**    | Стек или список, построенный по принципу LIFO (последним зашел — первым вышел).                   |

## Примеры использования

### ArrayList
```
ArrayList arrayList = new ArrayList();
arrayList.Add(1);
arrayList.Add("Hello");
arrayList.Add(true);
Console.WriteLine(arrayList[1]); // Вывод: Hello
```
### Hashtable
```
Hashtable hashtable = new Hashtable();
hashtable.Add("key1", "value1");
hashtable.Add("key2", "value2");
Console.WriteLine(hashtable["key1"]); // Вывод: value1
```
### Queue
```
Queue queue = new Queue();
queue.Enqueue("First");
queue.Enqueue("Second");
Console.WriteLine(queue.Dequeue()); // Вывод: First
```
### SortedList
```
SortedList sortedList = new SortedList();
sortedList.Add("b", 2);
sortedList.Add("a", 1);
Console.WriteLine(sortedList["a"]); // Вывод: 1
```
### Stack
```
Stack stack = new Stack();
stack.Push("First");
stack.Push("Second");
Console.WriteLine(stack.Pop()); // Вывод: Second
```
# Обобщеные коллекции

## Интерфейсы обобщенных коллекций

| Интерфейс               | Описание                                                                                   |
|-------------------------|--------------------------------------------------------------------------------------------|
| **ICollection<T>**      | Определяет основные свойства обобщенных коллекций.                                        |
| **IComparer<T>**        | Определяет обобщенный метод Compare для сравнения объектов, хранящихся в коллекции.     |
| **IDictionary<TKey, TValue>** | Определяет словарь — обобщенную коллекцию, состоящую из пар "ключ-значение".            |
| **IEnumerable<T>**      | Содержит обобщенный метод GetEnumerator, предоставляющий перечислитель для класса коллекции. |
| **IEnumerator<T>**      | Предоставляет методы для последовательного доступа к содержимому коллекции.               |
| **IEqualityComparer<T>**| Компаратор, который сравнивает два объекта на предмет равенства.                         |
| **IList<T>**           | Определяет обобщенную коллекцию, доступ к которой осуществляется с помощью индексатора.   |

## Примеры использования

### ICollection<T>
```
ICollection<int> collection = new List<int>();
collection.Add(1);
collection.Add(2);
Console.WriteLine(collection.Count); // Вывод: 2
```
###  IComparer<T>
```
class CustomComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        return x.Length.CompareTo(y.Length);
    }
}

List<string> words = new List<string> { "apple", "banana", "kiwi" };
words.Sort(new CustomComparer());
```
### IDictionary<TKey, TValue>
```
IDictionary<string, int> dictionary = new Dictionary<string, int>();
dictionary.Add("apple", 1);
dictionary.Add("banana", 2);
Console.WriteLine(dictionary["apple"]); // Вывод: 1
```
### IEnumerable<T>
```
IEnumerable<int> numbers = new List<int> { 1, 2, 3 };
foreach (var number in numbers)
{
    Console.WriteLine(number); // Вывод: 1, 2, 3
}
```
### IEnumerator<T>
```
IEnumerator<int> enumerator = new List<int> { 1, 2, 3 }.GetEnumerator();
while (enumerator.MoveNext())
{
    Console.WriteLine(enumerator.Current); // Вывод: 1, 2, 3
}
```
### IEqualityComparer<T>
```
class CustomEqualityComparer : IEqualityComparer<string>
{
    public bool Equals(string x, string y)
    {
        return x.Length == y.Length;
    }

    public int GetHashCode(string obj)
    {
        return obj.Length.GetHashCode();
    }
}

var comparer = new CustomEqualityComparer();
Console.WriteLine(comparer.Equals("hi", "ok")); // Вывод: True
```
### IList<T>
```
IList<string> list = new List<string>();
list.Add("first");
list.Add("second");
Console.WriteLine(list[0]); // Вывод: first
```
## Основные класс обобщеных коллекций

| Класс                           | Описание                                                                                   |
|---------------------------------|--------------------------------------------------------------------------------------------|
| **Dictionary<TKey, TValue>**    | Словарь. Используется для хранения пар "ключ-значение".                                   |
| **HashSet<T>**                  | Используется для хранения уникальных значений с использованием хэш-таблицы.               |
| **LinkedList<T>**               | Сохраняет элементы в двунаправленном списке.                                             |
| **List<T>**                     | Создает динамический массив. Функционал такой же, как и у необобщенного класса ArrayList. |
| **Queue<T>**                    | Очередь. Функционал такой же, как у необобщенного класса Queue.                           |
| **SortedDictionary<TKey, TValue>** | Используется для создания отсортированного списка из пар "ключ-значение".                |
| **SortedList<TKey, TValue>**    | Создает отсортированный список. Функционал такой же, как и у необобщенного класса SortedList. |
| **SortedSet<T>**                | Создает отсортированное множество.                                                       |
| **Stack<T>**                    | Стек. Функционал такой же, как у необобщенного класса Stack.                             |

### Dictionary<TKey, TValue>
```
var dictionary = new Dictionary<string, int>();
dictionary.Add("apple", 1);
dictionary.Add("banana", 2);
Console.WriteLine(dictionary["apple"]); // Вывод: 1
```
### HashSet<T>
```
var hashSet = new HashSet<int>();
hashSet.Add(1);
hashSet.Add(2);
hashSet.Add(1); // Не добавится, так как 1 уже существует
Console.WriteLine(hashSet.Count); // Вывод: 2
```
### LinkedList<T>
```
var linkedList = new LinkedList<string>();
linkedList.AddLast("first");
linkedList.AddLast("second");
foreach (var item in linkedList)
{
    Console.WriteLine(item); // Вывод: first, second
}
```

### List<T>
```
var list = new List<string>();
list.Add("first");
list.Add("second");
Console.WriteLine(list[0]); // Вывод: first
```

### Queue<T>
```
var queue = new Queue<int>();
queue.Enqueue(1);
queue.Enqueue(2);
Console.WriteLine(queue.Dequeue()); // Вывод: 1
```
### SortedDictionary<TKey, TValue>
```
var sortedDictionary = new SortedDictionary<string, int>();
sortedDictionary.Add("banana", 2);
sortedDictionary.Add("apple", 1);
foreach (var kvp in sortedDictionary)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}"); // Вывод: apple: 1, banana: 2
}
```

### SortedList<TKey, TValue>
```
var sortedList = new SortedList<int, string>();
sortedList.Add(2, "two");
sortedList.Add(1, "one");
Console.WriteLine(sortedList[1]); // Вывод: one
```

### SortedSet<T>
```
var sortedSet = new SortedSet<int> { 3, 1, 2 };
foreach (var item in sortedSet)
{
    Console.WriteLine(item); // Вывод: 1, 2, 3
}
```

### Stack<T>
```
var stack = new Stack<string>();
stack.Push("first");
stack.Push("second");
Console.WriteLine(stack.Pop()); // Вывод: second
```
# Реализация интерфейсов IEnumerable и IEnumerator
```
using System;
using System.Collections;

namespace YIELD
{
    // Реализация интерфейсов IEnumerable и IEnumerator
    class MyBytes : IEnumerable, IEnumerator
    {
        byte[] bytes = { 1, 3, 5, 7 };
        int index = -1;

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (index < bytes.Length - 1) {
                Reset();
                return false;
            }
            index++;
            return true;
        }

        public void Reset()
        {
            index = -1;
        }
        public object Current
        {
            get
            {
                return bytes[index];
            }
        }
    }
    class Programm
    {
        static void Main(string[] args)
        {
            MyBytes mb = new MyBytes();
            foreach(int j in mb)
                Console.Write(j + " ");
        }
    }
}
```

# Итераторы. Ключевое слово yield
Синтаксис итератора следующий:
```
public  IEnumerable  имя_итератора(список_параметров)   {
// ...
yield return obj;
}
```
- **имя_итератора** - конкретное имя метода 
- **список_параметров** - параметры, передаваемые методу итератора
- **obj** - следующий объект, возвращаемый итератором 

**Пример итератора**
```
class MyClass
{
    int limit = 0;
    public MyClass(int limit) { this.limit = limit; }
    
    public IEnumerable<int> CountFrom(int start)
    {
        for (int i = start; i <= limit; i++)
        {
            yield return i;
        }
    }
}
```
- Этот метод принимает параметр start и возвращает последовательность целых чисел от start до limit.
- Используется ключевое слово yield return, которое позволяет возвращать значения по одному, не сохраняя все значения в памяти сразу. Это делает метод "ленивым" — значения генерируются по мере необходимости.
**Зачем итераторы?**
- Метод CountFrom позволяет легко итерироваться по диапазону чисел. Вы можете использовать его в цикле foreach, чтобы получить каждое число по отдельности.
-  Поскольку значения возвращаются по одному, вы не загружаете в память все числа сразу. Это особенно полезно, если диапазон чисел большой.
-  Использование итераторов делает код более читаемым и удобным для использования. Вам не нужно вручную управлять индексами или хранить все значения в списке.
**Пример использования**
```
class Program
{
    static void Main(string[] args)
    {
        MyClass myClass = new MyClass(10); // Создаем объект с limit = 10
        foreach (int number in myClass.CountFrom(5)) // Начинаем с 5
        {
            Console.WriteLine(number); // Выводим числа от 5 до 10
        }
    }
}

```

# Пространство имён 
Пространство имён (namespace) — это способ организации кода в C#. Оно позволяет группировать классы, интерфейсы, структуры и другие элементы, чтобы избежать конфликтов имен и улучшить читаемость кода.

Зачем нужны пространства имён?

1. Организация кода: Позволяют структурировать проект, разделяя его на логические группы.

2. Избежание конфликтов: Позволяют использовать одинаковые имена для классов в разных пространствах имён.

3. Упрощение использования: Упрощают доступ к классам и методам при помощи директив using.

### Пример использования пространств имён
Определение пространств имён
```
namespace MyPets
{
    class Cat
    {
        public string Name;
        public byte Age;
        public byte Weight;
    }

    class Dog
    {
        public string Name;
        public byte Age;
        public byte Weight;
    }
}
```
Использование пространств имён
```
using System;
using MyPets; // Подключаем пространство имён MyPets

namespace MyNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");

            Dog dog = new Dog(); // Создаём объект класса Dog
            dog.Name = "Test";
            dog.Age = 245;
            dog.Weight = 22;

            Console.WriteLine("Параметры собаки: {0}, {1}, {2}", dog.Name, dog.Age, dog.Weight);
        }
    }
}
```

Как это работает?
1. Определение классов: В пространстве имён MyPets определены классы Cat и Dog, которые имеют свои поля.

2. Импортирование пространства: В файле с основным кодом используется директива using MyPets;, что позволяет обращаться к классам Cat и Dog без указания полного имени пространства.

3. Создание объектов: В методе Main создаётся объект Dog, и его параметры выводятся на консоль.

# Вложенные пространства имён 
### Создание вложеных пространств имён 
```
using System;

namespace MyPets
{
    namespace Cats
    {
        namespace Siamese
        {
            class Cat
            {
                public string Name;
                public byte Age;
                public byte Weight;

            }
        }
    }
    namespace Dogs
    {
        class Dog
        {
            public string Name;
            public byte Age;
            public byte Weight;
        }
    }
}
```
### Использование вложеных пространств имён 
```
using MyPets.Cats.Siamese;
using MyPets.Dogs;

namespace MyNamespaces
{
    class Programm
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            cat.Name = "Cat";
            cat.Age = 44;
            cat.Weight = 152;

            Console.WriteLine("Paramets cat : {0} , {1} , {2}", cat.Name, cat.Age, cat.Weight);
            Dog dog = new Dog();
            dog.Name = "Test";
            dog.Age = 245;
            dog.Weight = 22;
            Console.WriteLine("Paramets dogs : {0} , {1} , {2}", dog.Name, dog.Age, dog.Weight);
        
        
        }
    }
}
```

# Многопоточное и паралельное программирование

# Парарлельные колекции
В .NET есть несколько классов, которые обеспечивают потокобезопасные коллекции. Эти классы находятся в пространстве имен System.Collections.Concurrent. Ниже приведена таблица, описывающая основные классы и их функциональность.

## Параллельные коллекции

| Класс                          | Описание                                                                                                                                                              |
|--------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ConcurrentQueue<T>          | Параллельная версия очереди. Методы: Enqueue(), TryDequeue(), TryPeek(). Методы с префиксом Try предназначены для работы в многопоточной среде.             |
| ConcurrentStack<T>          | Параллельная версия стека. Методы: Push(), PushRange(), TryPeek(), TryPop(), TryPopRange(). Использует связный список для хранения элементов.             |
| ConcurrentBag<T>            | Не определяет порядок добавления или извлечения элементов. Методы: Add(), TryPeek(), TryTake(). Стремится избегать блокировок, используя внутренние массивы.    |
| ConcurrentDictionary<TKey,TValue> | Параллельная версия словаря. Методы: TryAdd(), TryGetValue(), TryRemove(), TryUpdate(). Позволяет неблокирующий доступ к элементам.                          |
| BlockingCollection<T>        | Коллекция, которая осуществляет блокировку и ожидает возможности для добавления или извлечения элемента. Методы: Add(), Take(). Блокирует поток при необходимости. |

### ConcurrentQueue<T>
```
var queue = new ConcurrentQueue<int>();
queue.Enqueue(1);
queue.Enqueue(2);

if (queue.TryDequeue(out int result))
{
    Console.WriteLine(result); // Вывод: 1
}
```
### ConcurrentStack<T>
```
var stack = new ConcurrentStack<int>();
stack.Push(1);
stack.Push(2);

if (stack.TryPop(out int result))
{
    Console.WriteLine(result); // Вывод: 2
}
```
### ConcurrentBag<T>
```
var bag = new ConcurrentBag<int>();
bag.Add(1);
bag.Add(2);

if (bag.TryTake(out int result))
{
    Console.WriteLine(result); // Вывод: 1 или 2 (порядок не определен)
}
```
### ConcurrentDictionary<TKey,TValue>
```
var dictionary = new ConcurrentDictionary<int, string>();
dictionary.TryAdd(1, "One");
dictionary.TryAdd(2, "Two");

if (dictionary.TryGetValue(1, out string value))
{
    Console.WriteLine(value); // Вывод: One
}
```

### BlockingCollection<T>
```
var blockingCollection = new BlockingCollection<int>();
Task.Run(() =>
{
    blockingCollection.Add(1);
    blockingCollection.Add(2);
});

int item = blockingCollection.Take(); // Блокируется, пока не будет добавлен элемент
Console.WriteLine(item); // Вывод: 1
```
В данном примере демонстрируется использование класса BlockingCollection для реализации модели Producer-Consumer. Программа создает поток для производителя и поток для потребителя, которые взаимодействуют через блокирующую коллекцию.

- System: Основное пространство имен, содержащее базовые классы.
- System.Collections.Concurrent: Содержит классы, обеспечивающие потокобезопасные коллекции.
- System.Threading: Содержит классы для работы с потоками.
- System.Threading.Tasks: Содержит классы для работы с асинхронным программированием.
```
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace BlockingCollection
{
    class Programm
    {
        static BlockingCollection<int> bc;

        // Метод producer добавляет 5 элементов (от 0 до 4) в коллекцию bc.
        static void producer()
        {
            for (int i = 0; i < 5; i++)
            { 
                bc.Add(i);
                Console.WriteLine("Producer " + i);
            }
            bc.CompleteAdding();
            // После добавления всех элементов вызывается метод CompleteAdding(), чтобы указать, что добавление завершено.
        }
        // Метод consumer извлекает элементы из коллекции, пока она не будет завершена.
        static void consumer()
        {
            int i;
            while (!bc.IsCompleted)
            { // Используется метод TryTake, который пытается взять элемент из коллекции. Если элемент успешно извлечен, он выводится на консоль.
                if (bc.TryTake(out i))
                    Console.WriteLine("Consumer: " + i);
            }
        }
        static void Main()
        { // создается экземпляр BlockingCollection с максимальным размером 4.
            bc = new BlockingCollection<int>(4);

            // Создаются задачи (Task) для методов producer и consumer.
            Task ProducerTask = new Task(producer);
            Task ConsumerTask = new Task(consumer);

            // Запускаются обе задачи с помощью метода Start().
            ProducerTask.Start();
            ConsumerTask.Start();

            try
            {   // Используется Task.WaitAll() для ожидания завершения обеих задач.
                Task.WaitAll(ConsumerTask, ProducerTask);
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            } finally
            {   // В блоке finally освобождаются ресурсы, вызвав методы Dispose() для задач и коллекции.
                ConsumerTask.Dispose();
                ProducerTask.Dispose();
                bc.Dispose();
            }
            Console.ReadLine();
        }
    }
}
```
В ходе выполнения программы в консоль будут выведены сообщения от производителя и потребителя, показывающие процесс добавления и извлечения элементов из блокирующей коллекции.

- Таким образом, программа демонстрирует простую реализацию паттерна Producer-Consumer с использованием класса BlockingCollection.


# Класс Task

Класс Task является основным элементом в **Task Parallel Library (TPL)** и представляет собой абстракцию для асинхронных операций. В отличие от класса Thread, который инкапсулирует поток исполнения, класс Task предоставляет более высокоуровневый подход к параллельному 

### Основные отличия от Thread

- **Task**: абстракция для асинхронной операции.
- **Thread**: инкапсулирует поток исполнения.
- Задачи могут разделять один и тот же поток благодаря планировщику задач, работающему с пулом потоков.

### Конструктор Task
Для создания задачи используется следующий конструктор: ```public Task(Action действие)```

Где действие — это точка входа в код, представляющий задачу.

### Делегат Action
Форма делегата Action:

### Пример использования
```
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Programm
    {
        // Метод, который будет запущен в качестве задачи
        static void TaskAction()
        {
            Console.WriteLine("TaskActions started, task {0}", Task.CurrentId);

            for (int count = 0; count < 5; count++)
            {
                // Ожидание 1 секунда (1000 мс)
                Thread.Sleep(1000);
                Console.WriteLine("Task {0}, Count: {1}", Task.CurrentId , count);
            }
        }

        static void Main()
        {
            Console.WriteLine("Main thread started");

            Task task1 = new Task(TaskAction);
            Task task2 = new Task(TaskAction);

            // Запуск задач
            task1.Start();
            task2.Start();

            for (int i = 0; i < 20; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }

            Console.WriteLine("Main thread shutdown");
            Console.ReadLine();
        }
    }
}
```
- В методе TaskAction выполняется цикл, который выводит номер задачи и счетчик.
- В методе Main создаются и запускаются две задачи.
- Основной поток выводит точки в течение 10 секунд, пока задачи выполняются.

# Ожидание задачи
```
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Programm
    {
        // Метод, который будет запущен в качестве задачи
        static void TaskAction()
        {
            Console.WriteLine("TaskActions started, task {0}", Task.CurrentId);

            for (int count = 0; count < 5; count++)
            {
                // Ожидание 1 секунда (1000 мс)
                Thread.Sleep(1000);
                Console.WriteLine("Task {0}, Count: {1}", Task.CurrentId, count);
            }
        }

        static void Main()
        {
            Console.WriteLine("Main thread started");

            Task task1 = new Task(TaskAction);
            Task task2 = new Task(TaskAction);
            // Запуск задач
            task1.Start();
            task2.Start();

            Console.WriteLine("Waiting...");
            // Ожидание завершения задач
            task1.Wait();
            task2.Wait();

            Console.WriteLine("Main thread shutdown");
            Console.ReadLine();
        }
    }
}
```
## Описание кода

1. **Метод TaskAction**:
   - Запускается в качестве задачи.
   - Выводит идентификатор задачи и выполняет цикл с задержкой в 1 секунду.

2. **Метод Main**:
   - Создает и запускает две задачи (task1 и task2).
   - Использует метод Wait() для ожидания завершения обеих задач.
   - После завершения задач выводит сообщение о завершении основного потока.

## Проблемы с использованием Thread.Sleep()
- Использование Thread.Sleep() для ожидания завершения задач может привести к ошибкам:
  - Неправильная задержка может привести к преждевременному завершению основного потока.
  - Невозможно точно предсказать время выполнения задач.

## Преимущества метода Wait()
- Метод Wait() обеспечивает надежное ожидание завершения задач.
- При вызове Wait() могут возникнуть исключения:
  - ObjectDisposedException: если задача была освобождена.
  - AggregateException: если задача завершилась с ошибкой или была отменена.

## Заключение
Использование класса Task и метода Wait() позволяет более эффективно управлять асинхронными операциями и избегать проблем, связанных с преждевременным завершением основного потока.

# Класс TaskFactory

Класс TaskFactory позволяет создавать и сразу запускать задачи, упрощая процесс работы с асинхронными операциями. 

### Создание и запуск задач
Вместо того чтобы сначала создавать задачу, а затем запускать её, мы можем использовать TaskFactory, чтобы сделать это в одном шаге.

### Получение экземпляра TaskFactory
Объект класса TaskFactory можно получить через статическое свойство Factory класса Task: ```TaskFactory tf = Task.Factory;```

### Метод StartNew()
Метод StartNew() имеет несколько перегрузок. Самая простая форма выглядит следующим образом: ```public Task StartNew(Action action)```


### Пример использования TaskFactory
Можно создать и запустить задачу следующим образом:
```
Task t1 = tf.StartNew(TaskAction);
Task t2 = Task.Factory.StartNew(TaskAction);
```


```
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Programm
    {
        // метод который будет запущен в качестве задачи
        static void TaskAction()
        {
            Console.WriteLine("TaskActions started, task {0}", Task.CurrentId);

            for (int count = 0; count < 5; count++)
            {
                // Ожидание 1 секунда (1000 мс)
                Thread.Sleep(1000);

                Console.WriteLine("Task {0}, Count: {1}", Task.CurrentId , count);
            }
        }
        static void Main()
        {
            Console.WriteLine("Main thread started");

            TaskFactory tf_1 = new TaskFactory();
            // запуск задачи
            Task t1 = tf_1.StartNew(TaskAction);
            // или так сразу
            Task t2 = Task.Factory.StartNew(TaskAction);

            Console.WriteLine("Waiting...");
            
            t1.Wait();
            t2.Wait();

            Console.WriteLine("Main threead shutdown");
            Console.ReadLine();
        }
    }
}
```
# Ожидание задачи 

## Введение
Задача в C# может возвращать значение, что удобно для организации параллельных вычислений. Это позволяет вычислять результат и возвращать его в основной поток, блокируя вызывающий процесс до получения результата.

## Использование Task<TResult>
Чтобы вернуть результат из задачи, необходимо использовать обобщенную форму Task<TResult> класса Task. 

### Конструкторы Task<TResult>
Вот два основных конструктора:

1. **Без аргументов:** : ```public Task(Func<TResult> функция)```

2. **С аргументом:** : ```public Task(Func<Object, TResult> функция, Object состояние)```
   
### Пример использования Task<TResult>
```
using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        // Создание задачи, возвращающей значение
        Task<int> task = new Task<int>(() => 
        {
            // Выполнение вычислений
            int result = 0;
            for (int i = 1; i <= 5; i++)
            {
                result += i; // Суммируем числа от 1 до 5
            }
            return result;
        });

        // Запуск задачи
        task.Start();

        // Ожидание завершения и получение результата
        int finalResult = task.Result; // Блокирует до завершения задачи

        Console.WriteLine($"Результат: {finalResult}"); // Вывод: Результат: 15
    }
}
```

## Использование TaskFactory<TResult>
Также можно использовать класс TaskFactory<TResult> для создания задач с возвратом значения.

### Методы StartNew()
Вот два метода, которые поддерживают возврат результата:

1. **Без аргументов:** : ```public Task<TResult> StartNew(Func<TResult> функция)```

2. **С аргументом:** : ```public Task<TResult> StartNew(Func<Object, TResult> функция, Object состояние)```


### Пример использования TaskFactory<TResult>
```
using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        TaskFactory<int> factory = new TaskFactory<int>();

        // Создание и запуск задачи с использованием TaskFactory
        Task<int> task = factory.StartNew(() =>
        {
            int result = 1;
            for (int i = 1; i <= 5; i++)
            {
                result *= i; // Вычисляем факториал 5
            }
            return result;
        });

        // Получение результата
        int factorialResult = task.Result; // Блокирует до завершения задачи

        Console.WriteLine($"Факториал 5: {factorialResult}"); // Вывод: Факториал 5: 120
    }
}
```
   