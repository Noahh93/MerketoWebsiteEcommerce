using AssignmentMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentMVC.ViewModel
{
    public class ProductViewModel
    {
        [Required]
        [StringLength (30)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [ForeignKey ("Category")]
        public int CategoryID { get; set; }
        public Category? Category { get; set; }

        [Required]
        [ForeignKey("ProductCategory")]
        public int ProductCategoryID { get; set; }
        public ProductCategory? ProductCategory { get; set; }

        public IFormFile ImagePath { get; set; }
    }
}
