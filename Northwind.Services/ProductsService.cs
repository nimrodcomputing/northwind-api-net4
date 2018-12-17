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

    public class ProductsService : IProductsService
    {

        private readonly NorthwindDb _db;

        public ProductsService(NorthwindDb db)
        {
            _db = db;
        }

        public IList<ProductResource> Select()
        {
            return _db.Products.ProjectTo<ProductResource>().ToList();
        }

        public async Task<ProductResource> SingleAsync(int id)
        {
            Product entity = await FindAsync(id);
            return ToResource(entity);
        }

        public async Task<ProductResource> AddAsync(ProductResource resource)
        {
            Product entity = ToEntity(resource);
            _db.Products.Add(entity);
            await _db.SaveChangesAsync();
            return ToResource(entity);
        }

        public async Task<ProductResource> ReplaceAsync(int id, ProductResource resource)
        {
            Product entity = await FindAsync(id);
            Mapper.Map(resource, entity);
            await _db.SaveChangesAsync();
            return ToResource(entity);
        }

        public async Task RemoveAsync(int id)
        {
            Product entity = await FindAsync(id);
            _db.Products.Remove(entity);
            await _db.SaveChangesAsync();
        }

        private async Task<Product> FindAsync(int id)
        {
            var entity = await _db.Products.FindAsync(id);
            if (entity == null)
                throw  new KeyNotFoundException();
            return entity;
        }

        private static Product ToEntity(ProductResource resource)
        {
            return Mapper.Map<Product>(resource);
        }

        private static ProductResource ToResource(Product entity)
        {
            return Mapper.Map<ProductResource>(entity);
        }
    }
}
