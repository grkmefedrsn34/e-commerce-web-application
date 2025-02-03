using System.ComponentModel.DataAnnotations;

namespace ETicaretWebApplication.Models
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        [Display(Name ="Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
        
    }
}
