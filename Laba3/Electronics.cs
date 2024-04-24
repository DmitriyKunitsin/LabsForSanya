namespace Laba3
{
    internal class Electronics : Product
    {
        private string _manufactures; // Страна производитель
        private bool _IsBatteryPowered; // Работает ли от батареек данный девайс
        public Electronics(string name, string descripsion, double price, int quantity, int lenghtStructure, string manufactures, bool IsBatteryPowered)
            : base(name, descripsion, price, quantity, lenghtStructure)
        {
            _IsBatteryPowered = IsBatteryPowered;
            _manufactures = manufactures;
            this.Departament = Departament.Electronics;
            Counter++;
        }

        public string Manufactures { get => _manufactures; set => _manufactures = value; }

        public bool IsBatteryPowered { get => _IsBatteryPowered; set => _IsBatteryPowered = value; }
        /// <summary>Счетчик статичный, если статичный, то общий для всех экземпляров(объектов) класса</summary>
        public static int Counter = 0;
        /// <summary>Расчет скидки в зависимости от условия внутри конкретного объекта, получается процент скидки, возвращает цену со скидкой</summary>
        /// <param name="discountPercentage">The discount percentage.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public override double GetDiscountPrice(double discountPercentage)
        {
            if (_IsBatteryPowered == true)
            {// Если работает от батареек, то скидку уменьшаем
                discountPercentage = (discountPercentage - 40) < 0 ? 0 : (discountPercentage - 40);
            }

            return base.GetDiscountPrice(discountPercentage);
        }

        public static Product AddElectronics()
        {
            Product newProduct = AddProduct();
            string manufactures = Print.GetInput("введите страну производителя");
            bool isBatteryPowered = Print.SurveyIsBoolean("Продукт работает от батареек? да/нет");
            Electronics newElectnronics = new Electronics(newProduct.Name, newProduct.Description, newProduct.Price, newProduct.Quantity, newProduct.LenghtStructure, manufactures, isBatteryPowered);
            for (int i = 0; i < newProduct.LenghtStructure; ++i)
            {
                newElectnronics[i] = newProduct[i];
            }
            return newElectnronics;
        }
    }
}
