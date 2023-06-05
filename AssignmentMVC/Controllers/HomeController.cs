using AssignmentMVC.Models;
using AssignmentMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AssignmentMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            ProductRepository productRepository = new ProductRepository();

            ViewBag.ProductList = productRepository.GetAllProducts();
            ViewBag.CategoryList = categoryRepository.GetAllCategories();


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}