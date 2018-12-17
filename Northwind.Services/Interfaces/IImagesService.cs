using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Interfaces
{
    public interface IImagesService
    {
        Task<byte[]> Category(int id);

        Task<byte[]> Employee(int id);
    }

}
