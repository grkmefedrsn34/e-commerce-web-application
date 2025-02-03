using ETicaret_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretWebApplication.Controllers
{
    public class NewsController : Controller
    {
        private readonly ETicaret_Context _context;

        public NewsController(ETicaret_Context context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index()
        {
            return View(await _context.News.ToArrayAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FirstOrDefaultAsync(m => m.ID == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }
    }
}
