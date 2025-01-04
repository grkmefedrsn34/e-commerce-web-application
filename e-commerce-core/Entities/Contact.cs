namespace e_commerce_core.Entities
{
    public class Contact: IEntitiy
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}