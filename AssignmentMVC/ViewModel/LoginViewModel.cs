using System.ComponentModel.DataAnnotations;

namespace AssignmentMVC.ViewModel
{
    public class LoginViewModel
    {
        [StringLength (30)]
        [Required]
        public string Email { get; set; }
        [StringLength(30)]
        [Required]
        public string Password { get; set; }
    }
}
