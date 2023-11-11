using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UkraineSvoNews.Models;

namespace UkraineSvoNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MainContext _context;
        public HomeController(MainContext context, 
            ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogError("Ошибка доступа!!!");
            return View();
        }
        public async Task<IActionResult> Users()
        {
            ViewData["Users"] = await _context.Users.ToListAsync();
            return View();
        }

        public IActionResult Privacy()
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