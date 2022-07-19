using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorsWebService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MentorsWebService.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        private IRepository _repository;
        private UserManager<IdentityUser> _user;

        public AccountController(SignInManager<IdentityUser> signInManager, IRepository repo,
            UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _repository = repo;
            _user = userManager;
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/Home/Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new ViewUser());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(ViewUser user)
        {
            IdentityUser getUser = await _user.FindByEmailAsync(user.Email);

            if (getUser != null)
            {
                await _signInManager.SignOutAsync();
                if ((await _signInManager.PasswordSignInAsync(getUser, user.Password, true, false)).Succeeded)
                {
                    return Redirect("~/Home/Index");
                }
            }

            return RedirectToAction("Register");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new ViewUser());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ViewUser user)
        {
            if (ModelState.IsValid)
            {
                var newTeacher = new Teacher
                {
                    // passwordHash!
                    UserName = user.Username,
                    NormalizedUserName = user.Username,
                    NormalizedEmail = user.Email,
                    Email = user.Email,
                    Bio = "Some bio"
                };
                
                var result = await _user.CreateAsync(newTeacher, user.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(newTeacher, false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return Redirect("~/Home/Account");
        }

    }
}
