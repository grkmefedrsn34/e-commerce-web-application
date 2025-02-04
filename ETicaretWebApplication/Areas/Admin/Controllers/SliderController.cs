using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ETicaret_Data;
using ETicaret_Core.Entities;
using ETicaretWebApplication.Ultis;
using Microsoft.AspNetCore.Authorization;

namespace ETicaretWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminPolicy")]
    public class SliderController : Controller
    {
        private readonly ETicaret_Context _context;

        public SliderController(ETicaret_Context context)
        {
            _context = context;
        }

        // GET: Admin/Slider
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sliders.ToListAsync());
        }

        // GET: Admin/Slider/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders.FirstOrDefaultAsync(m => m.ID == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // GET: Admin/Slider/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Slider/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ETicaret_Core.Entities.Slider slider, IFormFile? image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    slider.Image = await File_Helper.FileLoaderASYNC(image, "/image_client/Slider/");
                }

                _context.Add(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        // GET: Admin/Slider/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // POST: Admin/Slider/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ETicaret_Core.Entities.Slider slider, IFormFile? image,bool cbResimSil= false)
        {
            if (id != slider.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   if(cbResimSil)
                        slider.Image = string.Empty;
                    if (image is not null)
                        slider.Image = await File_Helper.FileLoaderASYNC(image, "/slider");
                    _context.Update(slider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderExists(slider.ID))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(slider);
        }

        // GET: Admin/Slider/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (id == null)
            {
                if(!string.IsNullOrEmpty(slider.Image))
                {
                    File_Helper.FileRemove(slider.Image,"/Slider/");
                }
                _context.Sliders.Remove(slider);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Admin/Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider != null)
            {
                _context.Sliders.Remove(slider);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SliderExists(int id)
        {
            return _context.Sliders.Any(e => e.ID == id);
        }
    }
}
