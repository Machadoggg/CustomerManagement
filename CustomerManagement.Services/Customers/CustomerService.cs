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


        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers;
        }
        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return customer;
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            try
            {
                ValidateAgeDocument(customer);
                var customerPost = await _customerRepository.CreateAsync(customer);
                return customerPost;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ValidateAgeDocument(Customer customer)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - customer.FechaNacimiento.Year;

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

            return true;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            var customerPost = await _customerRepository.UpdateAsync(customer);
            return customerPost;
        }

        public async Task DeleteAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
            return;
        }

        public async Task<IEnumerable<Customer>> GetByNameAsync(string nombre)
        {
            var customers = await _customerRepository.GetByNameAsync(nombre);
            return customers;
        }

        public async Task<IEnumerable<Customer>> GetByDocumentAsync(string documento)
        {
            var customers = await _customerRepository.GetByDocumentAsync(documento);
            return customers;
        }

        public async Task<IEnumerable<Customer>> GetDateRangeAsync(DateTime fechaInicial, DateTime fechaFinal)
        {
            var customers = await _customerRepository.GetDateRangeAsync(fechaInicial, fechaFinal);
            return customers;
        }
    }
}