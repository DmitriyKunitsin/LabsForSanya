using System.Security.Cryptography.X509Certificates;

namespace CQRS
{
    public class ProductStore
    {
        private List<Product> _products;

        public ProductStore()
        {
            _products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Апельсины"},
                new Product() { Id = 2, Name = "Печенье"},
                new Product() { Id = 3, Name = "Молоко"}
            };
        }

        /// <summary>возвращает все продукты, хранящиеся в базе данных, в виде коллекции объектов типа Product.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<IEnumerable<Product>> GetAllProductsAsync() => await Task.FromResult(_products);

        /// <summary>позволяет получить продукт по его уникальному идентификатору id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<Product> GetProductByIdAsync(int id) => await Task.FromResult(_products.First(p => p.Id == id));

        /// <summary>добавляет новый продукт в базу данных.</summary>
        /// <param name="product">The product.</param>
        public async Task AddProductAsync(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        /// <summary>возвращает идентификатор последнего добавленного продукта. Если база данных не содержит продуктов, возвращается значение 0.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<int>  GetLastProductIdAsync() => await Task.FromResult(_products.Count > 0 ? _products.OrderBy(x => x.Id).Last().Id: 0);    
    }
}
