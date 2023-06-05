using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace AssignmentMVC.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        [StringLength (30)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [StringLength (100)]
        [Required]
        public string Description { get; set; }


        [ForeignKey ("Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [ForeignKey ("ProductCategory")]
        public int ProductCategoryID { get; set; }
        public ProductCategory ProductCategory { get; set; }
        [StringLength (500)]
        [Required]
        public string ImagePath { get; set; }
    }
}
