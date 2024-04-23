using System.Diagnostics;
using System.Xml.Linq;

namespace Laba3
{
    internal class Clothing : Product
    {

        private string _manufactures; // Страна производитель
        private string _gender; // мужская или женская
        public Clothing(string name, string descripsion, double price, int quantity, int lenghtStructure, string manufactures, string gender) 
            : base(name, descripsion, price, quantity, lenghtStructure)
        {
            _manufactures = manufactures;
            _gender = gender;
            this.Departament = Departament.Clothing;
        }

        public override double GetDiscountPrice(double discountPercentage)
        {
            if(_gender == "муж")
            {// распродажа на мужскую одежду
                discountPercentage = (discountPercentage * 2) > 100 ? 95 : discountPercentage;
            }
            return base.GetDiscountPrice(discountPercentage);
        }

        public string Manufactures { get => _manufactures; set => _manufactures = value; }
        public string Gender { get => _gender; set => _gender = value; }
    }
}
