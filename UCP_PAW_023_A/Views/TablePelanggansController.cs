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
    public class TablePelanggansController : Controller
    {
        private readonly MirotaContext _context;

        public TablePelanggansController(MirotaContext context)
        {
            _context = context;
        }

        // GET: TablePelanggans
        public async Task<IActionResult> Index()
        {
            return View(await _context.TablePelanggans.ToListAsync());
        }

        // GET: TablePelanggans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablePelanggan = await _context.TablePelanggans
                .FirstOrDefaultAsync(m => m.IdPelanggan == id);
            if (tablePelanggan == null)
            {
                return NotFound();
            }

            return View(tablePelanggan);
        }

        // GET: TablePelanggans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TablePelanggans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPelanggan,NamaPelanggan,NoTelpon")] TablePelanggan tablePelanggan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablePelanggan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablePelanggan);
        }

        // GET: TablePelanggans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablePelanggan = await _context.TablePelanggans.FindAsync(id);
            if (tablePelanggan == null)
            {
                return NotFound();
            }
            return View(tablePelanggan);
        }

        // POST: TablePelanggans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPelanggan,NamaPelanggan,NoTelpon")] TablePelanggan tablePelanggan)
        {
            if (id != tablePelanggan.IdPelanggan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablePelanggan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablePelangganExists(tablePelanggan.IdPelanggan))
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
            return View(tablePelanggan);
        }

        // GET: TablePelanggans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablePelanggan = await _context.TablePelanggans
                .FirstOrDefaultAsync(m => m.IdPelanggan == id);
            if (tablePelanggan == null)
            {
                return NotFound();
            }

            return View(tablePelanggan);
        }

        // POST: TablePelanggans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablePelanggan = await _context.TablePelanggans.FindAsync(id);
            _context.TablePelanggans.Remove(tablePelanggan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablePelangganExists(int id)
        {
            return _context.TablePelanggans.Any(e => e.IdPelanggan == id);
        }
    }
}
