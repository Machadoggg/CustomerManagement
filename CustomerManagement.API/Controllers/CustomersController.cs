using CustomerManagement.API.Data;
using CustomerManagement.Domain;
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


        //[HttpGet]
        //public IActionResult GetAsync(string? nombre, string? documento)
        //{
        //    try
        //    {
        //        var customers = _context.Customers.ToList();
        //        if (nombre != null)
        //        {
        //            customers = customers
        //                .Where(c => c.Nombres.ToLower().Contains(nombre.ToLower()))
        //                .OrderBy(c => c.Nombres)
        //                .ToList();
        //            return Ok(customers);
        //        }
        //        if (documento != null)
        //        {
        //            customers = customers
        //                .Where(c => c.NumeroDocumento.ToString().Contains(documento))
        //                .OrderBy(c => c.NumeroDocumento)
        //                .ToList();
        //            return Ok(customers);
        //        }
        //        return Ok(customers);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

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

        //[HttpPost]
        //public async Task<ActionResult> PostAsync(Customer customer)
        //{
        //    try
        //    {
        //        DateTime currentDate = DateTime.Now;
        //        int age = currentDate.Year - customer.FechaNacimiento.Year;

        //        if (age >= 0 && age <= 7 && customer.TipoDocumento != "Registro Civil (RC)")
        //        {
        //            return BadRequest("El documento debe ser Registro Civil (RC) para clientes de 0 a 7 años.");
        //        }
        //        if (age >= 8 && age <= 17 && customer.TipoDocumento != "Tarjeta Identidad (TI)")
        //        {
        //            return BadRequest("El documento debe ser Tarjeta Identidad (TI) para clientes de 8 a 17 años.");
        //        }
        //        if (age > 18 && customer.TipoDocumento != "Cedula Ciudadanía (CC)")
        //        {
        //            return BadRequest("El documento debe ser Cedula Ciudadanía (CC) para clientes mayores de 18 años.");
        //        }
        //        _context.Customers.Add(customer);
        //        await _context.SaveChangesAsync();
        //        return Ok(customer);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPut]
        //public async Task<ActionResult> PutAsync(Customer customer)
        //{
        //    try
        //    {
        //        _context.Customers.Update(customer);
        //        await _context.SaveChangesAsync();
        //        return Ok(customer);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpDelete("{id:int}")]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Codigo == id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Customers.Remove(customer);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

    }
}
