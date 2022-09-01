using Customer.Microservice.CustomerDto;

namespace Customer.Microservice.Interface.IServices
{
    public interface ICustomerServices
    {
        CustomerResponseModel RegisterCustomer(CustomersDto request);
        CustomerResponseModel GetCustomer(string email);
        CustomerResponseModel DeleteCustomer(string email);
        CustomersResponseModel GetAllCustomer();
    }
}
