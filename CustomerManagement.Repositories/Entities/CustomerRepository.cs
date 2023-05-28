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
        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Codigo == id);
            return customer;
        }
    }

    //public class CustomerRepositoryMySQL : ICustomerRepository
    //{
    //    public Task<Customer> GetByIdAsync(int id)
    //    {
    //        var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Codigo == id);
    //    }
    //}

    //public class CustomerRepositoryAPI : ICustomerRepository
    //{
    //    public Task<Customer> GetByIdAsync(int id)
    //    {
    //        var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Codigo == id);
    //    }
    //}
}