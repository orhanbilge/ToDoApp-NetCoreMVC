using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Business.Abstract;
using ToDoApp.Models.Authentication;
using ToDoApp.Models.Entity;
using ToDoApp.Models.ViewModels;

namespace ToDoApp.Controllers
{
    [Authorize]
    public class ToDosController : Controller
    {
        readonly IToDoService _toDoManager;
        readonly UserManager<AppUser> _userManager;

        public ToDosController(IToDoService toDoService, UserManager<AppUser> userManager)
        {
            _toDoManager = toDoService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            AppUser user = await _userManager.GetUserAsync(User);

            var toDoList = _toDoManager.ListAll(user);
            return View(toDoList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateToDoViewModel createToDoViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.GetUserAsync(User);

                _toDoManager.Create(new ToDo() { User = user, Description = createToDoViewModel.Description });

                return RedirectToAction("Index", "ToDos");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ToDo toDoItem = _toDoManager.GetById(id);

            return View(toDoItem);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditToDoViewModel editToDoViewModel)
        {
            if (ModelState.IsValid)
            {
                ToDo toDoItem = _toDoManager.GetById(editToDoViewModel.Id);
                toDoItem.Description = editToDoViewModel.Description;

                _toDoManager.Update(toDoItem);

                return RedirectToAction("Index", "ToDos");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ToDo toDoItem = _toDoManager.GetById(id);
            _toDoManager.Delete(toDoItem);

            return RedirectToAction("Index", "ToDos");
        }
    }
}
