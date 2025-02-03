using ETicaret_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretWebApplication.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ETicaret_Context _context;

        public CategoriesController(ETicaret_Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _context.Categories.Include(P => P.Products)
                .FirstOrDefaultAsync(M => M.ID == id);
            if(category == null) 
            {
                return NotFound();
            }
            return View(category);
        }
    }
}
