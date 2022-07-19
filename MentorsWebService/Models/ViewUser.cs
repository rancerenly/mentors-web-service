using System.ComponentModel.DataAnnotations;

namespace MentorsWebService.Models
{
    public class ViewUser
    {
        [Required (ErrorMessage ="Введите Username")]
        public string Username { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
 
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
        
        
        [Required (ErrorMessage ="Введите Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}