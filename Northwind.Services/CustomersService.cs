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

    public class CustomersService : ICustomersService
    {

        private readonly NorthwindDb _db;

        public CustomersService(NorthwindDb db)
        {
            _db = db;
        }

        public IList<CustomerResource> Select()
        {
            return _db.Customers.ProjectTo<CustomerResource>().ToList();
        }

        public async Task<CustomerResource> SingleAsync(string id)
        {
            Customer entity = await FindAsync(id);
            return ToResource(entity);
        }

        public async Task<CustomerResource> AddAsync(CustomerResource resource)
        {
            Customer entity = ToEntity(resource);
            _db.Customers.Add(entity);
            await _db.SaveChangesAsync();
            return ToResource(entity);
        }

        public async Task<CustomerResource> ReplaceAsync(string id, CustomerResource resource)
        {
            Customer entity = await FindAsync(id);
            Mapper.Map(resource, entity);
            await _db.SaveChangesAsync();
            return ToResource(entity);
        }

        public async Task RemoveAsync(string id)
        {
            Customer entity = await FindAsync(id);
            _db.Customers.Remove(entity);
            await _db.SaveChangesAsync();
        }

        private async Task<Customer> FindAsync(string id)
        {
            var entity = await _db.Customers.FindAsync(id);
            if (entity == null)
                throw  new KeyNotFoundException();
            return entity;
        }

        private static Customer ToEntity(CustomerResource resource)
        {
            return Mapper.Map<Customer>(resource);
        }

        private static CustomerResource ToResource(Customer entity)
        {
            return Mapper.Map<CustomerResource>(entity);
        }
    }
}
