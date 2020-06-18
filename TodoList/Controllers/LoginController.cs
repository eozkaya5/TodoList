using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Models.Authentication;
using TodoList.Models.Context;
using TodoList.Models.Viewmodels;

namespace TodoList.Controllers
{
    public class LoginController : Controller
    {

        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
      
        #region Login Sayfası       
        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {

            TempData["returnUrl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    //İlgili kullanıcıya dair önceden oluşturulmuş bir Cookie varsa siliyoruz.
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.Persistent, model.Lock);

                    if (result.Succeeded)
                        return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("NotUser", "Böyle bir kullanıcı bulunmamaktadır.");
                    ModelState.AddModelError("NotUser2", "E-posta veya şifre yanlış.");
                }
            }
            return View(model);
        }
        #endregion

        #region Register Sayfası
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                    return RedirectToAction("Login", "Login");
                else
                    result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
            }
            return View();
        }

        #endregion

    }
}