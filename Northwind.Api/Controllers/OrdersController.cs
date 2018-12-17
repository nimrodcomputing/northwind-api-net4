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
    public class OrdersController : ApiController
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        // GET: api/Orders
        public IList<OrderResourceFull> GetOrders() => _ordersService.Select();

        // GET: api/Orders/5
        [ResponseType(typeof(OrderResource))]
        public async Task<IHttpActionResult> GetOrder(int id)
        {
            try
            {
                OrderResourceFull resource = await _ordersService.SingleAsync(id);
                return Ok(resource);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrder(int id, OrderResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            resource.Id = id;

            await _ordersService.ReplaceAsync(id, resource);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Orders
        [ResponseType(typeof(OrderResource))]
        public async Task<IHttpActionResult> PostOrder(OrderResource resoure)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            OrderResource result =  await _ordersService.AddAsync(resoure);

            return CreatedAtRoute("DefaultApi", new {id = result.Id}, result);
        }

        // DELETE: api/Orders/5
        public async Task<IHttpActionResult> DeleteOrder(int id)
        {
            try
            {
                await _ordersService.RemoveAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

    }
}