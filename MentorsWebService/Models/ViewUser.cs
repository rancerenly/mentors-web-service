using System.ComponentModel.DataAnnotations;

namespace MentorsWebService.Models
{
    public class ViewUser
    {
        [Required (ErrorMessage ="Введите Email")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}