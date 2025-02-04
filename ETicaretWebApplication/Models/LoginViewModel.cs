using System.ComponentModel.DataAnnotations;

namespace ETicaretWebApplication.Models
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress),Required(ErrorMessage ="Email Boş Geçilemez")]
        public string Email { get; set; }
        [Display(Name ="Şifre")]
        [DataType(DataType.Password), Required(ErrorMessage = "Password Boş Geçilemez")]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
        
    }
}
