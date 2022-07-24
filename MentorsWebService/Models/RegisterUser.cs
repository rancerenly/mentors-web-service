using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MentorsWebService.Models
{
    public class RegisterUser<T> : IRegisterUser<T> where T : IdentityUser
    {
        public async Task<T> RegisterUsers(T data, string pass, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            var result = await userManager.CreateAsync(data, pass);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(data, false);
                return data;
            }
            return null;
        }
    }
}