using Product.Microservice.Entity;
using Product.Microservice.Intefaces.IRepository;
using Product.Microservice.Intefaces.IService;
using Product.Microservice.ProductDto;

namespace Product.Microservice.Implementation.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductsRepository _productsRepository;
        public ProductService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public ProductResponseModel AddProduct(ProductsDto product)
        {
            var prod = new Products()
            {
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity
            };
            var add = _productsRepository.AddProduct(prod);
            if(add)
            {
                return new ProductResponseModel 
                {
                    IsSuccess = true,
                    Message = "Product Added Successfully"
                };
            }
            return new ProductResponseModel
            {
                IsSuccess = false,
                Message = "Failed"
            };
        }

        public ProductsResponseModel AllProducts()
        {
            var products = _productsRepository.GetAll().Select(x => new ProductsDto()
            {
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductQuantity = x.ProductQuantity,
                ProductId = x.ProductId
            }).ToList();
            if (products.Any())
            {
                return new ProductsResponseModel
                {
                    Data = products,
                    IsSuccess = true,
                    Message = "success"
                };
            }
            return new ProductsResponseModel
            {
                IsSuccess = false,
                Message = "fail"
            };
        }
        public ProductResponseModel DeleteProduct(int id)
        {
            var product = _productsRepository.GetProducts(id);
            if (product == null)
            {
                return new ProductResponseModel 
                {
                    IsSuccess= false,
                    Message= $"Product with Id {id} does not exist"
                };
            }
            var deleteProduct = _productsRepository.DeleteProduct(product);
            if(deleteProduct)
            { 
                return new ProductResponseModel
                {
                    IsSuccess = true,
                    Message = "Product deleted Successfully",
                };
            }
            return new ProductResponseModel
            {
                IsSuccess = false,
                Message = "Product failed to delete",
            };
        }

        public ProductResponseModel GetProduct(int id)
        {
             var product = _productsRepository.GetProducts(id);
            if (product == null)
            {
                return new ProductResponseModel 
                {
                    IsSuccess= false,
                    Message= "failed"
                };
            }
            return new ProductResponseModel
            {
                IsSuccess = true,
                Message = "Success",
                Data = new ProductsDto
                {
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    ProductQuantity = product.ProductQuantity,
                    ProductId = product.ProductId
                }
            };
        }

        public ProductResponseModel UpdateProduct(int id, ProductsDto product)
        {
            var products = _productsRepository.GetProducts(id);
            if (products == null)
            {
                return new ProductResponseModel
                {
                    IsSuccess = false,
                    Message = $"Product with Id {id} does not exist"
                };
            }
            products.ProductPrice = product.ProductPrice;
            product.ProductQuantity = product.ProductQuantity;
            product.ProductName = product.ProductName;
            var updateProduct = _productsRepository.UpdateProduct(products);
            if(updateProduct)
            {
                return new ProductResponseModel
                {
                    IsSuccess = true,
                    Message = $"Product with Id {id} updated successfully"
                };
            }
            return new ProductResponseModel
            {
                IsSuccess = false,
                Message = "fail"
            };
        }
    }
}
