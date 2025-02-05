using ETicaret_Core.Entities;
using ETicaret_Data;
using ETicaretWebApplication.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretWebApplication.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly ETicaret_Context _context;
        public FavoritesController(ETicaret_Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var favoriler = GetFavorites();
            return View(favoriler);
        }
        private List<Product> GetFavorites()
        {
            return HttpContext.Session.GetJson<List<Product>>("GetFavorites") ?? [];
        }

        public IActionResult Add(int ProductID)
        {
            var favoriler = GetFavorites();
            var product = _context.Products.Find(ProductID);
            if (product != null && !favoriler.Any(p => p.ID == product.ID))
            {
                favoriler.Add(product);
                HttpContext.Session.SetJson("GetFavorites",favoriler);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int ProductID)
        {
            var favoriler = GetFavorites();
            var product = _context.Products.Find(ProductID);
            if (product != null && !favoriler.Any(p => p.ID == product.ID))
            {
                favoriler.RemoveAll(i => i.ID == product.ID );
                HttpContext.Session.SetJson("GetFavorites", favoriler);
            }
            return RedirectToAction("Index");
        }

    }
}
