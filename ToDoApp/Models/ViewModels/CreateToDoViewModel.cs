using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ToDoApp.Models.ViewModels
{
    public class CreateToDoViewModel
    {
        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
