using System.ComponentModel.DataAnnotations;

namespace AssignmentMVC.ViewModel
{
    public class CategoryViewModel
    {
        [Required]
        [StringLength (30)]
        public string Name { get; set; }
        [Required]
        [StringLength (100)]
        public string Description { get; set; }

    }
}
