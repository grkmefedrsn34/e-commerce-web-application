using ETicaret_Core.Entities;


namespace ETicaretWebApplication.Models
{
    public class ProductDetailsViewModel
    {
        public Product? Product {  get; set; }
        public List<Product>? RelatedProducts {  get; set; }
    }
}
