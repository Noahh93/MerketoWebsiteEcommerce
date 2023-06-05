using System.ComponentModel.DataAnnotations;

namespace AssignmentMVC.Models
{
    public class Contact
    {
        public int ID { get; set; }
        [Required]
        [StringLength (50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(150)]
        public string Message { get; set; }
        public bool SaveMyInfo { get; set; }
    }
}
