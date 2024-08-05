using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;
using System.Threading.Tasks;
using System.Linq;

namespace TodoList.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        // GET: TodoController
        public async Task<ActionResult> Index()
        {
            var todos = await _context.Todos.ToListAsync();
            return PartialView("Todos/_AllTodos", todos);
        }

        // GET: TodoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // GET: TodoController/Create
        public ActionResult Create()
        {
            return RedirectToAction("Index", "Home");
        }

        // POST: TodoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Name,Description")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Home", todo);
        }

        // GET: TodoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TodoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TodoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
