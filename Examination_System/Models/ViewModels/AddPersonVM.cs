using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Examination_System.Models.ViewModels
{
    public class AddPersonVM
    {
        [Display(Name = "Register as instractor")]
        public bool AsInstractor { get; set; }
        public int ID { get; set; }
        [Required(ErrorMessage = ".")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name must be from 5 to 50")]
        public string Name { get; set; }
        [Range(20, 35, ErrorMessage = "Age must be between 20 and 35")]
        public int Age { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "You must give avalid email")]
        [EmailAddress()]
        //[Unicode]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,32}$", ErrorMessage = "should not start with digit or special character\r\nshould not end with special character must contain at least one letter\r\nmust contain at least one digit\r\nlength should be minimum 8 character")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,32}$", ErrorMessage = "should not start with digit or special character\r\nshould not end with special character must contain at least one letter\r\nmust contain at least one digit\r\nlength should be minimum 8 character")]
        [Compare("Password", ErrorMessage = "Password must match confirm password")]
        public string confirmPassword { get; set; }

    }
}
