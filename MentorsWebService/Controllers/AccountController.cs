using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorsWebService.Models;
using MentorsWebService.Infrastructure;
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

        [Authorize(Roles = nameof(Teacher))]
        public IActionResult CreateMajor()
        {
            // действия по созданию направления
            // редирект на направление...
            return View("Register");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        // [Authorize (Roles = "Teacher")]
        // Register(ViewUser user)
        
        [AllowAnonymous]
        public async Task<IActionResult> Register(ViewRegisterUser user)
        {
            
            if (ModelState.IsValid)
            {
                IdentityUser newUser = null;
                
                if (user.Role == UserRoles.Teacher)
                {
                    newUser = Mapping<Teacher, ViewRegisterUser>.MappingUser(user);
                }
                if (user.Role == UserRoles.Client)
                {
                    newUser = Mapping<Client, ViewRegisterUser>.MappingUser(user);
                }
                
                var registerUser = new RegisterUser<IdentityUser>();

                var result = await registerUser.RegisterInSystem(newUser, user.Password, _signInManager, _user);
                
                if (result != null)
                {
                    return RedirectToAction("UserAccount", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
