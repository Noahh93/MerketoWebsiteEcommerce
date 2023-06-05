using AssignmentMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentMVC.Repositories
{
    public class ProductCategoryRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductCategoryRepository()
        {
            _context = new ApplicationDBContext();
        }
        public List<ProductCategory> GetAllProductCategories() //PRODUCTCATEGORY
        {
            List<ProductCategory> productCategories = _context.ProductCategories.ToList();
            return productCategories;
        }
    }
}
