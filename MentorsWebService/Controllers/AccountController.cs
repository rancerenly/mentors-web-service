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
            return View();
        }
        
        [HttpGet]
        public IActionResult RegisterClient()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterClient(ViewClient user)
        {
            if (ModelState.IsValid)
            {
                var newClient = Mapping<Client, ViewClient>.MappingUser(user);

                RegisterUser<Client> regClient = new RegisterUser<Client>();
                var result = await regClient.RegisterUsers(newClient, user.Password, _signInManager, _user);
                
                if (result != null)
                {
                    return RedirectToAction("UserAccount", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult RegisterTeacher()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterTeacher(ViewTeacher user)
        {
            if (ModelState.IsValid)
            {
                var newTeacher = Mapping<Teacher, ViewTeacher>.MappingUser(user);

                RegisterUser<Teacher> regTeacher = new RegisterUser<Teacher>();
                var result = await regTeacher.RegisterUsers(newTeacher, user.Password, _signInManager, _user);
                
                if (result != null)
                {
                    return RedirectToAction("UserAccount", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
