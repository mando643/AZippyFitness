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
    public class MembersController : Controller
    {
        private readonly MembershipContext _context;

        public MembersController(MembershipContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            var membershipContext = _context.Members.Include(m => m.MembershipStatus).Include(m => m.MembershipType).Include(m => m.primaryLocation);
            return View(await membershipContext.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .Include(m => m.MembershipStatus)
                .Include(m => m.MembershipType)
                .Include(m => m.primaryLocation)
                .FirstOrDefaultAsync(m => m.memberId == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            ViewData["membershipStatusId"] = new SelectList(_context.MembershipStatuses, "membershipStatusId", "membershipStatusId");
            ViewData["membershipTypeId"] = new SelectList(_context.MembershipTypes, "membershipTypeId", "membershipTypeId");
            ViewData["primaryLocationId"] = new SelectList(_context.Locations, "locationId", "locationId");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("memberId,lastName,firstName,streetAddress,city,state,zipCode,emailAddress,phoneHome,phoneCell,membershipTypeId,employerCompanyName,employerPhoneNumber,membershipStatusId,emergencyContactName,emergencyContactPhone,emergencyContactRelationship,currentAmountOwed,primaryLocationId")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["membershipStatusId"] = new SelectList(_context.MembershipStatuses, "membershipStatusId", "membershipStatusId", member.membershipStatusId);
            ViewData["membershipTypeId"] = new SelectList(_context.MembershipTypes, "membershipTypeId", "membershipTypeId", member.membershipTypeId);
            ViewData["primaryLocationId"] = new SelectList(_context.Locations, "locationId", "locationId", member.primaryLocationId);
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            ViewData["membershipStatusId"] = new SelectList(_context.MembershipStatuses, "membershipStatusId", "membershipStatusId", member.membershipStatusId);
            ViewData["membershipTypeId"] = new SelectList(_context.MembershipTypes, "membershipTypeId", "membershipTypeId", member.membershipTypeId);
            ViewData["primaryLocationId"] = new SelectList(_context.Locations, "locationId", "locationId", member.primaryLocationId);
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("memberId,lastName,firstName,streetAddress,city,state,zipCode,emailAddress,phoneHome,phoneCell,membershipTypeId,employerCompanyName,employerPhoneNumber,membershipStatusId,emergencyContactName,emergencyContactPhone,emergencyContactRelationship,currentAmountOwed,primaryLocationId")] Member member)
        {
            if (id != member.memberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.memberId))
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
            ViewData["membershipStatusId"] = new SelectList(_context.MembershipStatuses, "membershipStatusId", "membershipStatusId", member.membershipStatusId);
            ViewData["membershipTypeId"] = new SelectList(_context.MembershipTypes, "membershipTypeId", "membershipTypeId", member.membershipTypeId);
            ViewData["primaryLocationId"] = new SelectList(_context.Locations, "locationId", "locationId", member.primaryLocationId);
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .Include(m => m.MembershipStatus)
                .Include(m => m.MembershipType)
                .Include(m => m.primaryLocation)
                .FirstOrDefaultAsync(m => m.memberId == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Members.FindAsync(id);
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.memberId == id);
        }
    }
}
