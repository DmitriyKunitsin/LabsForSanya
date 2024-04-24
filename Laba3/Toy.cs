namespace Laba3
{
    internal class Toy : Product
    {
        private int _ageRestrictions;// Возвраст с какого можно пользоваться (6+ как пример)
        private string _manufacturer;// Производитель
        private bool _isBatteryPowered; // Работает ли от батареек
        public Toy(string name, string descripsion, double price, int quantity, int lenghtStructure, int ageRestrictions, string manufacturer, bool isBatteryPowered)
            : base(name, descripsion, price, quantity, lenghtStructure)
        {
            _ageRestrictions = ageRestrictions;
            _manufacturer = manufacturer;
            _isBatteryPowered = isBatteryPowered;
            this.Departament = Departament.Toy;
            Counter++;
        }

        public int AgeRestrictions { get => _ageRestrictions; set => _ageRestrictions = value; }
        public string Manufacturer { get => _manufacturer; set => _manufacturer = value; }
        public bool IsBanttryPowered { get => _isBatteryPowered; set => _isBatteryPowered = value; }
        public static int Counter = 0;
        /// <summary>Расчет скидки в зависимости от условия внутри конкретного объекта, получается процент скидки, возвращает цену со скидкой</summary>
        /// <param name="discountPercentage">The discount percentage.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public override double GetDiscountPrice(double discountPercentage)
        {

            if (_isBatteryPowered == true)
            {// дополнительнская скидка на все товары, которые работают от батареек
                discountPercentage = (discountPercentage + 40) > 100 ? 90 : (discountPercentage + 40);
            }


            return base.GetDiscountPrice(discountPercentage);
        }

        public static Toy AddToy()
        {
            Product newProduct = AddProduct();
            int ageRestrictions = Print.GetIntInput("Введите возсраст с какого можно пользоваться данной игрушкой");
            string manufactures = Print.GetInput("введите страну производителя");
            bool isBatteryPowered = Print.SurveyIsBoolean("Игрушка работает от батареек? да/нет");
            Toy newToy = new Toy(newProduct.Name, newProduct.Description, newProduct.Price, newProduct.Quantity, newProduct.LenghtStructure, ageRestrictions, manufactures, isBatteryPowered);
            for (int i = 0; i < newProduct.LenghtStructure; ++i)
            {
                newToy[i] = newProduct[i];
            }
            return newToy;

        }
    }
}
