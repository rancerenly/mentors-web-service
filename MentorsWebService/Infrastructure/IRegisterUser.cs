using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MentorsWebService.Infrastructure
{
    public interface IRegisterUser<T> where T : IdentityUser 
    {
         Task<T> RegisterInSystem(T data,string pass,SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager);
    }
}