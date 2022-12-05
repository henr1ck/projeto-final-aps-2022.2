#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class CreditoController : Controller
    {
        private readonly MyDbContext _context;

        public CreditoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Credito
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.credito.Include(c => c.pedido);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Credito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credito = await _context.credito
                .Include(c => c.pedido)
                .FirstOrDefaultAsync(m => m.id == id);
            if (credito == null)
            {
                return NotFound();
            }

            return View(credito);
        }

        // GET: Credito/Create
        public IActionResult Create()
        {
            ViewData["pedidoId"] = new SelectList(_context.pedido, "id", "id");
            return View();
        }

        // POST: Credito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("numero,id,valorTotal,pedidoId")] Credito credito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(credito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["pedidoId"] = new SelectList(_context.pedido, "id", "id", credito.pedidoId);
            return View(credito);
        }

        // GET: Credito/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credito = await _context.credito.FindAsync(id);
            if (credito == null)
            {
                return NotFound();
            }
            ViewData["pedidoId"] = new SelectList(_context.pedido, "id", "id", credito.pedidoId);
            return View(credito);
        }

        // POST: Credito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("numero,id,valorTotal,pedidoId")] Credito credito)
        {
            if (id != credito.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(credito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditoExists(credito.id))
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
            ViewData["pedidoId"] = new SelectList(_context.pedido, "id", "id", credito.pedidoId);
            return View(credito);
        }

        // GET: Credito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credito = await _context.credito
                .Include(c => c.pedido)
                .FirstOrDefaultAsync(m => m.id == id);
            if (credito == null)
            {
                return NotFound();
            }

            return View(credito);
        }

        // POST: Credito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var credito = await _context.credito.FindAsync(id);
            _context.credito.Remove(credito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditoExists(int id)
        {
            return _context.credito.Any(e => e.id == id);
        }
    }
}
