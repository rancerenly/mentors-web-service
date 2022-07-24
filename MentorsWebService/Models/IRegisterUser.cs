using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MentorsWebService.Models
{
    public interface IRegisterUser<T> where T : IdentityUser 
    {
         Task<T> RegisterUsers(T data,string pass,SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager);
    }
}