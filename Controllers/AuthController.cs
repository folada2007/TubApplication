using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Philharmonic.Models;
using Philharmonic.Services.Interfaces;


namespace Philharmonic.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _service;
        private readonly ISaveDb _saveDb;

        public AuthController(IAuthService service, ISaveDb saveDb)
        {
            _service = service;
            _saveDb = saveDb;
        }

        public IActionResult Register()
        {
                return View();
        }

        [Authorize]
        public async Task<IActionResult> LogOut() 
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var principal = await _service.AuthenticationUserAsync(login);
                if (principal != null) 
                {
                    await _service.SignInAsync(principal);
                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError(string.Empty,"Пользователь с таким именем или паролем не найден повторите попытку или пройдите регистрацию");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            if (ModelState.IsValid)
            {
                register.Lives = register.GetDifferenceDate();
                await _saveDb.RegistrationUser(register);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
