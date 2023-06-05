using System.ComponentModel.DataAnnotations;

namespace AssignmentMVC.Models
{
    public class Category
    {
        public int ID { get; set; }
        [StringLength (30)]
        public string Name { get; set; }
        [StringLength (100)]
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
