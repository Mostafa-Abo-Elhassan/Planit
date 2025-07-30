using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaniT.Data;
using PlaniT.Models;
using System.Security.Claims;

namespace PlaniT.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = new PlannerViewModel
            {
                TodayTemplateItems = _context.TodayTemplateItems.Where(i => i.UserId == userId)
                .ToList(),
                DayCards = _context.DayCards.Include(c => c.Tasks).Where(i => i.UserId == userId)
                .ToList(),
                FutureVisionItems = _context.FutureVisionItems.Where(i => i.UserId == userId)
                .ToList(),
            };
            return View(viewModel);
        }
    }
}