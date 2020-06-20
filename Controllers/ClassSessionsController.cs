using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using A10.Models;

namespace A10.Controllers
{
    public class ClassSessionsController : Controller
    {
        private readonly MembershipContext _context;

        public ClassSessionsController(MembershipContext context)
        {
            _context = context;
        }

        // GET: ClassSessions
        public async Task<IActionResult> Index()
        {
            var membershipContext = _context.ClassSessions.Include(c => c.FitnessClass).Include(c => c.Location);
            return View(await membershipContext.ToListAsync());
        }

        // GET: ClassSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classSession = await _context.ClassSessions
                .Include(c => c.FitnessClass)
                .Include(c => c.Location)
                .FirstOrDefaultAsync(m => m.classSessionId == id);
            if (classSession == null)
            {
                return NotFound();
            }

            return View(classSession);
        }

        // GET: ClassSessions/Create
        public IActionResult Create()
        {
            ViewData["fitnessClassId"] = new SelectList(_context.FitnessClasses, "fitnessclassId", "fitnessclassId");
            ViewData["locationId"] = new SelectList(_context.Locations, "locationId", "locationId");

            return View();
        }

        // POST: ClassSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("classSessionId,fitnessClassId,ClassSessionStartTime,locationId")] ClassSession classSession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["fitnessClassId"] = new SelectList(_context.FitnessClasses, "fitnessclassId", "fitnessclassId", classSession.fitnessClassId);
            ViewData["locationId"] = new SelectList(_context.Locations, "locationId", "locationId", classSession.locationId);
            return View(classSession);
        }

        // GET: ClassSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classSession = await _context.ClassSessions.FindAsync(id);
            if (classSession == null)
            {
                return NotFound();
            }
            ViewData["fitnessClassId"] = new SelectList(_context.FitnessClasses, "fitnessclassId", "fitnessclassId", classSession.fitnessClassId);
            ViewData["locationId"] = new SelectList(_context.Locations, "locationId", "locationId", classSession.locationId);
            return View(classSession);
        }

        // POST: ClassSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("classSessionId,fitnessClassId,ClassSessionStartTime,locationId")] ClassSession classSession)
        {
            if (id != classSession.classSessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassSessionExists(classSession.classSessionId))
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
            ViewData["fitnessClassId"] = new SelectList(_context.FitnessClasses, "fitnessclassId", "fitnessclassId", classSession.fitnessClassId);
            ViewData["locationId"] = new SelectList(_context.Locations, "locationId", "locationId", classSession.locationId);
            return View(classSession);
        }

        // GET: ClassSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classSession = await _context.ClassSessions
                .Include(c => c.FitnessClass)
                .Include(c => c.Location)
                .FirstOrDefaultAsync(m => m.classSessionId == id);
            if (classSession == null)
            {
                return NotFound();
            }

            return View(classSession);
        }

        // POST: ClassSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classSession = await _context.ClassSessions.FindAsync(id);
            _context.ClassSessions.Remove(classSession);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassSessionExists(int id)
        {
            return _context.ClassSessions.Any(e => e.classSessionId == id);
        }
    }
}
