using CustomerManagement.Domain;

namespace CustomerManagement.Services.Customers
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync(string? nombre, string? documento);

        Task<Customer> GetByIdAsync(int id);

        Task<Customer> PostAsync(Customer customer);

        Task<Customer> PutAsync(Customer customer);

        Task<Customer> DeleteAsync(int id);
    }
}