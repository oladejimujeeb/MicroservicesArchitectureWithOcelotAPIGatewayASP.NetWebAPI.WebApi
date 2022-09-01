using Customer.Microservice.CustomerDto;
using Customer.Microservice.Entities;
using Customer.Microservice.Interface.IRepository;
using Customer.Microservice.Interface.IServices;

namespace Customer.Microservice.Implementation.Services
{
    public class CustomerService : ICustomerServices
    {
        private readonly ICustomersRepository _customerRepository;
        public CustomerService(ICustomersRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerResponseModel DeleteCustomer(string email)
        {
            var cus = _customerRepository.GetCustomer(email);
            if(cus ==null)
            {
                return new CustomerResponseModel 
                { 
                    Status = false,
                    Message= "failed"
                };
            }

            var delete = _customerRepository.DeleteCustomer(cus);
            if(delete)
            {
                return new CustomerResponseModel
                {
                    Status = true,
                    Message = "Delete Successfully"
                };
            }
            else
            {
                return new CustomerResponseModel
                {
                    Status = false,
                    Message = "failed"
                };
            }

        }

        public CustomersResponseModel GetAllCustomer()
        {
            var cus = _customerRepository.GetAllCustomers().Select(customer => new CustomersDto
            {
                Address = customer.Address,
                DoB = customer.DoB,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            }).ToList();
            if (cus.Any())
            {
                return new CustomersResponseModel
                {
                    Status = true,
                    Message = "Success",
                    Data = cus
                };
            }
            return new CustomersResponseModel()
            {
                Status = false,
                Message = "No Customer"
            };


        }

        public CustomerResponseModel GetCustomer(string email)
        {
            var customer = _customerRepository.GetCustomer(email);
            if(customer != null)
            {
                var cus = new CustomersDto()
                {
                    Address = customer.Address,
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DoB = customer.DoB
                };
                return new CustomerResponseModel()
                {
                    Data = cus,
                    Status = true,
                    Message ="Success"
                };
            }
            
            return new CustomerResponseModel()
            {
                Status = false,
                Message = "failed"
            };
        }

        public CustomerResponseModel RegisterCustomer(CustomersDto request)
        {
            var cus = new Customers 
            { 
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                DoB = request.DoB,
                Email = request.Email,
            };
            var add=  _customerRepository.AddCustomer(cus);
            if(!add)
            {
                return new CustomerResponseModel()
                {
                    Status = false,
                    Message ="Failed Added"
                };
            }
            return new CustomerResponseModel()
            {
                Status = true,
                Message = "Successfuly Added"
            };
        }
    }
}
