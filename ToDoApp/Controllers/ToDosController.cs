using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Controllers
{
    [Authorize]
    public class ToDosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
