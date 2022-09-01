using System.ComponentModel.DataAnnotations;

namespace Product.Microservice.ProductDto
{
    public class ProductsDto
    {
        public int ProductId;
        [Required]
        public string ProductName { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double ProductPrice { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
    }
    public class ProductResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ProductsDto Data { get; set; }
    }
    public class ProductsResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public IEnumerable<ProductsDto> Data { get; set; }
    }
}
