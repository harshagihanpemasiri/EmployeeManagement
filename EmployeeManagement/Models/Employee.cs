using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string Province { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [StringLength(50)]
        public string Position { get; set; }

        [Range(10000, double.MaxValue)]
        public decimal Salary { get; set; } = 10000;

        [Required]
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Invalid gender.")]
        public string Gender { get; set; }

        public string? ProfilePicName { get; set; }

        [Required]
        [NotMapped]
        public IFormFile? ProfilePic { get; set; }   

    }
}
