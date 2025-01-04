namespace e_commerce_core.Entities
{
    public class Slider: IEntitiy
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Link { get; set; }
    }
}