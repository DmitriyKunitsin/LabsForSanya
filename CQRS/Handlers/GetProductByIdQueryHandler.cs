using MediatR;

namespace CQRS.Handlers
{
    /*это класс запроса, который представляет запрос на получение продукта по его идентификатору. 
     * Он наследует интерфейс IRequest<Product>,
     * который указывает, что этот класс является запросом и ожидает ответ в виде объекта типа Product.*/
    public record GetProductByIdQuery(int id) : IRequest<Product>;
    /* это класс обработчика запроса, который реализует интерфейс IRequestHandler<GetProductByIdQuery, Product>.
     * Он содержит логику обработки запроса GetProductByIdQuery и возвращает объект типа Product.*/
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        /*предоставляет доступ к данным о продуктах. 
         В конструкторе GetProductByIdQueryHandler происходит инъекция зависимости объекта ProductStore.*/
        private readonly ProductStore _productStore;
        public GetProductByIdQueryHandler(ProductStore productStore)
        {
            _productStore = productStore;
        }

        /*это метод обработки запроса. Он принимает объект запроса GetProductByIdQuery,
         извлекает идентификатор продукта из него и вызывает метод GetProductByIdAsync у объекта ProductStore, 
        чтобы получить соответствующий продукт.*/
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            => await _productStore.GetProductByIdAsync(request.id);
    }
}

