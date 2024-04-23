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
            _manufactures   = manufactures;
            this.Departament = Departament.Electronics;
        }

        public string Manufactures { get => _manufactures; set => _manufactures = value; }

        public bool IsBatteryPowered { get => _IsBatteryPowered; set => _IsBatteryPowered = value;}

        public override double GetDiscountPrice(double discountPercentage)
        {
            if(_IsBatteryPowered == true)
            {// Если работает от батареек, то скидку уменьшаем
               discountPercentage = (discountPercentage - 40) < 0 ? 0 : discountPercentage;
            }

            return base.GetDiscountPrice(discountPercentage);
        }
    }
}
