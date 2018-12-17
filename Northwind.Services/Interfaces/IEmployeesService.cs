using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Resources;

namespace Northwind.Services.Interfaces
{
    public interface IEmployeesService
    {
        IList<EmployeeResource> Select();

        Task<EmployeeResource> SingleAsync(int id);

        Task<EmployeeResource> AddAsync(EmployeeResource resource);

        Task<EmployeeResource> ReplaceAsync(int id, EmployeeResource resource);

        Task RemoveAsync(int id);

        Task<byte[]> GetImageAsync(int id);
    }
}