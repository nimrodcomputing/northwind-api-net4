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
    public class EmployeesController : ApiController
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        // GET: api/Employees
        public IList<EmployeeResource> GetEmployees() => _employeesService.Select();

        // GET: api/Employees/5
        [ResponseType(typeof(EmployeeResource))]
        public async Task<IHttpActionResult> GetEmployee(int id)
        {
            try
            {
                EmployeeResource resource = await _employeesService.SingleAsync(id);
                return Ok(resource);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployee(int id, EmployeeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            resource.Id = id;

            await _employeesService.ReplaceAsync(id, resource);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [ResponseType(typeof(EmployeeResource))]
        public async Task<IHttpActionResult> PostEmployee(EmployeeResource resoure)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            EmployeeResource result =  await _employeesService.AddAsync(resoure);

            return CreatedAtRoute("DefaultApi", new {id = result.Id}, result);
        }

        // DELETE: api/Employees/5
        public async Task<IHttpActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeesService.RemoveAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

    }
}