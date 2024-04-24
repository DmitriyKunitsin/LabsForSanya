using System.Xml.Linq;

namespace Laba3
{
    internal class Product
    {
        private string _name;//название продукта
        private string _description;// описание продукта
        private double _price;// цена продукта
        private int _quantity;// колличество продуктов
        private string[] _structure;// состав продукта
        private int _lenght_structure; //Максильное колличество продуктов на полках
        public Departament Departament { get; set; }

        public Product()
        {// Конструктор без параметров
            _name = "Defoult";
            _description = string.Empty;
            _price = double.NaN;
            _quantity = 0;
            _structure = Array.Empty<string>();
        }

        public Product(string name, string description, double price,
            int quantity, int LenghtStructure)
        {// Конструктор с параметрами
            _name = name;
            _description = description;
            _price = price;
            _quantity = quantity;
            _structure = new string[LenghtStructure];
        }

        public virtual double GetDiscountPrice(double discountPercentage)// Виртуальный метод для реализации полиформизма
        {// в него передается процент скидки
            if (discountPercentage < 0)
            {
                discountPercentage = 0;
            }
            return Price - (Price * (discountPercentage / 100));
        }

        public string Name { get => _name; set => _name = value; }

        public string Description { get => _description; set => _description = value; }
        public double Price { get => _price; set => _price = value; }

        public int Quantity { get => _quantity; set => _quantity = value; }

        public string this[int index]
        {
            get { return _structure[index]; }
            set { _structure[index] = value; }
        }

        public int LenghtStructure { get => _lenght_structure; set => _lenght_structure = value; }

        public static int CounterProduct = 0;
        public static int MaxProduct = 0;
        public static int DiscountAmount = 0;

        /*Функция для увеличения счетчика продуктуктов*/
        public static void IncreaseProductCount()
        {
            CounterProduct++;
        }

        /*Функция для уменьшения счетчика продуктуктов*/
        public static void DecreaseProductCount()
        {
            if (CounterProduct <= 0)
            {
                Console.WriteLine("Удалять больше нечего");
            }
            else { CounterProduct--; }
        }

        public static void AddStructProduct(Product product, string[] values)
        {
            if (values.Length == product._structure.Length)
            {
                for (int i = 0; i < values.Length; ++i)
                {
                    product[i] = values[i];
                }
            }
            else
            {
                throw new Exception("Размер переданного массива не соответствует размеру массива структуры.");
            }
        }
        public static Product AddProduct()
        {
            string name_prod = Print.GetInput("Введите название продукта");
            string discripsion = Print.GetInput("Введите описание продукта");
            double price_product = Print.GetDoubleInput("Введите цену продукта");
            int quantity_product = Print.GetIntInput("Введите колличество товаров");
            int lenght_struct = Print.GetIntInput("Какое колличество составляющих продукта?");
            string[] current_struct_product = new string[lenght_struct];
            for (int i = 0; i < lenght_struct; ++i)
            {
                current_struct_product[i] = Print.GetInput($"введите ингридитент состава {i + 1} из {lenght_struct} :");
            }
            Product current_product = new Product(name_prod, discripsion, price_product, quantity_product, lenght_struct);
            AddStructProduct(current_product, current_struct_product);
            current_product.LenghtStructure = lenght_struct;

            return current_product;
        }

        public static void RemoveProduct(List<Product> allProducts)
        {
            string search_product_for_remove = Print.GetInput("Введите название продукта, который необходимо удалить");

            Product productToRemove = allProducts.FirstOrDefault(x => x.Name == search_product_for_remove);

            if (productToRemove != null)
            {
                Console.WriteLine($"Товар из отдела {Print.GetDepartamentByProduct(productToRemove)}");
                allProducts.Remove(productToRemove);

            }
            else
            {
                Console.WriteLine("Продукт не найден");
            }
        }

        public static void PrintCurrentProduct(Product currentProduct)
        {
            if (currentProduct != null)
            {
                Console.WriteLine($"Отдел : {Print.GetDepartamentByProduct(currentProduct)}");
                Console.WriteLine($"Название : " + currentProduct.Name);
                Console.WriteLine($"Описание : " + currentProduct.Description);
                Console.WriteLine($"Цена : " + currentProduct.Price);
                Console.WriteLine($"Цена со скидкой :" + currentProduct.GetDiscountPrice(DiscountAmount));
                Console.WriteLine($"Колличество на остатке : " + currentProduct.Quantity);
                Console.WriteLine("Состав : ");
                for (int i = 0; i < currentProduct._structure.Length; ++i)
                {
                    Console.Write($" {i + 1}. :" + currentProduct[i] + "\n");
                }

            }
            else
            {
                Console.WriteLine("Продукт не найден");
            }
        }

        public static void PrintAllProduct(List<Product> allProducts)
        {
            int count = 1;
            if (allProducts != null)
            {
                foreach (Product product in allProducts)
                {
                    if (product == null)
                    {
                        continue;
                    }
                    Console.WriteLine($"Отдел : {Print.GetDepartamentByProduct(product)}");
                    Console.WriteLine($"Продукт #{count++} : ");
                    Console.WriteLine($"Название : " + product.Name);
                }
            }
            if (count == 1)
            {
                Console.WriteLine("Продуктов в магазине нету");
            }
        }

        public static void SearchLinesInSelectedProduct(List<Product> AllProducts, int selected)
        {
            bool IsNullAllProdOrNo = false;
            switch (selected)
            {
                case 1://Название
                    string name_search = Print.GetInput("Введите название по которому искать");
                    bool name_check = false;
                    for (int i = 0; i < AllProducts.Count; ++i)
                    {
                        if (AllProducts[i] == null)
                        {
                            continue;
                        }
                        IsNullAllProdOrNo = true;
                        if (AllProducts[i].Name.ToLower() == name_search)
                        {
                            PrintCurrentProduct(AllProducts[i]);
                            name_check = true;
                        }
                    }
                    if (!name_check)
                    {
                        Console.WriteLine("Таких названий не найдено");
                    }
                    break;
                case 2://Описание
                    string dist_search = Print.GetInput("Введите строку по которой искать в описание");
                    bool dist_check = false;
                    for (int i = 0; i < AllProducts.Count; ++i)
                    {
                        if (AllProducts[i] == null)
                        {
                            continue;
                        }
                        IsNullAllProdOrNo = true;
                        if (AllProducts[i].Description.ToLower().Contains(dist_search.ToLower()))
                        {
                            PrintCurrentProduct(AllProducts[i]);
                            dist_check = true;
                        }
                    }
                    if (!dist_check)
                    {
                        Console.WriteLine("Совпадений не найдено");
                    }
                    break;
                case 3://Цена
                    double price_search = Print.GetDoubleInput("Bведите цену по которой искать");
                    bool price_check = false;
                    for (int i = 0; i < AllProducts.Count; ++i)
                    {
                        if (AllProducts[i] == null)
                        {
                            continue;
                        }
                        IsNullAllProdOrNo = true;
                        if (AllProducts[i].Price == price_search)
                        {
                            PrintCurrentProduct(AllProducts[i]);
                            price_check = true;
                        }
                    }
                    if (!price_check)
                    {
                        Console.WriteLine("Совпадений не найдено");
                    }
                    break;
                case 4://Колличество
                    int quantity_search = Print.GetIntInput("Введите колличество по которому искать совпадения");
                    bool quantity_check = false;
                    for (int i = 0; i < AllProducts.Count; ++i)
                    {
                        if (AllProducts[i] == null)
                        {
                            continue;
                        }
                        IsNullAllProdOrNo = true;
                        if (AllProducts[i].Quantity == quantity_search)
                        {
                            PrintCurrentProduct(AllProducts[i]);
                            quantity_check = true;
                        }
                    }
                    if (!quantity_check)
                    {
                        Console.WriteLine("Совпадений не найдено");
                    }
                    break;
                case 5://Состав
                    string struct_search = Print.GetInput("введите состав по которому искать");
                    bool struct_check = false;
                    for (int i = 0; i < AllProducts.Count; ++i)
                    {
                        if (AllProducts[i] == null)
                        {
                            continue;
                        }
                        IsNullAllProdOrNo = true;
                        for (int k = 0; k < AllProducts[i]._structure.Length; ++k)
                        {

                            if (AllProducts[i]._structure[k] == struct_search)
                            {
                                PrintCurrentProduct(AllProducts[i]);
                                struct_check = true;
                            }
                        }
                    }
                    if (!struct_check)
                    {
                        Console.WriteLine("Совпадений не найдено");
                    }
                    break;

            }
            if (IsNullAllProdOrNo == false)
            {
                Console.WriteLine("Полки пусты");
            }
        }

        public static void UpdateCurrentProduct(Product currentProduct, int selected)
        {
            switch (selected)
            {
                case 1:
                    currentProduct.Description = Print.GetInput("Введите новое описание");
                    break;
                case 2:
                    currentProduct.Price = Print.GetIntInput("Введите новую цену");
                    break;
                case 3:
                    currentProduct.Quantity = Print.GetIntInput("Введите новое колличество продукта");
                    break;
                case 4:
                    int newLenghtStruct = Print.GetIntInput("Сколько позиций будет в новом составе?");
                    ResizeArrayProduct(ref currentProduct, newLenghtStruct);
                    Console.WriteLine($"Введите новый состав на {newLenghtStruct} позиций");
                    for (int i = 0; i < currentProduct._structure.Length; ++i)
                    {
                        currentProduct[i] = Print.GetInput($"{i + 1}. : ");
                    }
                    break;
            }
        }

        public static bool CheckArrayIsNotNull(Product[] product)
        {
            bool check = false;
            for (int i = 0; i < product.Length; ++i)
            {
                if (product[i] == null)
                {
                    check = true;
                }
            }
            return check;
        }

        private static void ResizeArrayProduct(ref Product currentProduct, int newSize)
        {
            currentProduct._structure = new string[newSize];
        }

        public static Product SearchSelectedProduct(List<Product> allProducts)
        {
            string current_name_product = Print.GetInput("Введите название продукта для его изменения");

            return allProducts.FirstOrDefault(x => x.Name.ToLower() == current_name_product.ToLower()); 
        }

        public static List<Product> GetProductBySelectedDepartament(List<Product> products)
        {
            Departament selectedDepartamentd = (Departament)Print.PrintMenuDepartament();

            return products.Where(x => x.Departament == selectedDepartamentd).ToList();
        }
    }
}
