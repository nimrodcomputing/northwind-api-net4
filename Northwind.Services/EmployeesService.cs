using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Northwind.Data;
using Northwind.Models;
using Northwind.Resources;
using Northwind.Services.Interfaces;

namespace Northwind.Services
{

    public class EmployeesService : IEmployeesService
    {

        private readonly NorthwindDb _db = new NorthwindDb();

        public IList<EmployeeResource> Select()
        {
            return _db.Employees.ProjectTo<EmployeeResource>().ToList();
        }

        public async Task<EmployeeResource> SingleAsync(int id)
        {
            Employee entity = await FindAsync(id);
            return ToResource(entity);
        }

        public async Task<EmployeeResource> AddAsync(EmployeeResource resource)
        {
            Employee entity = ToEntity(resource);
            _db.Employees.Add(entity);
            await _db.SaveChangesAsync();
            return ToResource(entity);
        }

        public async Task<EmployeeResource> ReplaceAsync(int id, EmployeeResource resource)
        {
            Employee entity = await FindAsync(id);
            Mapper.Map(resource, entity);
            await _db.SaveChangesAsync();
            return ToResource(entity);
        }

        public async Task RemoveAsync(int id)
        {
            Employee entity = await FindAsync(id);
            _db.Employees.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<byte[]> GetImageAsync(int id)
        {
            Employee entity = await FindAsync(id);
            byte[] image = entity.Photo;
            return image;
        }

        private async Task<Employee> FindAsync(int id)
        {
            var entity = await _db.Employees.FindAsync(id);
            if (entity == null)
                throw  new KeyNotFoundException();
            return entity;
        }

        private static Employee ToEntity(EmployeeResource resource)
        {
            return Mapper.Map<Employee>(resource);
        }

        private static EmployeeResource ToResource(Employee entity)
        {
            return Mapper.Map<EmployeeResource>(entity);
        }
    }
}
