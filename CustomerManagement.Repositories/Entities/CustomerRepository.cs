using CustomerManagement.API.Data;
using CustomerManagement.Domain;
using CustomerManagement.Services.Customers;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Customer>> GetAllAsync(string? nombre, string? documento)
        {
                var customers = await _context.Customers.ToListAsync();
                if (nombre != null)
                {
                    customers = customers
                        .Where(c => c.Nombres.ToLower().Contains(nombre.ToLower()))
                        .OrderBy(c => c.Nombres)
                        .ToList();
                    return customers;
                }
                if (documento != null)
                {
                    customers = customers
                        .Where(c => c.NumeroDocumento.ToString().Contains(documento))
                        .OrderBy(c => c.NumeroDocumento)
                        .ToList();
                    return customers;
                }
                return customers;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Codigo == id);
            return customer;
        }

        public async Task<Customer> PostAsync(Customer customer)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - customer.FechaNacimiento.Year;

            try
            {
                if (age >= 0 && age <= 7 && customer.TipoDocumento != "Registro Civil (RC)")
                {
                    throw new Exception("El documento debe ser Registro Civil (RC) para clientes de 0 a 7 años.");
                }
                else if (age >= 8 && age <= 17 && customer.TipoDocumento != "Tarjeta Identidad (TI)")
                {
                    throw new Exception("El documento debe ser Tarjeta Identidad (TI) para clientes de 8 a 17 años.");
                }
                else if (age > 18 && customer.TipoDocumento != "Cedula Ciudadanía (CC)")
                {
                    throw new Exception("El documento debe ser Cedula Ciudadanía (CC) para clientes mayores de 18 años.");
                }
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return (customer);
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        public async Task<Customer> PutAsync(Customer customer)
        {
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                return customer;
        }

        public async Task<Customer> DeleteAsync(int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Codigo == id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}