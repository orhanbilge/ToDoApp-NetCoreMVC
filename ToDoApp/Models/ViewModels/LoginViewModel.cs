using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ToDoApp.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please specify a value in email format.")]
        [Display(Name = "Email ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password, ErrorMessage = "Please follow the password rules.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        
        public bool Lock { get; set; }
    }
}
