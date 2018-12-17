using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Resources;

namespace Northwind.Services.Interfaces
{
    public interface ICategoriesService
    {
        IList<CategoryResource> Select();

        Task<CategoryResource> SingleAsync(int id);

        Task<CategoryResource> AddAsync(CategoryResource resource);

        Task<CategoryResource> ReplaceAsync(int id, CategoryResource resource);

        Task RemoveAsync(int id);

        Task<byte[]> GetImageAsync(int id);
    }
}