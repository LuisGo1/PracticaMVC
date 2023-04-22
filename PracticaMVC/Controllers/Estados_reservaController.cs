using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaMVC.Models;

namespace PracticaMVC.Controllers
{
    public class Estados_reservaController : Controller
    {
        private readonly equiposDbContext _context;

        public Estados_reservaController(equiposDbContext context)
        {
            _context = context;
        }

        // GET: Estados_reserva
        public async Task<IActionResult> Index()
        {
            return _context.Estado_reserva != null ?
                        View(await _context.Estado_reserva.ToListAsync()) :
                        Problem("Entity set 'equiposDbContext.Estado_reserva'  is null.");
        }

        // GET: Estados_reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estado_reserva == null)
            {
                return NotFound();
            }

            var estados_reserva = await _context.Estado_reserva
                .FirstOrDefaultAsync(m => m.estados_res_id == id);
            if (estados_reserva == null)
            {
                return NotFound();
            }

            return View(estados_reserva);
        }

        // GET: Estados_reserva/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estados_reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("estados_res_id,estado")] Estados_reserva estados_reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estados_reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estados_reserva);
        }

        // GET: Estados_reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estado_reserva == null)
            {
                return NotFound();
            }

            var estados_reserva = await _context.Estado_reserva.FindAsync(id);
            if (estados_reserva == null)
            {
                return NotFound();
            }
            return View(estados_reserva);
        }

        // POST: Estados_reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("estados_res_id,estado")] Estados_reserva estados_reserva)
        {
            if (id != estados_reserva.estados_res_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estados_reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Estados_reservaExists(estados_reserva.estados_res_id))
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
            return View(estados_reserva);
        }

        // GET: Estados_reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estado_reserva == null)
            {
                return NotFound();
            }

            var estados_reserva = await _context.Estado_reserva
                .FirstOrDefaultAsync(m => m.estados_res_id == id);
            if (estados_reserva == null)
            {
                return NotFound();
            }

            return View(estados_reserva);
        }

        // POST: Estados_reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estado_reserva == null)
            {
                return Problem("Entity set 'equiposDbContext.Estado_reserva'  is null.");
            }
            var estados_reserva = await _context.Estado_reserva.FindAsync(id);
            if (estados_reserva != null)
            {
                _context.Estado_reserva.Remove(estados_reserva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Estados_reservaExists(int id)
        {
            return (_context.Estado_reserva?.Any(e => e.estados_res_id == id)).GetValueOrDefault();
        }
    }
}