using ETicaret_Data;
using ETicaretWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ETicaretWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ETicaret_Context _context;

        public HomeController(ETicaret_Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Sliders);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
