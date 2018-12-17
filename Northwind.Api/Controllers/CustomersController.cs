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
    public class CustomersController : ApiController
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        // GET: api/Customers
        public IList<CustomerResource> GetCustomers() => _customersService.Select();

        // GET: api/Customers/5
        [ResponseType(typeof(CustomerResource))]
        public async Task<IHttpActionResult> GetCustomer(string id)
        {
            try
            {
                CustomerResource resource = await _customersService.SingleAsync(id);
                return Ok(resource);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomer(string id, CustomerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            resource.Id = id;

            await _customersService.ReplaceAsync(id, resource);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(CustomerResource))]
        public async Task<IHttpActionResult> PostCustomer(CustomerResource resoure)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CustomerResource result =  await _customersService.AddAsync(resoure);

            return CreatedAtRoute("DefaultApi", new {id = result.Id}, result);
        }

        // DELETE: api/Customers/5
        public async Task<IHttpActionResult> DeleteCustomer(string id)
        {
            try
            {
                await _customersService.RemoveAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

    }
}