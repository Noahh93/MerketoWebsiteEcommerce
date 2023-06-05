using AssignmentMVC.Models;

namespace AssignmentMVC.Repositories
{
    public class CategoryRepository
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepository() 
        {
            _context = new ApplicationDBContext();
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories = _context.Categories.ToList();
            return categories;
        }
        public Category GetCategoryByName(string name)
        {
            Category category = _context.Categories.Where(x => x.Name == name).FirstOrDefault(); //Read(Fetch) from database
            // '=>' = Lambda expression means current object    //select top 1 Name from Categories where Name = 'example'
            return category;
        }
        public bool SaveCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
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
