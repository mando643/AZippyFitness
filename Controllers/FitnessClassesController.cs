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
    public class FitnessClassesController : Controller
    {
        private readonly MembershipContext _context;

        public FitnessClassesController(MembershipContext context)
        {
            _context = context;
        }

        // GET: FitnessClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.FitnessClasses.ToListAsync());
        }

        // GET: FitnessClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessClass = await _context.FitnessClasses
                .FirstOrDefaultAsync(m => m.fitnessclassId == id);
            if (fitnessClass == null)
            {
                return NotFound();
            }

            return View(fitnessClass);
        }

        // GET: FitnessClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FitnessClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("fitnessclassId,fitnessclassTitle,fitnessclassDescription,fitnessclassDuration,fitnessclassCaloriesBurnedApprox,fitnessclassMaxEnrollees,fitnessclassFee")] FitnessClass fitnessClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fitnessClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fitnessClass);
        }

        // GET: FitnessClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessClass = await _context.FitnessClasses.FindAsync(id);
            if (fitnessClass == null)
            {
                return NotFound();
            }
            return View(fitnessClass);
        }

        // POST: FitnessClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("fitnessclassId,fitnessclassTitle,fitnessclassDescription,fitnessclassDuration,fitnessclassCaloriesBurnedApprox,fitnessclassMaxEnrollees,fitnessclassFee")] FitnessClass fitnessClass)
        {
            if (id != fitnessClass.fitnessclassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fitnessClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FitnessClassExists(fitnessClass.fitnessclassId))
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
            return View(fitnessClass);
        }

        // GET: FitnessClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessClass = await _context.FitnessClasses
                .FirstOrDefaultAsync(m => m.fitnessclassId == id);
            if (fitnessClass == null)
            {
                return NotFound();
            }

            return View(fitnessClass);
        }

        // POST: FitnessClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fitnessClass = await _context.FitnessClasses.FindAsync(id);
            _context.FitnessClasses.Remove(fitnessClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FitnessClassExists(int id)
        {
            return _context.FitnessClasses.Any(e => e.fitnessclassId == id);
        }
    }
}
