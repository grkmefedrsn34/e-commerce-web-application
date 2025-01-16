using ETicaret_Data;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactsController : Controller
    {

        private readonly ETicaret_Context _context;

        public ContactsController(ETicaret_Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Contacts);
        }
    }
}
