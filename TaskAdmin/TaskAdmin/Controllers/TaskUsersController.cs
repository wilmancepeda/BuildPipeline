using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskAdmin.Models;

namespace TaskAdmin.Controllers
{
    public class TaskUsersController : Controller
    {
        private readonly TaskAdminContext _context;

        public TaskUsersController(TaskAdminContext context)
        {
            _context = context;
        }

        // GET: TaskUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaskUser.ToListAsync());
        }

        // GET: TaskUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskUser = await _context.TaskUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskUser == null)
            {
                return NotFound();
            }

            return View(taskUser);
        }

        // GET: TaskUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] TaskUser taskUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskUser);
        }

        // GET: TaskUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskUser = await _context.TaskUser.FindAsync(id);
            if (taskUser == null)
            {
                return NotFound();
            }
            return View(taskUser);
        }

        // POST: TaskUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] TaskUser taskUser)
        {
            if (id != taskUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskUserExists(taskUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(taskUser);
        }

        // GET: TaskUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskUser = await _context.TaskUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskUser == null)
            {
                return NotFound();
            }

            return View(taskUser);
        }

        // POST: TaskUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskUser = await _context.TaskUser.FindAsync(id);
            _context.TaskUser.Remove(taskUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskUserExists(int id)
        {
            return _context.TaskUser.Any(e => e.Id == id);
        }
    }
}
