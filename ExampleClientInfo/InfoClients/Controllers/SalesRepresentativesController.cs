using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InfoClients.Data;
using InfoClients.Models;

namespace InfoClients.Controllers
{
    public class SalesRepresentativesController : Controller
    {
        private readonly DbInfoClientesContext _context;

        public SalesRepresentativesController(DbInfoClientesContext context)
        {
            _context = context;
        }

        // GET: SalesRepresentatives
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesRepresentatives.ToListAsync());
        }

        // GET: SalesRepresentatives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesRepresentative = await _context.SalesRepresentatives
                .FirstOrDefaultAsync(m => m.SalesRepresentativeId == id);
            if (salesRepresentative == null)
            {
                return NotFound();
            }

            return View(salesRepresentative);
        }

        // GET: SalesRepresentatives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesRepresentatives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesRepresentativeId,Fullname,Employecode")] SalesRepresentative salesRepresentative)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesRepresentative);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesRepresentative);
        }

        // GET: SalesRepresentatives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesRepresentative = await _context.SalesRepresentatives.FindAsync(id);
            if (salesRepresentative == null)
            {
                return NotFound();
            }
            return View(salesRepresentative);
        }

        // POST: SalesRepresentatives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesRepresentativeId,Fullname,Employecode")] SalesRepresentative salesRepresentative)
        {
            if (id != salesRepresentative.SalesRepresentativeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesRepresentative);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesRepresentativeExists(salesRepresentative.SalesRepresentativeId))
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
            return View(salesRepresentative);
        }

        // GET: SalesRepresentatives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesRepresentative = await _context.SalesRepresentatives
                .FirstOrDefaultAsync(m => m.SalesRepresentativeId == id);
            if (salesRepresentative == null)
            {
                return NotFound();
            }

            return View(salesRepresentative);
        }

        // POST: SalesRepresentatives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesRepresentative = await _context.SalesRepresentatives.FindAsync(id);
            _context.SalesRepresentatives.Remove(salesRepresentative);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesRepresentativeExists(int id)
        {
            return _context.SalesRepresentatives.Any(e => e.SalesRepresentativeId == id);
        }
    }
}
