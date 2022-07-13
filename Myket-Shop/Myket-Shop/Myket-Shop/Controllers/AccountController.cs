using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Myket_Shop.Data.Repositories;
using Myket_Shop.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Myket_Shop.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #region Register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            if (_userRepository.IsExistUserByEmail(register.Email.ToLower()))
            {
                ModelState.AddModelError("Email", "از این ایمیل قبلا استفاده شده است");
                return View(register);
            }
            Users user = new Users()
            {
                FullName = register.FullName,
                Email = register.Email,
                Password = register.Password,
                IsAdmin = false,
                RegisterDate = System.DateTime.Now
            };
            _userRepository.AddUser(user);
            return View("Wellcome");
        }

        #endregion
        #region Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var user = _userRepository.GetUserForLogin(login.Email.ToLower(), login.Password);
            if (user == null)
            {
                ModelState.AddModelError("Error", "اطلاعات صحیح نیست");
                return View(login);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.FullName),
                new Claim("IsAdmin",user.IsAdmin.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };
            HttpContext.SignInAsync(principal, properties);
            return Redirect("/Home/Index");
        }
        #endregion
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }
    }
}
