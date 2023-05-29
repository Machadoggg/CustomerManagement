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
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var customers = await _customerService.GetAllAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByNameAsync/{nombre}")]
        public async Task<IActionResult> GetByNameAsync(string nombre)
        {
            try
            {
                var customers = await _customerService.GetByNameAsync(nombre);
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByDocumentAsync/{documento}")]
        public async Task<IActionResult> GetByDocumentAsync(string documento)
        {
            try
            {
                var customers = await _customerService.GetByDocumentAsync(documento);
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
        public async Task<ActionResult> CreateAsync(Customer customer)
        {
            try
            {
                var customerPost = await _customerService.CreateAsync(customer);
                return Ok(customerPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Customer customer)
        {
            var customerPut = await _customerService.UpdateAsync(customer);
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


        [HttpGet("GetDatesByRange/")]
        public async Task<IActionResult> GetDateRangeAsync(DateTime fechaInicial, DateTime fechaFinal)
        {
            var customers = _customerService.GetDateRangeAsync(fechaInicial, fechaFinal);
            return Ok(customers);
        }
    }
}
