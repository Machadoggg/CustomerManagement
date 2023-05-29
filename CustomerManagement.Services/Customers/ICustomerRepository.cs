using CustomerManagement.Domain;

namespace CustomerManagement.Services.Customers
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();

        Task<IEnumerable<Customer>> GetByNameAsync(string nombre);

        Task<IEnumerable<Customer>> GetByDocumentAsync(string documento);

        Task<Customer> GetByIdAsync(int id);

        Task<Customer> CreateAsync(Customer customer);

        Task<Customer> UpdateAsync(Customer customer);

        Task DeleteAsync(int id);

        Task<IEnumerable<Customer>> GetDateRangeAsync(DateTime fechaInicial, DateTime fechaFinal);
    }
}