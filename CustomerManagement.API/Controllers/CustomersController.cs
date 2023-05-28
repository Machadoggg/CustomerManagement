using CustomerManagement.Domain;
using CustomerManagement.Services.Customers;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.API.Controllers
{
    [ApiController]
    [Route("/api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService CustomerService)
        {
            _customerService = CustomerService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string? nombre, string? documento)
        {
            try
            {
                var customers = await _customerService.GetAllAsync(nombre, documento);
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Customer customer)
        {
            try
            {
                var customerPost = await _customerService.PostAsync(customer);
                return Ok(customerPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Customer customer)
        {
            var customerPut = await _customerService.PutAsync(customer);
            return Ok(customerPut);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var customer = await _customerService.DeleteAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
