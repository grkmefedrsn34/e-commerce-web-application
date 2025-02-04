using ETicaret_Core.Entities;
using ETicaretWebApplication.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretWebApplication.Controllers
{
    public class FavoritesController : Controller
    {
        public IActionResult Index()
        {
            var favoriler = GetFavorites();
            return View(favoriler);
        }
        private List<Product> GetFavorites()
        {
            return HttpContext.Session.GetJson<List<Product>>("GetFavorites") ?? [];
        }
    }
}
