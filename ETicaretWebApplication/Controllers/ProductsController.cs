using ETicaret_Data;
using ETicaretWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretWebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ETicaret_Context _context;

        public ProductsController(ETicaret_Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string q = "")
        {
            var eTicaret_Context = _context.Products.Where(p=>p.IsActive && p.Name.Contains(q)).Include(p => p.Brand).Include(p => p.Category);
            return View(await eTicaret_Context.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductDetailsViewModel()
            {
                Product = product,
                RelatedProducts = await _context.Products
                    .Where(p => p.IsActive && p.CategoryID == product.CategoryID && p.ID != product.ID)
                    .ToListAsync()
            };
            return View(model);
        }

    }
}
