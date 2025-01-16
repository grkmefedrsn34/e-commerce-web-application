using ETicaret_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretWebApplication.ViewComponents
{
    public class Categories : ViewComponent
    {
        private readonly ETicaret_Context _context;

        public Categories(ETicaret_Context context)
        {
            _context = context; // Context'i doğru şekilde başlatıyoruz
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Categories.ToListAsync());
        }
    }
}
