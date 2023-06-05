using AssignmentMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace AssignmentMVC.ViewModel
{
    public class ContactViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? CompanyName { get; set; }
        [Required]
        public string Message { get; set; }
        public string SaveMyInfo { get; set; }
        public string City { get; set; }

    }
}
