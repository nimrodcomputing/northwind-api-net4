using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Resources;

namespace Northwind.Services.Interfaces
{
    public interface IProductsService
    {
        IList<ProductResource> Select();

        Task<ProductResource> SingleAsync(int id);

        Task<ProductResource> AddAsync(ProductResource resource);

        Task<ProductResource> ReplaceAsync(int id, ProductResource resource);

        Task RemoveAsync(int id);
    }
}