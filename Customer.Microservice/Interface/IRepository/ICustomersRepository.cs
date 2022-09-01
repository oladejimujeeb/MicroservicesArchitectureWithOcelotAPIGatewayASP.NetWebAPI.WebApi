using Customer.Microservice.Entities;

namespace Customer.Microservice.Interface.IRepository
{
    public interface ICustomersRepository
    {
        bool AddCustomer(Customers customer);
        Customers GetCustomer(string email);
        List<Customers> GetAllCustomers();
        bool DeleteCustomer(Customers customers);
    }
}
