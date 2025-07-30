using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlaniT.Data;
using PlaniT.Models;
using System.Security.Claims;

namespace PlaniT.Controllers
{
    [Authorize]
    public class FutureVisionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public FutureVisionController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Json(new { redirectUrl = Url.Action("Register", "Account") });

            var items = _context.FutureVisionItems
                .Where(i => i.UserId == userId)
                .ToList();

            return PartialView("_FutureVision", items);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(string text)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            if (string.IsNullOrWhiteSpace(text))
                return BadRequest("Text is required");

            var item = new FutureVisionItem
            {
                Text = text,
                UserId = userId
            };

            _context.FutureVisionItems.Add(item);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var item = _context.FutureVisionItems
                .FirstOrDefault(i => i.Id == id && i.UserId == userId);

            if (item == null)
                return NotFound();

            _context.FutureVisionItems.Remove(item);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string text)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var item = _context.FutureVisionItems
                .FirstOrDefault(i => i.Id == id && i.UserId == userId);

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
