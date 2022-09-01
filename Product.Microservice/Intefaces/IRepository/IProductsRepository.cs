using Product.Microservice.Entity;

namespace Product.Microservice.Intefaces.IRepository
{
    public interface IProductsRepository
    {
        public bool AddProduct(Products product);
        public bool DeleteProduct(Products product);
        public Products GetProducts(int id);
        public IList<Products> GetAll();
        public bool UpdateProduct(Products product);
    }
}
