using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Resources;

namespace Northwind.Services.Interfaces
{
    public interface IOrdersService
    {
        List<OrderResourceFull> Select();

        Task<OrderResourceFull> SingleAsync(int id);

        Task<OrderResource> AddAsync(OrderResource resource);

        Task<OrderResource> ReplaceAsync(int id, OrderResource resource);

        Task RemoveAsync(int id);
    }
}