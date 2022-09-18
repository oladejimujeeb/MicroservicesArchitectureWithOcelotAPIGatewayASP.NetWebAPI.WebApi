using Product.Microservice.Entity;
using Product.Microservice.ProductDto;

namespace Product.Microservice.Intefaces.IService
{
    public interface IProductService
    {
        ProductResponseModel AddProduct(ProductsDto product);
        ProductResponseModel UpdateProduct(int id, ProductsDto product);
        ProductResponseModel DeleteProduct(int id);
        ProductResponseModel GetProduct(int id);
        ProductsResponseModel AllProducts();
       
    }
}
