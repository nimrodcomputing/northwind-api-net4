using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Data;
using Northwind.Services.Interfaces;

namespace Northwind.Services
{
    public class ImagesService : IImagesService
    {

        private readonly NorthwindDb _db;

        public ImagesService(NorthwindDb db)
        {
            _db = db;
        }

        #region Implementation of IImagesService

        public async Task<byte[]> Category(int id)
        {
            try
            {
                var image = await _db.Categories.Where(c => c.Id == id)
                    .Select(c => c.Picture).SingleAsync();
                return image;
            }
            catch (InvalidOperationException)
            {
                throw new KeyNotFoundException();
            }
        }

        public async Task<byte[]> Employee(int id)
        {
            try
            {
                var image = await _db.Employees.Where(e => e.Id == id)
                    .Select(c => c.Photo).SingleAsync();
                return image;
            }
            catch (InvalidOperationException)
            {
                throw new KeyNotFoundException();
            }
        }

        #endregion

    }
}