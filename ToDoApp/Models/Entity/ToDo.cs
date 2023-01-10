using ToDoApp.Models.Authentication;

namespace ToDoApp.Models.Entity
{
    public class ToDo
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}