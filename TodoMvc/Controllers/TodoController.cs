using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoMvc.Models;

namespace TodoMvc.Controllers
{
    public class TodoController : Controller
    {
        // In-memory store for simplicity
        private static readonly List<TodoItem> Items = new();
        private static int _nextId = 1;

        public IActionResult Index()
        {
            return View(Items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                Items.Add(new TodoItem
                {
                    Id = _nextId++,
                    Title = title,
                    IsCompleted = false
                });
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Toggle(int id)
        {
            var item = Items.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = Items.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                Items.Remove(item);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
