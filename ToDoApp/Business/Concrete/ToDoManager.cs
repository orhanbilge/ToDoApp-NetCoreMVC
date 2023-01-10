using Microsoft.AspNetCore.Identity;
using ToDoApp.Business.Abstract;
using ToDoApp.Models.Authentication;
using ToDoApp.Models.Entity;
using ToDoApp.Models.Repositories.Abstract;
using ToDoApp.Models.Repositories.Concrete.EntityFrameworkCore;

namespace ToDoApp.Models.Business.Concrete
{
    public class ToDoManager : IToDoService
    {
        public IToDoRepository _toDoRepository;
        readonly UserManager<AppUser> _userManager;

        public ToDoManager(IToDoRepository toDoRepository, UserManager<AppUser> userManager)
        {
            _toDoRepository = toDoRepository;
            _userManager = userManager;
        }

        public List<ToDo> ListAll(AppUser appUser)
        {
            return _toDoRepository.ListAll(appUser);
        }

        public void Create(ToDo toDo)
        {
            toDo.CreateDate = DateTime.Now;

            _toDoRepository.Create(toDo);
        }

        public void Update(ToDo toDo)
        {
            _toDoRepository.Update(toDo);
        }

        public void Delete(ToDo toDo)
        {
            _toDoRepository.Delete(toDo);
        }

        public ToDo GetById(int id)
        {
            return _toDoRepository.GetById(id);
        }
    }
}
