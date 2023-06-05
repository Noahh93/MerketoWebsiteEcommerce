using AssignmentMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using AssignmentMVC.Models;
using AssignmentMVC.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace AssignmentMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _webhostenvironment; 
        public ProductController(IWebHostEnvironment webhostenvironment) //It gives the object of wwwroot
        {
            _webhostenvironment = webhostenvironment; //assigned here
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {

            CategoryRepository categoryRepository = new CategoryRepository();
            ProductCategoryRepository productCategoryRepository = new ProductCategoryRepository();

            ViewBag.Categories = categoryRepository.GetAllCategories();
            ViewBag.ProductCategories = productCategoryRepository.GetAllProductCategories();

            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult SaveProduct(ProductViewModel productViewModel)
        {
            ProductRepository productRepository = new ProductRepository();
            Product product = new Product();
            Category category = new Category();
            ProductCategory productCategory = new ProductCategory();

            if(ModelState.IsValid)
            {
                product.Name =              productViewModel.Name;
                product.Description =       productViewModel.Description;
                product.Price =             productViewModel.Price;
                product.CategoryID =        productViewModel.CategoryID;
                product.ProductCategoryID = productViewModel.ProductCategoryID;
                //product.ImagePath =         productViewModel.ImagePath;

                string fileName = Path.GetFileName(productViewModel.ImagePath.FileName);
                string uploadsFolder = Path.Combine(_webhostenvironment.WebRootPath, "uploads");
                string filepath = Path.Combine(uploadsFolder, fileName);

                using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
                {
                    productViewModel.ImagePath.CopyTo(fileStream);
                }

                product.ImagePath = fileName;

                bool productSaved = productRepository.SaveProduct(product);
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Index", "Product");
        }
        public ActionResult ProductPage(int id)
        {
            ProductRepository productDB = new ProductRepository();
            Product product = productDB.GetProductByID(id);



            return View(product);
        }
    }
}
