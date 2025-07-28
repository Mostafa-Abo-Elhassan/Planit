using Microsoft.AspNetCore.Mvc;
using PlaniT.Data;
using PlaniT.Models;

namespace PlaniT.Controllers
{
    public class FutureVisionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FutureVisionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _context.FutureVisionItems.ToList();
            return PartialView("_FutureVision", items);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Add(string text)
        {
            if (text == null)
                return BadRequest("Text is required");

            var item = new FutureVisionItem { Text = text };
            _context.FutureVisionItems.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var item = _context.FutureVisionItems.Find(id);
            if (item == null)
                return NotFound();

            _context.FutureVisionItems.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(int id, string text)
        {
            var item = _context.FutureVisionItems.Find(id);
            if (item == null)
                return NotFound();

            if (string.IsNullOrWhiteSpace(text))
                return BadRequest("Text is required");

            item.Text = text;
            _context.SaveChanges();
            return Ok();
        }
    }
}