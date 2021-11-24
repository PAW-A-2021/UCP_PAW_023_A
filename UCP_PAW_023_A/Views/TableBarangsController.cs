using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP_PAW_023_A.Models;

namespace UCP_PAW_023_A.Views
{
    public class TableBarangsController : Controller
    {
        private readonly MirotaContext _context;

        public TableBarangsController(MirotaContext context)
        {
            _context = context;
        }

        // GET: TableBarangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TableBarangs.ToListAsync());
        }

        // GET: TableBarangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableBarang = await _context.TableBarangs
                .FirstOrDefaultAsync(m => m.IdBarang == id);
            if (tableBarang == null)
            {
                return NotFound();
            }

            return View(tableBarang);
        }

        // GET: TableBarangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TableBarangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBarang,NamaBarang,HargaBarang")] TableBarang tableBarang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tableBarang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tableBarang);
        }

        // GET: TableBarangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableBarang = await _context.TableBarangs.FindAsync(id);
            if (tableBarang == null)
            {
                return NotFound();
            }
            return View(tableBarang);
        }

        // POST: TableBarangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBarang,NamaBarang,HargaBarang")] TableBarang tableBarang)
        {
            if (id != tableBarang.IdBarang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableBarang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableBarangExists(tableBarang.IdBarang))
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
            return View(tableBarang);
        }

        // GET: TableBarangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableBarang = await _context.TableBarangs
                .FirstOrDefaultAsync(m => m.IdBarang == id);
            if (tableBarang == null)
            {
                return NotFound();
            }

            return View(tableBarang);
        }

        // POST: TableBarangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tableBarang = await _context.TableBarangs.FindAsync(id);
            _context.TableBarangs.Remove(tableBarang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableBarangExists(int id)
        {
            return _context.TableBarangs.Any(e => e.IdBarang == id);
        }
    }
}
