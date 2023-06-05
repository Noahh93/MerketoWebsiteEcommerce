using System.ComponentModel.DataAnnotations;

namespace AssignmentMVC.ViewModel
{
    public class RegisterUserViewModel
    {
        [Required]
        [StringLength (30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        [StringLength(40)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [StringLength(30)]
        public string StreetName { get; set; }
        [StringLength(10)]
        public string PostalCode { get; set; }
        [StringLength(20)]
        public string City { get; set; }
    }
}
