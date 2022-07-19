using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MentorsWebService.Models;
using Microsoft.AspNetCore.Identity;

namespace MentorsWebService.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        private UserManager<IdentityUser> _user;
        
        public HomeController(IRepository repos, UserManager<IdentityUser> userManager)
        {
            repository = repos;
            _user = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> UserAccount()
        {
            var getUser = await _user.GetUserAsync(HttpContext.User);
            if (getUser != null)
            {
                TestUser testUser = new TestUser { UserName = getUser.UserName };
                return View(testUser);
            }
            return RedirectToAction("Login", "Account");
        }
        public IActionResult Index() => View(repository.GetMajors);
    }
}