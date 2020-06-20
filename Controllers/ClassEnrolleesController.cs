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
    public class ClassEnrolleesController : Controller
    {
        private readonly MembershipContext _context;

        public ClassEnrolleesController(MembershipContext context)
        {
            _context = context;
        }

        // GET: ClassEnrollees
        public async Task<IActionResult> Index()
        {
            var membershipContext = _context.ClassEnrollees.Include(c => c.ClassSession).ThenInclude(c => c.FitnessClass).Include(c => c.Member);
            return View(await membershipContext.ToListAsync());
        }

        // GET: ClassEnrollees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classEnrollee = await _context.ClassEnrollees
                .Include(c => c.ClassSession)
                .Include(c => c.Member)
                .FirstOrDefaultAsync(m => m.enrolledRegistrationId == id);
            if (classEnrollee == null)
            {
                return NotFound();
            }

            return View(classEnrollee);
        }

        // GET: ClassEnrollees/Create
        public IActionResult Create()
        {
            var classList = new List<SelectListItem>();
            var classes = _context.ClassSessions
                .Include(c => c.FitnessClass);
             
            foreach (var c in classes)
            {
                classList.Add(new SelectListItem
                {
                    Text = c.FitnessClass.fitnessclassTitle,
                    Value = c.classSessionId.ToString()
                }); 
            }
          
            var memberList = new List<SelectListItem>();
            foreach (var m in _context.Members)
            {
                memberList.Add(new SelectListItem
                {
                    Text = m.firstName + " " + m.lastName,
                    Value = m.memberId.ToString()
                });
            }
            ViewBag.listOfMembers = memberList;
            ViewBag.classsession = classList;
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("enrolledRegistrationId,classSessionId,memberId")] ClassEnrollee classEnrollee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classEnrollee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["classSessionId"] = new SelectList(_context.ClassSessions, "classSessionId", "classSessionId", classEnrollee.classSessionId);
            ViewData["memberId"] = new SelectList(_context.Members, "memberId", "memberId", classEnrollee.memberId);
            return View(classEnrollee);
        }

        // GET: ClassEnrollees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classEnrollee = await _context.ClassEnrollees.FindAsync(id);
            if (classEnrollee == null)
            {
                return NotFound();
            }
            ViewData["classSessionId"] = new SelectList(_context.ClassSessions, "classSessionId", "classSessionId", classEnrollee.classSessionId);
            ViewData["memberId"] = new SelectList(_context.Members, "memberId", "memberId", classEnrollee.memberId);
            return View(classEnrollee);
        }

        // POST: ClassEnrollees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("enrolledRegistrationId,classSessionId,memberId")] ClassEnrollee classEnrollee)
        {
            if (id != classEnrollee.enrolledRegistrationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classEnrollee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassEnrolleeExists(classEnrollee.enrolledRegistrationId))
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
            ViewData["classSessionId"] = new SelectList(_context.ClassSessions, "classSessionId", "classSessionId", classEnrollee.classSessionId);
            ViewData["memberId"] = new SelectList(_context.Members, "memberId", "memberId", classEnrollee.memberId);
            return View(classEnrollee);
        }

        // GET: ClassEnrollees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classEnrollee = await _context.ClassEnrollees
                .Include(c => c.ClassSession)
                .Include(c => c.Member)
                .FirstOrDefaultAsync(m => m.enrolledRegistrationId == id);
            if (classEnrollee == null)
            {
                return NotFound();
            }

            return View(classEnrollee);
        }

        // POST: ClassEnrollees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classEnrollee = await _context.ClassEnrollees.FindAsync(id);
            _context.ClassEnrollees.Remove(classEnrollee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassEnrolleeExists(int id)
        {
            return _context.ClassEnrollees.Any(e => e.enrolledRegistrationId == id);
        }
    }
}
