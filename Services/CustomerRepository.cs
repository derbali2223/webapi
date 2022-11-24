using Exercices10.Models;

namespace Exercices10.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly derbali2223_5w6Context context;

        public CustomerRepository(derbali2223_5w6Context context)
        {
            this.context = context;
        }

        public List<Customer2> GetCustomers()
        {
            return context.Customer2s.ToList();
        }

        public Customer2 AddCustomer(Customer2 customer)
        {
            var newCustomer =  context.Add(customer).Entity;
            context.SaveChanges();
            return newCustomer;
  
        }

        public Customer2 UpdateCustomer(Customer2 customer)
        {
            var updatedCustomer = context.Update(customer).Entity;
            context.SaveChanges();
            return updatedCustomer;
        }

        public Customer2 DeleteCustomer(Customer2 customer)
        {
            var deletedCustomer = context.Remove(customer).Entity;
            context.SaveChanges();
            return deletedCustomer;
        }

        public Customer2 GetCustomerById(int id)
        {
            return context.Customer2s.Find(id);
        }
    }
}
