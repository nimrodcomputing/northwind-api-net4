using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Resources;

namespace Northwind.Services.Interfaces
{
    public interface ICustomersService
    {
        IList<CustomerResource> Select();

        Task<CustomerResource> SingleAsync(string id);

        Task<CustomerResource> AddAsync(CustomerResource resource);

        Task<CustomerResource> ReplaceAsync(string id, CustomerResource resource);

        Task RemoveAsync(string id);
    }
}