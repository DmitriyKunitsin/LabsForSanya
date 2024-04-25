using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Queries;
using MediatR;

namespace CQRS.Handlers
{
    /*Данный класс должен реализовывать“IRequestHandler”, где: 
     * TCommand – команда, обработчиком которой будет являться описываемый класс (в нашем случае – это “GetProductsQuery”),
     * а TResponse – тип возвращаемого значения данной команды (тот же параметр, который передавали выше интерфейсу IRequest – “IEnumerable”). */
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        /*приватное свойство только для чтения типа “ProductStore” и инициализируем его в конструкторе:*/
        private readonly ProductStore _productStore;

        public GetProductsQueryHandler(ProductStore productStore)
        {
            _productStore = productStore;
        }
        /*реализуя интерфейс “IRequestHandler”, создаем метод Handle*/
        /// <summary>Метод Handle принимает запрос типа GetProductsQuery и отмену операции через токен CancellationToken. Возвращает асинхронную задачу, которая возвращает коллекцию продуктов.</summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productStore.GetAllProductsAsync();
        }

    }
}
