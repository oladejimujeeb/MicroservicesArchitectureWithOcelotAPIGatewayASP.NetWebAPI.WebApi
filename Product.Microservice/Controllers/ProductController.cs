using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Microservice.Intefaces.IService;
using Product.Microservice.ProductDto;
using System.Collections;

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
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
        public ActionResult GetAllProducts()
        {
            var products = _productService.AllProducts();
            if(products.IsSuccess)
            {
                var result = new ArrayList();
                result.Add(products.Data);
                result.Add(products.Message);

                return Ok(products);
            }
            return BadRequest(products.Message);
        }
        [HttpGet("{id}", Name="Get")]
        public ActionResult GetProduct(int id)
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
