using Customer.Microservice.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Customer.Microservice.CustomerDto
{
    public class CustomersDto
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        
        public string Email { get; set; }
        [Required]
        [DisplayName("Date of Birth")]
        public DateTime DoB { get; set; }
        [Required]
        public string Address { get; set; }

    }
}
