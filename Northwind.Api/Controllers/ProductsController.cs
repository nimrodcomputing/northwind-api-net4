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
    public class ProductsController : ApiController
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        // GET: api/Products
        public IList<ProductResource> GetProducts() => _productsService.Select();

        // GET: api/Products/5
        [ResponseType(typeof(ProductResource))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            try
            {
                ProductResource resource = await _productsService.SingleAsync(id);
                return Ok(resource);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(int id, ProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            resource.Id = id;

            await _productsService.ReplaceAsync(id, resource);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(ProductResource))]
        public async Task<IHttpActionResult> PostProduct(ProductResource resoure)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ProductResource result =  await _productsService.AddAsync(resoure);

            return CreatedAtRoute("DefaultApi", new {id = result.Id}, result);
        }

        // DELETE: api/Products/5
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productsService.RemoveAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

    }
}