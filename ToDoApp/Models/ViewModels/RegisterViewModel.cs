using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ToDoApp.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(15, ErrorMessage = "Please enter username between 4 and 15 characters.", MinimumLength = 4)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please specify a value in email format.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password, ErrorMessage = "Please follow the password rules.")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
