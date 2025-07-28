using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaniT.Data;
using PlaniT.Models;

namespace PlaniT.Controllers
{
    public class DayCardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DayCardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cards = _context.DayCards.Include(c => c.Tasks).ToList();
            return PartialView("_DayCards", cards);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddCard(string dayName)
        {
            if (dayName == null)
                return BadRequest("Day name is required");

            var card = new DayCard { DayName = dayName };
            _context.DayCards.Add(card);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddTask(int dayCardId, string taskText)
        {
            if (taskText == null || dayCardId == null)
                return BadRequest("Task text is required");

            var card = _context.DayCards.Find(dayCardId);
            if (card == null)
                return NotFound();

            var task = new DayTask { TaskText = taskText, DayCardId = dayCardId };
            _context.DayTasks.Add(task);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.DayTasks.Find(id);
            if (task == null)
                return NotFound();

            _context.DayTasks.Remove(task);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult DeleteCard(int id)
        {
            var card = _context.DayCards.Include(c => c.Tasks).FirstOrDefault(c => c.Id == id);
            if (card == null)
                return NotFound();

            _context.DayTasks.RemoveRange(card.Tasks);
            _context.DayCards.Remove(card);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult EditTask(int id, string taskText)
        {
            var item = _context.DayTasks.Find(id);
            if (item == null)
                return NotFound();

            if (taskText == null)
                return BadRequest("Title is required");

            item.TaskText = taskText;
            _context.SaveChanges();
            return Ok();
        }
    }
}