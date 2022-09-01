using Customer.Microservice.Context;
using Customer.Microservice.Entities;
using Customer.Microservice.Interface.IRepository;

namespace Customer.Microservice.Implementation.Repositories
{
    public class CustomerRepository : ICustomersRepository
    {
        private readonly MyAppContext _context;
        public CustomerRepository(MyAppContext context)
        {
            _context = context;
        }
        public bool AddCustomer(Customers customer)
        {
            var addCustomer = _context.Customers.Add(customer);
            _context.SaveChanges();
            return addCustomer != null;
        }

        public bool DeleteCustomer(Customers customers)
        {
            _context.Customers.Remove(customers);
            _context.SaveChanges();
            return true;
        }

        public List<Customers> GetAllCustomers()
        {
           var customers = _context.Customers.ToList();
            return customers;
        }

        public Customers GetCustomer(string email)
        {
            var getCustomer = _context.Customers.FirstOrDefault(x => x.Email == email);
            return getCustomer;
        }
    }
}
