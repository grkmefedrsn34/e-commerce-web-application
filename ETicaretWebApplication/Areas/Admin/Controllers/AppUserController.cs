using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ETicaret_Core.Entities;
using ETicaret_Data;

namespace ETicaretWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppUserController : Controller
    {
        private readonly ETicaret_Context _context;
        
        public AppUserController(ETicaret_Context _context)
        {
            _context = _context;
        }

        //GET:Admin/Appuser
        public async Task<IActionResult> Index()
        {
            return View(await _context.AppUsers.ToListAsync());
        }

        // GET : Admin/AppUsers/Detalis/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var appuser = await _context.AppUsers.FirstOrDefaultAsync(m => m.ID == id);
            if (appuser == null)
            {
                return NotFound();
            }
            return View(appuser);
        }
        // GET : Admin/AppUsers/Create
        public IActionResult Create() 
        {
            return View();  
        }

        //POST : Admin/AppUsers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create(AppUser aPPuuser)
        {
            if(ModelState.IsValid)
            {
                _context.Add(aPPuuser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aPPuuser);
        }

        //POST : Admin/AppUsers/Edit

        public async Task<IActionResult> Edit(int id,AppUser aPPuuser) 
        {
            if (id != aPPuuser.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aPPuuser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppUserExists(aPPuuser.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aPPuuser);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var appUsers = await _context.AppUsers.FirstOrDefaultAsync(m => m.ID == id);
            if (appUsers == null)
            {
                return NotFound();
            }
            return View(appUsers);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> DeleteConfirmend(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var AppUsers = await _context.AppUsers.FindAsync(id);
            if (AppUsers == null) {
                _context.AppUsers.Remove(AppUsers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        private bool AppUserExists(int id)
        {
            return _context.AppUsers.Any(e => e.ID == id);
        }
    }
}
