using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret_Core.Entities
{
    public class AppUser : IEntitiy
    {
        public int ID { get; set; }
        [Display(Name ="Adı")]
        public string Name { get; set; }
        [Display(Name = "Soyadı")]
        public string Surname { get; set; }
        public string Email { get; set; }
        [Display(Name = "Parola")]
        public string Password { get; set; }
        public string? UserName { get; set; }
        [Display(Name = "Telefon Numarası")]
        public string? Phone { get; set; }
        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin?")]
        public bool IsAdmin { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Guid? UserGuid { get; set; } = Guid.NewGuid();
    }
}
