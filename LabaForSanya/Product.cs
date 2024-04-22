using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaForSanya
{
    class Product
    {
        private string _name;
        private string _description;
        private double _price;
        private int _quantity;
        private string[] _structure;


        // Свойства для доступа к приватным полям
        // Название
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        // Описание
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        // Стоимость
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        // Колличество
        public int Quantity
        {
            get { return (_quantity <= 0) ? 0 : _quantity; }
            set { _quantity = value; }
        }

        // Индексатор для доступа к элементам массива _structure по индексу
        public string this[int index]
        {
            get { return _structure[index]; }
            set { _structure[index] = value; }
        }
        // Конструктор класса для инициализации объекта с заданным именем
        public Product(string name, int rows)
        {
            this._name = name;
            this._description = "";
            this._price = 0;
            this._quantity = 0;
            this._structure = new string[rows];
        }

        public static int GetLenghtStructure(string name)
        {
            Product current_prodect = ProductManager.FindProductByName(name);
            return current_prodect._structure.Length;
        }

        
    }
}
