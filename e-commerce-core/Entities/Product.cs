namespace e_commerce_core.Entities
{
    public class Product : IEntitiy
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public string? ProductCode { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsHome { get; set; }
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
        public int? BrandID { get; set; }
        public Brand? Brand { get; set; }
        public int OrderNo { get; set; }
    }
}