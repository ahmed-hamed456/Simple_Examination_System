using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Examination_System.Models.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Login as instractor")]
        public bool AsAnInstractor { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "You must give avalid email")]
        [EmailAddress()]
        [Display(Name ="Email address")]
        [Unicode]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,32}$", ErrorMessage = "should not start with digit or special character\r\nshould not end with special character must contain at least one letter\r\nmust contain at least one digit\r\nlength should be minimum 8 character")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
