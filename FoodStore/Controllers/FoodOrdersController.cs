using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodStore.Data;
using FoodStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FoodStore.Controllers
{
    public class FoodOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public FoodOrdersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "power")]
        // GET: FoodOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodOrders.ToListAsync());
        }

        [Authorize(Roles = "power")]
        // GET: FoodOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodOrder = await _context.FoodOrders
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (foodOrder == null)
            {
                return NotFound();
            }

            return View(foodOrder);
        }

        [Authorize]
        // GET: FoodOrders/Create
        public IActionResult Create()
        {
            ViewData["FoodID"] = new SelectList(_context.FoodInfos, "FoodID", "FoodName");
            return View();
        }

        // POST: FoodOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,Description,Quantity,FoodID")] FoodOrder foodOrder)
        {
            ModelState.Remove("Price");
            ModelState.Remove("Total");
            ModelState.Remove("UserID");
            ModelState.Remove("OrderDate");

            if (ModelState.IsValid)
            {

                var foodInfo = await _context.FoodInfos
                    .FirstOrDefaultAsync(m => m.FoodID == foodOrder.FoodID);
                foodOrder.Price = foodInfo.Price;
                foodOrder.Total = foodOrder.Price * foodOrder.Quantity;
                foodOrder.UserID = _userManager.GetUserName(this.User);
                foodOrder.OrderDate = DateTime.Now;
                _context.Add(foodOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction("Success", "Home");
            }
            ViewData["FoodID"] = new SelectList(_context.FoodInfos, "FoodID", "FoodName", foodOrder.FoodID);
            return View(foodOrder);
        }


        [Authorize(Roles = "power")]
        // GET: FoodOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodOrder = await _context.FoodOrders
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (foodOrder == null)
            {
                return NotFound();
            }

            return View(foodOrder);
        }

        // POST: FoodOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodOrder = await _context.FoodOrders.FindAsync(id);
            _context.FoodOrders.Remove(foodOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodOrderExists(int id)
        {
            return _context.FoodOrders.Any(e => e.OrderID == id);
        }
    }
}
