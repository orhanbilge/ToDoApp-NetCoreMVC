using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ToDoApp.Models.ViewModels
{
    public class EditToDoViewModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
