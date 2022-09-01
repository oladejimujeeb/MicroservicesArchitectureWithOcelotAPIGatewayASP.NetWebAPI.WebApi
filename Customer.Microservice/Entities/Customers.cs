using System.ComponentModel.DataAnnotations;

namespace Customer.Microservice.Entities
{
    public class Customers
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DoB { get; set; }
        [Required]
        public string Address { get; set; }

    }
}
