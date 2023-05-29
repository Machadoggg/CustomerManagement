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
            var customers = await _context.Customers.FromSqlRaw("EXEC GetCustomers").ToListAsync();
            return CustomersToList(customers);
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Codigo == id);
            return PeristenceToCustomer(customer);
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            var newCustomer = CustomerToPeristence(customer);
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();
            return (customer);
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            var newCustomer = CustomerToPeristence(customer);
            _context.Customers.Update(newCustomer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Codigo == id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return;
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
                return CustomersToList(customers);
            }
            return CustomersToList(customers);
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
                return CustomersToList(customers);
            }
            return CustomersToList(customers);
        }

        public async Task<IEnumerable<Customer>> GetDateRangeAsync(DateTime fechaInicial, DateTime fechaFinal)
        {
            var customers = _context.Customers
                .Where(c => c.FechaNacimiento >= fechaInicial && c.FechaNacimiento <= fechaFinal)
                .OrderBy(c => c.FechaNacimiento)
                .ToList();

            return CustomersToList(customers);
        }

        private Entities.Customer CustomerToPeristence(Customer customer)
        {
            return new Entities.Customer
            {
                Codigo = customer.Codigo,
                TipoDocumento = customer.TipoDocumento,
                NumeroDocumento = customer.NumeroDocumento,
                Nombres = customer.Nombres,
                Apellido_1 = customer.Apellido_1,
                Apellido_2 = customer.Apellido_2,
                Genero = customer.Genero,
                FechaNacimiento = customer.FechaNacimiento,
                Direcciones = customer.Direcciones,
                Telefonos = customer.Telefonos,
                Emails = customer.Emails
            };
        }

        private Customer PeristenceToCustomer(Entities.Customer customer)
        {
            return new Customer
            {
                Codigo = customer.Codigo,
                TipoDocumento = customer.TipoDocumento,
                NumeroDocumento = customer.NumeroDocumento,
                Nombres = customer.Nombres,
                Apellido_1 = customer.Apellido_1,
                Apellido_2 = customer.Apellido_2,
                Genero = customer.Genero,
                FechaNacimiento = customer.FechaNacimiento,
                Direcciones = customer.Direcciones,
                Telefonos = customer.Telefonos,
                Emails = customer.Emails
            };
        }

        private List<Customer> CustomersToList(List<Entities.Customer> customers)
        {
            var newCustomers = new List<Customer>();
            foreach (var customer in customers)
            {
                newCustomers.Add(PeristenceToCustomer(customer));

            }
            return newCustomers;

        }
    }
}