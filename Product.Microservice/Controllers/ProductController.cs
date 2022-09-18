using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Microservice.Intefaces.IService;
using Product.Microservice.ProductDto;
using System.Collections;
using Microsoft.Extensions.Caching.Memory;
using Product.Microservice.Entity;

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private const string Key = "cache";
        private readonly IMemoryCache _memoryCache;
        

        public ProductController(IProductService productService, IMemoryCache memoryCache)
        {
            _productService = productService;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public IActionResult AddProduct([FromBody]ProductsDto product)
        {
           var add = _productService.AddProduct(product);
           if(add.IsSuccess)
           {
                return Ok(add.Message);
           }
           return BadRequest(add.Message);
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            ProductsResponseModel products;
            if (!_memoryCache.TryGetValue(Key, out  products))
            {
                products = _productService.AllProducts(); //Get the data from database

                var option = new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromSeconds(90),
                    //AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    Size = 1024,
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(3)
                };
            
                _memoryCache.Set(Key, products, option);
                return Ok(products);
            }
            Thread.Sleep(2000);
            return Ok(products);
            /*
             if(products.IsSuccess)
             {
                 var result = new ArrayList();
                 result.Add(products.Data);
                 result.Add(products.Message);

                 return Ok(products);
             }
             return BadRequest(products.Message);*/
        }

        [HttpGet("{id}", Name="Get")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetProduct(id);
            if(product.IsSuccess)
            {
                return Ok(product);
            }
            return BadRequest(product.Message);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var del = _productService.DeleteProduct(id);
            if(del.IsSuccess)
            {
                return Ok(del.Message);
            }
            return BadRequest(del.Message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductsDto product)
        {
            var update = _productService.UpdateProduct(id, product);
            if(update.IsSuccess)
            {
                return Ok(update.Message);
            }
            return BadRequest(update.Message);
        }
    }
}
