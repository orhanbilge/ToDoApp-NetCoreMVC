using ToDoApp.Models.Authentication;
using ToDoApp.Models.Entity;

namespace ToDoApp.Business.Abstract
{
    public interface IToDoService
    {
        void Create(ToDo toDo);
        void Update(ToDo toDo);
        void Delete(ToDo toDo);
        List<ToDo> ListAll(AppUser appUser);
        ToDo GetById(int id);
    }
}
