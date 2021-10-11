using FoodStore.Data;
using FoodStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FoodStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodCategories.OrderBy(x => Guid.NewGuid()).ToListAsync());
        }

        public async Task<IActionResult> ViewAllCompanies()
        {
            return View(await _context.Companies.OrderBy(x => Guid.NewGuid()).ToListAsync());
        }

        public async Task<IActionResult> ViewAllCategories()
        {
            return View(await _context.FoodCategories.OrderBy(x => Guid.NewGuid()).ToListAsync());
        }

        public async Task<IActionResult> ViewFoodByCategory(int? id)
        {
            var applicationDbContext = _context.FoodInfos
            .Include(b => b.CategoryFood).Include(b => b.CategoryFood).Where(m => m.CategoryID == id);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> ViewFoodByCompany(int? id)
        {
            var applicationDbContext = _context.FoodInfos
            .Include(b => b.CategoryFood).Include(b => b.CategoryFood).Where(m => m.CompanyID == id);
            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> UserOrderHistory()
        {
            var applicationDbContext = _context.FoodOrders
            .Include(b => b.FoodInfo).Where(m => m.UserID == _userManager.GetUserName(this.User));
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult Success()
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
