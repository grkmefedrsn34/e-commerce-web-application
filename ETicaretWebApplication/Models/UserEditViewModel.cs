using System.ComponentModel.DataAnnotations;

namespace ETicaretWebApplication.Models
{
    public class UserEditViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Adı")]
        public string Name { get; set; }
        [Display(Name = "Soyadı")]
        public string Surname { get; set; }
        public string Email { get; set; }
        [Display(Name = "Email")]
        public string? Phone { get; set; }
        public string Password { get; set; }
    }
}
