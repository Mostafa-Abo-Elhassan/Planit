using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaniT.Data;
using PlaniT.Models;

namespace PlaniT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new PlannerViewModel
            {
                TodayTemplateItems = _context.TodayTemplateItems.ToList(),
                DayCards = _context.DayCards.Include(c => c.Tasks).ToList(),
                FutureVisionItems = _context.FutureVisionItems.ToList()
            };
            return View(viewModel);
        }
    }
}