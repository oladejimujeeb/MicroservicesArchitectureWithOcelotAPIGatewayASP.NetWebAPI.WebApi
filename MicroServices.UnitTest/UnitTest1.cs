using NUnit.Framework;
using Product.Microservice.Implementation.Services;
using Product.Microservice.ProductDto;
using Assert = NUnit.Framework.Assert;
using IgnoreAttribute = NUnit.Framework.IgnoreAttribute;

namespace MicroServices.UnitTest
{
    [TestFixture]
    public class TestMe
    {
        [Test]
        [Ignore("This just for testing nothing much")]
        public void ProductLessThanTen_ChangesPrice_ReturnTrue()
        {
            var product = new ProductsDto() 
            {
                ProductId = 1,
                ProductName = "Milo",
                ProductPrice = 80,
                ProductQuantity = 6
            };

            var test = new Testme();
            var result = test.ChangeProduct(product);

            Assert.IsTrue(result);
        }
    }
}