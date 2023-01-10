using ToDoApp.Models.Authentication;
using ToDoApp.Models.Entity;

namespace ToDoApp.Models.Repositories.Abstract
{
    public interface IToDoRepository
    {
        List<ToDo> ListAll(AppUser appUser);
        void Create(ToDo toDo);
        void Delete(ToDo toDo);
        void Update(ToDo toDo);
        ToDo GetById(int id);
    }
}
