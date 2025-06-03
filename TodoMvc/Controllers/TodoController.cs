using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoMvc.Models;
using TodoMvc.Data;
using TodoMvc.Filters;

namespace TodoMvc.Controllers
{
    [ServiceFilter(typeof(RequireLoginAttribute))]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _context.Items.Include(i => i.AssignedTo)
                .AsNoTracking().ToListAsync();
            ViewBag.Users = await _context.Users.AsNoTracking().ToListAsync();
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Users = await _context.Users.AsNoTracking().ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string title, int assignedToId)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                _context.Items.Add(new TodoItem
                {
                    Title = title,
                    IsCompleted = false,
                    AssignedToId = assignedToId
                });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Toggle(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
