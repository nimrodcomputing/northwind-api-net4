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

    public class OrdersService : IOrdersService
    {

        private readonly NorthwindDb _db;

        public OrdersService(NorthwindDb db)
        {
            _db = db;
        }

        public List<OrderResourceFull> Select()
        {
            return _db.Orders.ProjectTo<OrderResourceFull>().ToList();
        }

        public async Task<OrderResourceFull> SingleAsync(int id)
        {
            Order entity = await FindAsync(id);
            return Mapper.Map<OrderResourceFull>(entity);
        }

        public async Task<OrderResource> AddAsync(OrderResource resource)
        {
            Order entity = ToEntity(resource);
            _db.Orders.Add(entity);
            await _db.SaveChangesAsync();
            return ToResource(entity);
        }

        public async Task<OrderResource> ReplaceAsync(int id, OrderResource resource)
        {
            Order entity = await FindAsync(id);
            Mapper.Map(resource, entity);
            await _db.SaveChangesAsync();
            return ToResource(entity);
        }

        public async Task RemoveAsync(int id)
        {
            Order entity = await FindAsync(id);
            _db.Orders.Remove(entity);
            await _db.SaveChangesAsync();
        }

        private async Task<Order> FindAsync(int id)
        {
            var entity = await _db.Orders.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException();
            return entity;
        }

        private static Order ToEntity(OrderResource resource) => Mapper.Map<Order>(resource);

        private static OrderResource ToResource(Order entity) => Mapper.Map<OrderResource>(entity);
    }
}
