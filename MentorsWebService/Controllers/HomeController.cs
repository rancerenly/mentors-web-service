using Microsoft.AspNetCore.Mvc;
using MentorsWebService.Models;

namespace MentorsWebService.Controllers
{
    public class HomeController : Controller
    {
        // GET
        
        public string Index()
        {
            return "Hello World!";
        }
    }
}