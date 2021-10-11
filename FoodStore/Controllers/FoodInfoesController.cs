using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodStore.Data;
using FoodStore.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace FoodStore.Controllers
{
    [Authorize(Roles = "power")]
    public class FoodInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public FoodInfoesController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        // GET: FoodInfoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FoodInfos.Include(f => f.CategoryFood).Include(f => f.Company);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FoodInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodInfo = await _context.FoodInfos
                .Include(f => f.CategoryFood)
                .Include(f => f.Company)
                .FirstOrDefaultAsync(m => m.FoodID == id);
            if (foodInfo == null)
            {
                return NotFound();
            }

            return View(foodInfo);
        }

        // GET: FoodInfoes/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.FoodCategories, "CategoryID", "CategoryName");
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyName");
            return View();
        }

        // POST: FoodInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodID,FoodName,Description,File,Price,CompanyID,CategoryID")] FoodInfo foodInfo)
        {
            using (var memoryStream = new MemoryStream())
            {
                await foodInfo.File.FormFile.CopyToAsync(memoryStream);

                string photoname = foodInfo.File.FormFile.FileName;
                foodInfo.Extension = Path.GetExtension(photoname);
                if (!".jpg.jpeg.png.gif.bmp".Contains(foodInfo.Extension.ToLower()))
                {
                    ModelState.AddModelError("File.FormFile", "Invalid Format of Image Given.");
                }
                else
                {
                    ModelState.Remove("Extension");
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(foodInfo);
                await _context.SaveChangesAsync();
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "foodphotos");
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }
                string filename = foodInfo.FoodID + foodInfo.Extension;
                var filePath = Path.Combine(uploadsRootFolder, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await foodInfo.File.FormFile.CopyToAsync(fileStream).ConfigureAwait(false);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.FoodCategories, "CategoryID", "CategoryName", foodInfo.CategoryID);
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyName", foodInfo.CompanyID);
            return View(foodInfo);
        }

        // GET: FoodInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodInfo = await _context.FoodInfos.FindAsync(id);
            if (foodInfo == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.FoodCategories, "CategoryID", "CategoryName", foodInfo.CategoryID);
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyName", foodInfo.CompanyID);
            return View(foodInfo);
        }

        // POST: FoodInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodID,FoodName,Description,Extension,Price,CompanyID,CategoryID")] FoodInfo foodInfo)
        {
            if (id != foodInfo.FoodID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodInfoExists(foodInfo.FoodID))
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
            ViewData["CategoryID"] = new SelectList(_context.FoodCategories, "CategoryID", "CategoryName", foodInfo.CategoryID);
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyName", foodInfo.CompanyID);
            return View(foodInfo);
        }

        // GET: FoodInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodInfo = await _context.FoodInfos
                .Include(f => f.CategoryFood)
                .Include(f => f.Company)
                .FirstOrDefaultAsync(m => m.FoodID == id);
            if (foodInfo == null)
            {
                return NotFound();
            }

            return View(foodInfo);
        }

        // POST: FoodInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodInfo = await _context.FoodInfos.FindAsync(id);
            _context.FoodInfos.Remove(foodInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodInfoExists(int id)
        {
            return _context.FoodInfos.Any(e => e.FoodID == id);
        }
    }
}
