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

    public class CategoriesService : ICategoriesService
    {

        private readonly NorthwindDb _db = new NorthwindDb();

        public IList<CategoryResource> Select()
        {
            return _db.Categories.ProjectTo<CategoryResource>().ToList();
        }

        public async Task<CategoryResource> SingleAsync(int id)
        {
            Category entity = await FindAsync(id);
            return ToResource(entity);
        }

        public async Task<CategoryResource> AddAsync(CategoryResource resource)
        {
            Category entity = ToEntity(resource);
            _db.Categories.Add(entity);
            await _db.SaveChangesAsync();
            return ToResource(entity);
        }

        public async Task<CategoryResource> ReplaceAsync(int id, CategoryResource resource)
        {
            Category entity = await FindAsync(id);
            entity.CategoryName = resource.CategoryName;
            entity.Description = resource.Description;
            await _db.SaveChangesAsync();
            return ToResource(entity);
        }

        public async Task RemoveAsync(int id)
        {
            Category entity = await FindAsync(id);
            _db.Categories.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<byte[]> GetImageAsync(int id)
        {
            Category entity = await FindAsync(id);
            return entity.Picture;
        }

        private async Task<Category> FindAsync(int id)
        {
            var entity = await _db.Categories.FindAsync(id);
            if (entity == null)
                throw  new KeyNotFoundException();
            return entity;
        }

        private static Category ToEntity(CategoryResource resource)
        {
            return Mapper.Map<Category>(resource);
        }

        private static CategoryResource ToResource(Category entity)
        {
            return Mapper.Map<CategoryResource>(entity);
        }
    }
}
