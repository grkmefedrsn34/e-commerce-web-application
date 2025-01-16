using ETicaret_Data;
using ETicaretWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders.ToListAsync(); // Asenkron i�lemi bekliyoruz
            return View(sliders); // Do�ru model d�nd�r�l�yor
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
