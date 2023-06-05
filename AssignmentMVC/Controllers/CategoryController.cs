using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using AssignmentMVC.ViewModel;
using AssignmentMVC.Models;
using AssignmentMVC.Repositories;

namespace AssignmentMVC.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult SaveCategory(CategoryViewModel CategoryVM)
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            

            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.Name = CategoryVM.Name;
                category.Description = CategoryVM.Description;
                Category categoryDB = categoryRepository.GetCategoryByName(CategoryVM.Name);

                if (categoryDB == null)
                {
                    bool saveCategory = categoryRepository.SaveCategory(category);
                    ViewBag.CategoryNameExist = "Your new category has been added";
                }
                else
                {
                    ViewBag.CategoryNameExist = "This category already exists";
                }
            }
            return View("Index");
        }
    }
}
