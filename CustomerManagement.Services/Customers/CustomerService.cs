using System;
using CustomerManagement.Domain;

namespace CustomerManagement.Services.Customers
{
    public class CustomerService
    {
        public readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            customerRepository = customerRepository;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await customerRepository.GetByIdAsync(id);
            return customer;
        }
    }
}