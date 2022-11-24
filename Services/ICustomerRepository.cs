using Exercices10.Models;

namespace Exercices10.Services
{
    public interface ICustomerRepository
    {
        List<Customer2> GetCustomers();
        Customer2 AddCustomer(Customer2 customer);
        Customer2 UpdateCustomer(Customer2 customer);    
        Customer2 DeleteCustomer(Customer2 customer);
        Customer2 GetCustomerById(int id);
    }
}
