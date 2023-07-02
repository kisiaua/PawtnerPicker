using Microsoft.AspNetCore.Mvc;
using PawtnerPicker.Data;
using System.Linq;
using PawtnerPicker.Models;
using PawtnerPicker.Models.ViewModels;
using PawtnerPicker.Models.Domain;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace PawtnerPicker.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly DataContext _dataContext;

        public AuthenticationController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }




        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> SignOut() {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            bool userExist = _dataContext.Authentications.Any(x => x.Login == loginViewModel.Login && x.Password == loginViewModel.Password);
            if (userExist)
            {
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, loginViewModel.Login),
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProperties);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "User with given credentials don't exists.");

            return View();
            
        }

        [HttpPost]
        public async Task<IActionResult> Register(Authentication authentication, RegisterViewModel registerViewModel)
        {
            if(registerViewModel.Password == registerViewModel.ConfirmPassword)
            {
                var usernames = await _dataContext.Authentications.ToListAsync();
                foreach (var user in usernames)
                {
                    if(user.Login == registerViewModel.Login)
                    {
                        return View();
                    }
                }

                _dataContext.Authentications.Add(authentication);
                _dataContext.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}
