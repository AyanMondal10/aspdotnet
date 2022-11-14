using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstApproach.Models;

namespace DatabaseFirstApproach.Controllers
{
    public class StudentDbsController : Controller
    {
        private readonly StudentDbContext _context;

        public StudentDbsController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: StudentDbs
        public async Task<IActionResult> Index()
        {
              return View(await _context.StudentDbs.ToListAsync());
        }

        // GET: StudentDbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentDbs == null)
            {
                return NotFound();
            }

            var studentDb = await _context.StudentDbs
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentDb == null)
            {
                return NotFound();
            }

            return View(studentDb);
        }

        // GET: StudentDbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentDbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,Department,Course")] StudentDb studentDb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentDb);
        }

        // GET: StudentDbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentDbs == null)
            {
                return NotFound();
            }

            var studentDb = await _context.StudentDbs.FindAsync(id);
            if (studentDb == null)
            {
                return NotFound();
            }
            return View(studentDb);
        }

        // POST: StudentDbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,Department,Course")] StudentDb studentDb)
        {
            if (id != studentDb.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentDbExists(studentDb.StudentId))
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
            return View(studentDb);
        }

        // GET: StudentDbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentDbs == null)
            {
                return NotFound();
            }

            var studentDb = await _context.StudentDbs
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentDb == null)
            {
                return NotFound();
            }

            return View(studentDb);
        }

        // POST: StudentDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentDbs == null)
            {
                return Problem("Entity set 'StudentDbContext.StudentDbs'  is null.");
            }
            var studentDb = await _context.StudentDbs.FindAsync(id);
            if (studentDb != null)
            {
                _context.StudentDbs.Remove(studentDb);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentDbExists(int id)
        {
          return _context.StudentDbs.Any(e => e.StudentId == id);
        }
    }
}
