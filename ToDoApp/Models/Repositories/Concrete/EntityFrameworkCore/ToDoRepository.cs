using Microsoft.EntityFrameworkCore;
using ToDoApp.Models.Authentication;
using ToDoApp.Models.Entity;
using ToDoApp.Models.Repositories.Abstract;

namespace ToDoApp.Models.Repositories.Concrete.EntityFrameworkCore
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly AppDbContext context;

        public ToDoRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(ToDo toDo)
        {
            context.Add<ToDo>(toDo);
            context.SaveChanges();
        }

        public ToDo GetById(int id)
        {
            return context.ToDos.Find(id);
        }

        public void Update(ToDo toDo)
        {
            context.Update(toDo);
            context.SaveChanges();
        }

        public void Delete(ToDo toDo)
        {
            context.Remove<ToDo>(toDo);
            context.SaveChanges();
        }

        public List<ToDo> ListAll(AppUser appUser)
        {
            return context.ToDos.Where(x => x.User == appUser).ToList();
        }
    }
}
