using System;
using CustomerManagement.Domain;

namespace CustomerManagement.Services.Customers
{
    public class CustomerService
    {
        public readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<IEnumerable<Customer>> GetAllAsync(string? nombre, string? documento)
        {
            var customers = await _customerRepository.GetAllAsync(nombre, documento);
            return customers;
        }
        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return customer;
        }

        public async Task<Customer> PostAsync(Customer customer)
        {
           
                var customerPost = await _customerRepository.PostAsync(customer);
                return customerPost;
            
            
        }

        public async Task<Customer> PutAsync(Customer customer)
        {
            var customerPost = await _customerRepository.PutAsync(customer);
            return customerPost;
        }

        public async Task<Customer> DeleteAsync(int id)
        {
            var customer = await _customerRepository.DeleteAsync(id);
            return customer;
        }
    }
}