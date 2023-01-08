using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models.Authentication;
using ToDoApp.Models.ViewModels;

namespace ToDoApp.Controllers
{
    public class AuthController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(loginViewModel.Email);

                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult signIn = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, loginViewModel.Lock);

                    if (signIn.Succeeded)
                        return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("NotUser", "No user or incorrect information.");

            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser newUserInfo = new AppUser
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email
                };

                IdentityResult createNewUser = await _userManager.CreateAsync(newUserInfo, registerViewModel.Password);

                if (createNewUser.Succeeded)
                    return RedirectToAction("Index", "Home");
                else
                    createNewUser.Errors.ToList().ForEach(Error => ModelState.AddModelError(Error.Code, Error.Description));
            }

            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
