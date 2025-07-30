using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaniT.Data;
using PlaniT.Models;
using System.Security.Claims;

namespace PlaniT.Controllers
{
    [Authorize]
    public class TodayTemplateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodayTemplateController(ApplicationDbContext context)
        {
            _context = context;
        }

        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = GetUserId();
            if (userId == null)
                return Json(new { redirectUrl = Url.Action("register", "Account") });

            var items = await _context.TodayTemplateItems
                                .Where(x => x.UserId == userId) // لو مستقبلًا حبيت تربط العناصر بالمستخدم
                                .ToListAsync();

            return PartialView("_TodayTemplate", items);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string title)
        {
            var userId = GetUserId();
            if (userId == null)
                return Json(new { redirectUrl = Url.Action("register", "Account") });

            if (string.IsNullOrWhiteSpace(title))
                return BadRequest("Title is required");

            var item = new TodayTemplateItem
            {
                Title = title,
                UserId = userId // لو عايز تربط العنصر بالمستخدم مستقبلاً
            };

            await _context.TodayTemplateItems.AddAsync(item);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = GetUserId();
            if (userId == null)
                return Json(new { redirectUrl = Url.Action("register", "Account") });

            var item = await _context.TodayTemplateItems.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
            if (item == null)
                return NotFound();

            _context.TodayTemplateItems.Remove(item);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string title)
        {
            var userId = GetUserId();
            if (userId == null)
                return Json(new { redirectUrl = Url.Action("register", "Account") });

            if (string.IsNullOrWhiteSpace(title))
                return BadRequest("Title is required");

            var item = await _context.TodayTemplateItems.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
            if (item == null)
                return NotFound();

            item.Title = title;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
