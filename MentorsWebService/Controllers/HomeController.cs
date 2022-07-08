using Microsoft.AspNetCore.Mvc;
using MentorsWebService.Models;

namespace MentorsWebService.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}