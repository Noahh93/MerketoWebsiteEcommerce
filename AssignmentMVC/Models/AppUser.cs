using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AssignmentMVC.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(20)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(20)]
        public string Lastname { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        [StringLength(40)]
        [Required]
        public string StreetName { get; set; }
        [StringLength(10)]
        [Required]
        public string PostalCode { get; set; }
        [StringLength(40)]
        [Required]
        public string City { get; set; }
    }
}
