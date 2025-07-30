using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaniT.Data;
using PlaniT.Models;
using System.Security.Claims;

namespace PlaniT.Controllers
{
    [Authorize]
    public class DayCardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DayCardController(ApplicationDbContext context)
        {
            _context = context;
        }

        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userId = GetUserId();
            if (userId == null)
                return Json(new { redirectUrl = Url.Action("register", "Account") });

            var cards = _context.DayCards
                                .Include(c => c.Tasks)
                                .Where(c => c.UserId == userId)
                                .ToList();

            return PartialView("_DayCards", cards);
        }

        [HttpPost]
        public IActionResult AddCard(string dayName)
        {
            var userId = GetUserId();
            if (userId == null)
                return Json(new { redirectUrl = Url.Action("register", "Account") });

            if (string.IsNullOrWhiteSpace(dayName))
                return BadRequest("Day name is required");

            var card = new DayCard { DayName = dayName, UserId = userId };

            _context.DayCards.Add(card);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult AddTask(int dayCardId, string taskText)
        {
            var userId = GetUserId();
            if (userId == null)
                return Json(new { redirectUrl = Url.Action("register", "Account") });

            if (string.IsNullOrWhiteSpace(taskText))
                return BadRequest("Task text is required");

            var card = _context.DayCards.FirstOrDefault(c => c.Id == dayCardId && c.UserId == userId);
            if (card == null)
                return NotFound();

            var task = new DayTask { TaskText = taskText, DayCardId = dayCardId, UserId = userId };
            _context.DayTasks.Add(task);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            var userId = GetUserId();
            if (userId == null)
                return Json(new { redirectUrl = Url.Action("register", "Account") });

            var task = _context.DayTasks
                               .Include(t => t.DayCard)
                               .FirstOrDefault(t => t.Id == id && t.DayCard.UserId == userId);

            if (task == null)
                return NotFound();

            _context.DayTasks.Remove(task);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult DeleteCard(int id)
        {
            var userId = GetUserId();
            if (userId == null)
                return Json(new { redirectUrl = Url.Action("register", "Account") });

            var card = _context.DayCards
                               .Include(c => c.Tasks)
                               .FirstOrDefault(c => c.Id == id && c.UserId == userId);

            if (card == null)
                return NotFound();

            _context.DayTasks.RemoveRange(card.Tasks);
            _context.DayCards.Remove(card);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult EditTask(int id, string taskText)
        {
            var userId = GetUserId();
            if (userId == null)
                return Json(new { redirectUrl = Url.Action("register", "Account") });

            if (string.IsNullOrWhiteSpace(taskText))
                return BadRequest("Task text is required");

            var task = _context.DayTasks
                               .Include(t => t.DayCard)
                               .FirstOrDefault(t => t.Id == id && t.DayCard.UserId == userId);

            if (task == null)
                return NotFound();

            task.TaskText = taskText;
            _context.SaveChanges();
            return Ok();
        }
    }
}
