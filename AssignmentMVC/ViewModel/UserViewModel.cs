using System.ComponentModel.DataAnnotations;

namespace AssignmentMVC.ViewModel
{
    public class UserViewModel
    {
        [Required]
        public string? Firstname { get; set; }
        [Required]
        public string? Lastname { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public IFormFile? Photo { get; set; }
        public int CountryID { get; set; }
    }
}
