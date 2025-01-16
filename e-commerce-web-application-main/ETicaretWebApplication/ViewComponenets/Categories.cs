using ETicaret_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretWebApplication.ViewComponenets
{
    public class Categories : ViewComponent
    {
        private readonly ETicaret_Context _context;

        public Categories(ETicaret_Context _context)
        {
            _context = _context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Categories.ToListAsync());
        }
    }
}
