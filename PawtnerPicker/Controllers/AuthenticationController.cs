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

        public IActionResult AccessDenied()
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
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string value)
        {
            if(value == "Register")
            {
                return RedirectToAction("Register");
            }


            bool userExist = _dataContext.Authentications.Any(x => x.Login == loginViewModel.Login && x.Password == loginViewModel.Password);
            if (userExist)
            {
                //TODO: It can be simplified
                var usernames = await _dataContext.Authentications.ToListAsync();
                foreach (var user in usernames)
                {
                    if (user.Login == loginViewModel.Login)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.Login),
                            new Claim(ClaimTypes.Role, user.Role),
                        };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties();
                        if (loginViewModel.Remember is true)
                        {
                             authProperties = new AuthenticationProperties()
                            {
                                IsPersistent = true,
                                ExpiresUtc = new DateTimeOffset(2038, 1, 1, 0, 0, 0, TimeSpan.FromHours(0))
                            };
                        }
                        else
                        {
                            authProperties = new AuthenticationProperties()
                            {
                                IsPersistent = false,
                            };
                        }

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            TempData["ErrorLogin"] = "Invalid login or password";

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
                if (registerViewModel.EmployeeCode != "2137")
                {
                    authentication.Role = "User";
                }
                else
                {
                    authentication.Role = "Admin";
                }
                _dataContext.Authentications.Add(authentication);
                _dataContext.SaveChanges();
                return RedirectToAction("Login");
            }
            
            TempData["ErrorRegister"] = "Passwords do not match";
            
            return View();
        }
    }
}
