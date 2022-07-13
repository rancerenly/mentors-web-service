using Microsoft.AspNetCore.Mvc;
using MentorsWebService.Models;

namespace MentorsWebService.Controllers
{
    
    public class HomeController : Controller
    {
        private IRepository repository;
        public HomeController(IRepository repos)
        {
            repository = repos;
        }
        public IActionResult Index() => View(repository.GetMajors);
    }
}