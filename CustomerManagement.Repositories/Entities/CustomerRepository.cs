using CustomerManagement.Persistence.Data;
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


        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var customers = await _context.Customers.FromSqlRaw<Customer>("EXEC GetCustomers").ToListAsync();
            return customers;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Codigo == id);
            return customer;
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return (customer);
        }

        public async Task<Customer> UpdateAsync(Customer customer)
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

        public async Task<IEnumerable<Customer>> GetByNameAsync(string nombre)
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
            return customers;
        }

        public async Task<IEnumerable<Customer>> GetByDocumentAsync(string documento)
        {
            var customers = await _context.Customers.ToListAsync();
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

        public async Task<IEnumerable<Customer>> GetDateRangeAsync(DateTime fechaInicial, DateTime fechaFinal)
        {
            var customers = _context.Customers
                .Where(c => c.FechaNacimiento >= fechaInicial && c.FechaNacimiento <= fechaFinal)
                .OrderBy(c => c.FechaNacimiento)
                .ToList();

            return customers;
        }
    }
}