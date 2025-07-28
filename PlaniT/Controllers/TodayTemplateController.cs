using Microsoft.AspNetCore.Mvc;
using PlaniT.Data;
using PlaniT.Models;

namespace PlaniT.Controllers
{
    public class TodayTemplateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodayTemplateController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var items = _context.TodayTemplateItems.ToList();
            return PartialView("_TodayTemplate", items);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Add(string title)
        {
            if (title == null)
                return BadRequest("Title is required");

            var item = new TodayTemplateItem { Title = title };
            _context.TodayTemplateItems.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var item = _context.TodayTemplateItems.Find(id);
            if (item == null)
                return NotFound();

            _context.TodayTemplateItems.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(int id, string title)
        {
            var item = _context.TodayTemplateItems.Find(id);
            if (item == null)
                return NotFound();

            if (title == null)
                return BadRequest("Title is required");

            item.Title = title;
            _context.SaveChanges();
            return Ok();
        }
    }
}