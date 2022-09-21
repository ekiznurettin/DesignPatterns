﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Observer.Models;
using WebApp.Observer.Observer;

namespace WebApp.Observer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserObserverSubject _userObserverSubject;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, UserObserverSubject userObserverSubject)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userObserverSubject = userObserverSubject;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var hasUser = await _userManager.FindByEmailAsync(email);
            if (hasUser == null) return View();
            var signInResult = await _signInManager.PasswordSignInAsync(hasUser, password, true, false);
            if (!signInResult.Succeeded) return View();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateViewModel userCreateViewModel)
        {
            var appUser = new AppUser() { UserName = userCreateViewModel.UserName,Email = userCreateViewModel.Email};
            var identityResult = await _userManager.CreateAsync(appUser, userCreateViewModel.Password);
            if (identityResult.Succeeded)
            {
                _userObserverSubject.NotifyObservers(appUser);//kullanıcı sisteme kayıt olduğunda indirim uygulama ve mesaj göndrme işlemlerini yapar
                ViewBag.Message = "Üyelik işlemi başarılı";
            }
            else
            {
                ViewBag.Message = identityResult.Errors.ToList().First().Description;
            }
            return View();
        }
    }
}
