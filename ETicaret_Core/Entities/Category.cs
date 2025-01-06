using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret_Core.Entities
{
    public class Category:IEntitiy
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsTopMenu { get; set; }
        public int ParentID { get; set; }
        public int OrderNo { get; set; }
        public IList<Product>? Products { get; set; }
    }
}
