using ETicaret_Core.Entities;
using ETicaret_Data;
using ETicaretWebApplication.Models;
using ETicaretWebApplication.Ultis;
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
            AppUser user = _context.AppUsers.FirstOrDefault(x => x.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
            if (user == null)
            {
                return NotFound();
            }
            var model = new UserEditViewModel()
            {
                Email = user.Email,
                ID = user.ID,
                Name = user.Name,
                Password = user.Password,
                Surname = user.Surname,
                Phone = user.Phone
            };
            return View(model);
        }
        [HttpPost , Authorize]
        public IActionResult Index(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AppUser user = _context.AppUsers.FirstOrDefault(x => x.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
                    if (user is not null)
                    {
                        user.Surname = model.Surname;
                        user.Phone = model.Phone;
                        user.Name = model.Name;
                        user.Password = model.Password;
                        user.Email= model.Email;
                        _context.AppUsers.Update(user);
                        _context.SaveChanges();
                        var sonuc = _context.SaveChanges();
                        if (sonuc> 0)
                        {
                            TempData["Message"] = @"<div class=""alert alert-success alert-dismissible fade show"" role=""alert"">
   <strong>Bilgileriniz Güncellenmiştir !</strong>
   <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
</div>";
                            //await MailHelper.SendMailAsync(contact);
                            return RedirectToAction("Index");
                        }
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("","Hata Oluştu !");
                }
            }
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
