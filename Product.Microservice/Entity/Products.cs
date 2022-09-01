using System.ComponentModel.DataAnnotations;

namespace Product.Microservice.Entity
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        [Required]
        public int ProductQuantity { get; set; }    
       
    }
}
