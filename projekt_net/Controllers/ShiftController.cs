using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projekt_net.Data;
using projekt_net.Models;

namespace projekt_net
{
    public class ShiftController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShiftController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shift
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Shift.Include(s => s.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: /xhours
        [Route("/xhours")]
        public async Task<IActionResult> xhours()
        {
            var applicationDbContext = _context.Shift.Include(s => s.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Shift/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shift == null)
            {
                return NotFound();
            }

            var shift = await _context.Shift
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shift == null)
            {
                return NotFound();
            }

            return View(shift);
        }

        // GET: Shift/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name");
            return View();
        }

        // POST: Shift/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Type,From,To,Abscence,EmployeeId")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shift);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", shift.EmployeeId);
            return View(shift);
        }

        // GET: Shift/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shift == null)
            {
                return NotFound();
            }

            var shift = await _context.Shift.FindAsync(id);
            if (shift == null)
            {
                return NotFound();
            }

            ViewData["EmployeeEmail"] = new SelectList(_context.Employees, "Id", "Email", shift.EmployeeId);
            ViewData["EmployeeName"] = new SelectList(_context.Employees, "Id", "Name", shift.EmployeeId);
            return View(shift);
        }

        // POST: Shift/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,From,To,Abscence,EmployeeId")] Shift shift)
        {
            if (id != shift.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shift);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShiftExists(shift.Id))
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
            ViewData["EmployeeEmail"] = new SelectList(_context.Employees, "Id", "Email", shift.EmployeeId);
            ViewData["EmployeeName"] = new SelectList(_context.Employees, "Id", "Name", shift.EmployeeId);

            return View(shift);
        }

        // GET: Shift/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shift == null)
            {
                return NotFound();
            }

            var shift = await _context.Shift
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shift == null)
            {
                return NotFound();
            }

            return View(shift);
        }

        // POST: Shift/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shift == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Shift'  is null.");
            }
            var shift = await _context.Shift.FindAsync(id);
            if (shift != null)
            {
                _context.Shift.Remove(shift);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShiftExists(int id)
        {
          return (_context.Shift?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
