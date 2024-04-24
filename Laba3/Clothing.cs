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
            Counter++;
        }

        /// <summary>Расчет скидки в зависимости от условия внутри конкретного объекта, получается процент скидки, возвращает цену со скидкой</summary>
        /// <param name="discountPercentage">The discount percentage.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public override double GetDiscountPrice(double discountPercentage)
        {
            if (_gender == "муж")
            {// распродажа на мужскую одежду
                discountPercentage = (discountPercentage * 2) > 100 ? 95 : (discountPercentage * 2);
            }
            return base.GetDiscountPrice(discountPercentage);
        }

        public string Manufactures { get => _manufactures; set => _manufactures = value; }
        public string Gender { get => _gender; set => _gender = value; }
        public static int Counter = 0;

        public static Clothing AddClothing()
        {
            string gender;
            Product newProduct = AddProduct();
            string manufactures = Print.GetInput("введите страну производителя");
            if (Print.SurveyIsBoolean("Данная вещь мужская? да/нет"))
            {
                gender = "муж";

            }
            else
            {
                gender = "жен";
            }
            Clothing newClothing = new Clothing(newProduct.Name, newProduct.Description, newProduct.Price, newProduct.Quantity, newProduct.LenghtStructure, manufactures, gender);
            for (int i = 0; i < newProduct.LenghtStructure; ++i)
            {
                newClothing[i] = newProduct[i];
            }
            return newClothing;
        }
    }
}
