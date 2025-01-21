using ETicaret_Data;
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
        public async Task<IActionResult> Index()
        {
            var eTicaret_Context = _context.Products.Where(p=>p.IsActive).Include(p => p.Brand).Include(p => p.Category);
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

            return View(product);
        }
    }
}
