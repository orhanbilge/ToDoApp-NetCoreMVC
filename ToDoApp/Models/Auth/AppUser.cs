using Microsoft.AspNetCore.Identity;
using ToDoApp.Models.Entity;

namespace ToDoApp.Models.Authentication
{
    public class AppUser : IdentityUser<int>
    {
        public ICollection<ToDo> ToDos { get; set; }
    }
}
