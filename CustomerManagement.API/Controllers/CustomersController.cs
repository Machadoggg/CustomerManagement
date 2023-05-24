using CustomerManagement.API.Data;
using CustomerManagement.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.API.Controllers
{
    [ApiController]
    [Route("/api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomersController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAsync(string? nombre, string? documento)
        {
            try
            {
                var customers = _context.Customers.ToList();
                if (nombre != null)
                {
                    customers = customers
                        .Where(c => c.Nombres.ToLower().Contains(nombre.ToLower()))
                        .OrderBy(c => c.Nombres)
                        .ToList();

                    return Ok(customers);
                }
                if (documento != null)
                {
                    customers = customers
                        .Where(c => c.NumeroDocumento.ToString().Contains(documento))
                        .OrderBy(c => c.Nombres)
                        .ToList();
                    return Ok(customers);
                }
                
                return Ok(customers);
                

                

            }
            catch (Exception)
            {

                return BadRequest("Error.");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        { 
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Codigo == id); 
            if (customer == null) 
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Codigo == id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
