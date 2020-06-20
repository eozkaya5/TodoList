﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using TodoList.Models.Authentication;
using TodoList.Models.Viewmodels;

namespace TodoList.Controllers
{
    public class LoginController : Controller
    {
        #region Manager       
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #endregion

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

        #region Üye bilgileri tablosu  
        [Authorize]
        public IActionResult UserTable()
        {
            return View(_userManager.Users);
        }
        #endregion

        #region Password Reset Sayfası
        public IActionResult PasswordReset()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PasswordReset(ResetPasswordViewModel model)
        {
            AppUser user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.To.Add(user.Email);
                mail.From = new MailAddress("******@gmail.com", "Şifre Güncelleme", System.Text.Encoding.UTF8);
                mail.Subject = "Şifre Güncelleme Talebi";
                mail.Body = $"<a target=\"_blank\" href=\"https://localhost:5001{Url.Action("UpdatePassword", "Login", new { Id = user.Id, token = HttpUtility.UrlEncode(resetToken) })}\">Yeni şifre talebi için tıklayınız</a>";
                mail.IsBodyHtml = true;
                SmtpClient smp = new SmtpClient();
                smp.Credentials = new NetworkCredential("ozkayaelif562@gmail.com", "ozkayaelif562");
                smp.Port = 587;
                smp.Host = "smtp.gmail.com";
                smp.EnableSsl = true;
                smp.Send(mail);

                ViewBag.State = true;
            }
            else
                ViewBag.State = false;

            return View();
        }
        #endregion

        #region Password Update Sayfası
        [HttpGet("[action]/{Id}/{token}")]
        public IActionResult UpdatePassword(string Id, string token)
        {
            return View();
        }
        [HttpPost("[action]/{Id}/{token}")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordModel model, string Id, string token)
        {
            AppUser user = await _userManager.FindByIdAsync(Id);
            IdentityResult result = await _userManager.ResetPasswordAsync(user, HttpUtility.UrlDecode(token), model.Password);
            if (result.Succeeded)
            {
                ViewBag.State = true;
                await _userManager.UpdateSecurityStampAsync(user);
                return RedirectToAction("Login", "Login");
            }
            else
                ViewBag.State = false;
            return View();
        }

        #endregion

        #region Çıkış yap
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        #endregion      
    }
}

