using CustomerManagement.Domain;

namespace CustomerManagement.Services.Customers
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int id);
    }
}