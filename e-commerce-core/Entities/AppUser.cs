
namespace e_commerce_core.Entities
{
    public class AppUser: IEntitiy
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? UserName { get; set;} 
        public string? Phone { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Guid? UserGuid { get; set; }  = Guid.NewGuid();
    }
}