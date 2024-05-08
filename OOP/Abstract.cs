using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    abstract class Transport
    {
        public abstract int Speed { get; set; }
        public string Name { get;}
        public Transport(string name)
        {
            this.Name = name;
        }

        public abstract void Move();

    }
    class Ship : Transport
    {
        int speed;
        public override int Speed { get => this.speed; set => this.speed = value; } 
        public Ship(string name) : base(name) { }
        public override void Move()
        {
            Console.WriteLine($"Корабль плывет, его скорость {this.speed}");
        }
    }
    abstract class Car : Transport
    {
       public Car(string name) : base(name) { }
    }
    class Auto : Car
    {
        public override int Speed { get; set; } = 25;
        public Auto(string name) : base(name) { }
        public override void Move() => Console.WriteLine($"Легковая машина марки {this.Name} едет, ее скорость {this.Speed}");
    }
    class Aircraft : Transport
    {
        public override int Speed { get; set; } = 100;
        public Aircraft(string name) : base(name) { }
        public override void Move() => Console.WriteLine($"Самолет летит, его скорость {this.Speed}");
    }

    abstract class Shape
    {
        // абстрактный метод для получения периметра
        public abstract double GetPerimetr();

        // абстрактный метод для получения площади
        public abstract double GetArea();
    }
    // производный класс прямоугольника
    class Recrangle : Shape
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public override double GetPerimetr() => Width *  2 + Height * 2;

        public override double GetArea() => Width * Height;

    }
    // производный класс окружности
    class Circle : Shape
    {
        public double Radius { get; set; }

        // переопределение получения периметра
        public override double GetPerimetr() => Radius * 2 * 3.14;
        // переопрелеление получения площади
        public override double GetArea() => Radius * Radius * 3.14;
    }

}
