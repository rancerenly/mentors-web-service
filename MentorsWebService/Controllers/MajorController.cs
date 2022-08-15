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
    [Authorize(Roles = nameof(Teacher))]
    public class MajorController : Controller
    {
        private IRepository repository;
        private UserManager<IdentityUser> _userManager;
        
        public MajorController(IRepository repos, UserManager<IdentityUser> userManager)
        {
            repository = repos;
            _userManager = userManager;
        }
        
        [HttpGet]
        public IActionResult CreateMajor()
        {
            return View(new ViewMajor());
        }

        [HttpPost]
        public async Task<IActionResult> CreateMajor(ViewMajor major)
        {
            // string name = User.Identity.Name;
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser != null)
            {
                var createMajor = new Major
                {
                    Description = major.Description,
                    Title = major.Title,
                    Teacher = currentUser as Teacher
                }; 
                repository.AddMajor(createMajor);
            }
            return Redirect("~/Home/Index"); // затычка
        }
        [HttpGet]
        public IActionResult CreateModule(int id)
        {
            return View(new ViewModule { MajorId = id});
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateModule(ViewModule module)
        {
            
            Major currentMajor = repository.GetMajor(module.MajorId);
            
            if (ModelState.IsValid && currentMajor != null)
            {
                Module newModule = new Module
                {
                    Title = module.Title,
                    Major = currentMajor
                };
                
                repository.AddModule(newModule);
            }
            return null;
        }
        
        [HttpGet]
        public IActionResult CreateExercise(int id)
        {
            return View(new ViewExercise { ModuleId = id});
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateExercise(ViewExercise exercise)
        {
            Module currentModule = repository.GetModule(exercise.ModuleId);
            
            if (ModelState.IsValid && currentModule != null)
            {
                Exercise newExercise = new Exercise
                {
                    Description = exercise.Description,
                    Module = currentModule,
                    Title = exercise.Title
                };
                repository.AddExercise(newExercise);
                
                // currentModule.Exercises.Add(newExercise);
            }
            return null;
        }
    }
}