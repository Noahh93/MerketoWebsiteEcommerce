using AssignmentMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentMVC.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationDBContext _context;


        public ProductRepository() 
        {
            _context = new ApplicationDBContext();
        }
        public Product GetProductByID(int id)
        {
            Product product = _context.Products.Include(x => x.Category).Include(x => x.ProductCategory).Where(x => x.Id == id).FirstOrDefault();
            return product;
        }
        public List<Product> GetAllProducts()
        {
            List<Product> products = _context.Products.ToList();
            return products;
        }
        public bool SaveProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
