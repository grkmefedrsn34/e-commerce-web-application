using ETicaret_Core.Entities;
using ETicaret_Data;
using ETicaretWebApplication.Models;
using Microsoft.AspNetCore.Authentication;//login
using Microsoft.AspNetCore.Authorization;//login
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;//login

namespace ETicaretWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly ETicaret_Context _context;

        public AccountController(ETicaret_Context context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SingIn()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> SingInAsync(LoginViewModel LoginViewModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var account = await _context.AppUsers.FirstOrDefaultAsync(x=>x.Email == LoginViewModel.Email & x.Password == LoginViewModel.Password & x.IsActive);
                    if (account == null) 
                    {
                        ModelState.AddModelError("", "Giriş Başarısız !");
                    }
                    else
                    {
                        var claims = new List<Claim>()
                        {
                            new(ClaimTypes.Name,account.Name),
                            new(ClaimTypes.Role,account.IsAdmin ? "Admin" :"Customer"),
                            new(ClaimTypes.Email,account.Email), 
                            new("UserID",account.ID.ToString()),
                            new("UserGuid",account.UserGuid.ToString()),
                        };
                        var userIdentity = new ClaimsIdentity(claims,"Login");
                        ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);
                        await HttpContext.SignInAsync(userPrincipal);
                        return Redirect(string.IsNullOrEmpty(LoginViewModel.ReturnUrl) ? "/" : LoginViewModel.ReturnUrl);
                    }
                }
                catch (Exception hata)
                {
                    //loglama
                    ModelState.AddModelError("", "Hata Oluştu !");
                }
            }
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
        public async Task <IActionResult> SingOutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("SingIn");
        }
    }
}
