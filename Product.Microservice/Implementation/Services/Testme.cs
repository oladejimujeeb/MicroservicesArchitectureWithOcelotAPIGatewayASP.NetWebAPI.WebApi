using Microsoft.AspNetCore.Mvc;
using Product.Microservice.ProductDto;

namespace Product.Microservice.Implementation.Services
{
    public class Testme
    {
        public bool ChangeProduct(ProductsDto products)
        {
            if (products.ProductQuantity < 10)
            {
                products.ProductPrice = products.ProductPrice * 10;
                return true;
            }
            return false;
        }

    }
}

public class CustomerController 
{
    public ActionResult GetCustomer(int id)
    {
        if (id == 0)
            return new NotFound();

        return new Ok();
    }
}

public class ActionResult { }

public class NotFound : ActionResult { }

public class Ok : ActionResult { }

