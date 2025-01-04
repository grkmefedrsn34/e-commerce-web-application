namespace e_commerce_core.Entities
{
    public class News : IEntitiy
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}