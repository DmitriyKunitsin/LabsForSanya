﻿using CQRS;
using MediatR;


/*Record - это ссылочный тип, который представляет неизменяемую структуру данных.
Основное назначение record - это удобное и эффективное создание неизменяемых объектов данных.*/

/*
 * Основные особенности record:

1. **Неизменяемость**: Значения полей в record не могут быть изменены после создания объекта. 
Если вы хотите изменить значение поля, то создается новый объект record.

2. **Сравнение и равенство**: По умолчанию record сравниваются по значениям своих полей, а не по ссылкам на объекты.

3. **Методы по умолчанию**: Компилятор автоматически генерирует ряд методов для record,
такие как Equals, GetHashCode, ToString, что упрощает работу с данными.

4. **Поля только для чтения**: Поля в record могут быть только для чтения, что подчеркивает неизменяемость данных.

5. **Деконструкция**: Возможность деконструировать record на отдельные переменные.

6. **Копирование с изменением**: Метод with позволяет создавать копию объекта с измененными значениями полей.
*/
namespace CQRS.Queries
{
    public record GetProductsQuery : IRequest<IEnumerable<Product>>;

}