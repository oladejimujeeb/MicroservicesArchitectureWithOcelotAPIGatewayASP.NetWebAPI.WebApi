using Customer.Microservice.CustomerDto;
using Customer.Microservice.Interface.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        
        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }
        [HttpPut]
        public ActionResult RegisterCustomer(CustomersDto request)
        {
            var register = _customerServices.RegisterCustomer(request);
            if(register.Status)
            {
                return Ok(register.Message);
            }
            return BadRequest(register.Message);
        }

        [HttpGet("{email}")]
        public ActionResult GetCustomer(string email)
        {
            var cus = _customerServices.GetCustomer(email);
            if(cus.Status)
            {
                return Ok(cus.Data);
            }
            return BadRequest(cus.Message);
        }
        [HttpGet]
        public ActionResult GetAllCustomer()
        {
            var cus = _customerServices.GetAllCustomer();
            if(cus.Status)
            {
                return Ok(cus.Data);
            }
            return BadRequest(cus.Message);
        }
        [HttpDelete("{email}")]
        public ActionResult DeleteCustomer(string email)
        {
            var cus = _customerServices.DeleteCustomer(email);
            if (cus.Status)
            {
                return Ok(cus.Message);
            }
            return BadRequest(cus.Message);
        }
    }
}
