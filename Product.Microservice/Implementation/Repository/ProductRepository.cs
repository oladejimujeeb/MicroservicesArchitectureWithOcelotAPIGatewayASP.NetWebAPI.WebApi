using Product.Microservice.Entity;
using Product.Microservice.Intefaces.IRepository;
using Product.Microservice.MyContext;

namespace Product.Microservice.Implementation.Repository
{
    public class ProductRepository : IProductsRepository
    {
        private readonly AppContx _context;
        public ProductRepository(AppContx appContx)
        {
            _context = appContx;
        }
        public bool AddProduct(Products product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteProduct(Products product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public IList<Products> GetAll()
        {
            var products = _context.Products.ToList();
            return products;
        }

        public Products GetProducts(int id)
        {
            var product = _context.Products.Find(id);
            return product;
        }

        public bool UpdateProduct(Products product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return true;
        }
    }
}
