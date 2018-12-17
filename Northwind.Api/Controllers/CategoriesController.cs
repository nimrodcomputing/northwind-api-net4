using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Northwind.Resources;
using Northwind.Services.Interfaces;

namespace Northwind.Api.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        // GET: api/Categories
        public IList<CategoryResource> GetCategories() => _categoriesService.Select();

        // GET: api/Categories/5
        [ResponseType(typeof(CategoryResource))]
        public async Task<IHttpActionResult> GetCategory(int id)
        {
            try
            {
                CategoryResource resource = await _categoriesService.SingleAsync(id);
                return Ok(resource);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategory(int id, CategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            resource.Id = id;

            await _categoriesService.ReplaceAsync(id, resource);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [ResponseType(typeof(CategoryResource))]
        public async Task<IHttpActionResult> PostCategory(CategoryResource resoure)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CategoryResource result =  await _categoriesService.AddAsync(resoure);

            return CreatedAtRoute("DefaultApi", new {id = result.Id}, result);
        }

        // DELETE: api/Categories/5
        public async Task<IHttpActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoriesService.RemoveAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

    }
}