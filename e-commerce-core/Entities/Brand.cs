namespace e_commerce_core.Entities
{
    public class Brand : IEntitiy
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Logo { get; set; }
        public bool IsActive { get; set; }
        public int OrderNo { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public IList<Product>? Products { get; set; }
    }
}