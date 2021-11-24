using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP_PAW_023_A.Models;

namespace UCP_PAW_023_A.Controllers
{
    public class TablePenjualsController : Controller
    {
        private readonly MirotaContext _context;

        public TablePenjualsController(MirotaContext context)
        {
            _context = context;
        }

        // GET: TablePenjuals
        public async Task<IActionResult> Index()
        {
            return View(await _context.TablePenjuals.ToListAsync());
        }

        // GET: TablePenjuals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablePenjual = await _context.TablePenjuals
                .FirstOrDefaultAsync(m => m.IdPenjual == id);
            if (tablePenjual == null)
            {
                return NotFound();
            }

            return View(tablePenjual);
        }

        // GET: TablePenjuals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TablePenjuals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPenjual,NamaPenjual")] TablePenjual tablePenjual)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablePenjual);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablePenjual);
        }

        // GET: TablePenjuals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablePenjual = await _context.TablePenjuals.FindAsync(id);
            if (tablePenjual == null)
            {
                return NotFound();
            }
            return View(tablePenjual);
        }

        // POST: TablePenjuals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPenjual,NamaPenjual")] TablePenjual tablePenjual)
        {
            if (id != tablePenjual.IdPenjual)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablePenjual);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablePenjualExists(tablePenjual.IdPenjual))
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
            return View(tablePenjual);
        }

        // GET: TablePenjuals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablePenjual = await _context.TablePenjuals
                .FirstOrDefaultAsync(m => m.IdPenjual == id);
            if (tablePenjual == null)
            {
                return NotFound();
            }

            return View(tablePenjual);
        }

        // POST: TablePenjuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablePenjual = await _context.TablePenjuals.FindAsync(id);
            _context.TablePenjuals.Remove(tablePenjual);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablePenjualExists(int id)
        {
            return _context.TablePenjuals.Any(e => e.IdPenjual == id);
        }
    }
}
