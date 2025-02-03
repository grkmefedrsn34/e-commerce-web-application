using ETicaret_Core.Entities;
using ETicaret_Data;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly ETicaret_Context _context;

        public AccountController(ETicaret_Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SingIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SingIn(AppUser appUser)
        {
            return View();
        }
        public IActionResult SingUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SingUpAsync(AppUser appUser)
        {
            appUser.IsAdmin = false;
            appUser.IsActive = true;
            if (ModelState.IsValid)
            {
                await _context.AddAsync(appUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }
    }
}
