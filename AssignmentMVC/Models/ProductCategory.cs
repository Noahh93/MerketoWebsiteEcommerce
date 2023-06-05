using System.ComponentModel.DataAnnotations;

namespace AssignmentMVC.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        [Required]
        [StringLength (25)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
