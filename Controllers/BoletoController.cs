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
    public class BoletoController : Controller
    {
        private readonly MyDbContext _context;

        public BoletoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Boleto
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.boleto.Include(b => b.pedido);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Boleto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boleto = await _context.boleto
                .Include(b => b.pedido)
                .FirstOrDefaultAsync(m => m.id == id);
            if (boleto == null)
            {
                return NotFound();
            }

            return View(boleto);
        }

        // GET: Boleto/Create
        public IActionResult Create()
        {
            ViewData["pedidoId"] = new SelectList(_context.pedido, "id", "id");
            return View();
        }

        // POST: Boleto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codigo,id,valorTotal,pedidoId")] Boleto boleto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boleto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["pedidoId"] = new SelectList(_context.pedido, "id", "id", boleto.pedidoId);
            return View(boleto);
        }

        // GET: Boleto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boleto = await _context.boleto.FindAsync(id);
            if (boleto == null)
            {
                return NotFound();
            }
            ViewData["pedidoId"] = new SelectList(_context.pedido, "id", "id", boleto.pedidoId);
            return View(boleto);
        }

        // POST: Boleto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("codigo,id,valorTotal,pedidoId")] Boleto boleto)
        {
            if (id != boleto.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boleto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoletoExists(boleto.id))
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
            ViewData["pedidoId"] = new SelectList(_context.pedido, "id", "id", boleto.pedidoId);
            return View(boleto);
        }

        // GET: Boleto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boleto = await _context.boleto
                .Include(b => b.pedido)
                .FirstOrDefaultAsync(m => m.id == id);
            if (boleto == null)
            {
                return NotFound();
            }

            return View(boleto);
        }

        // POST: Boleto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boleto = await _context.boleto.FindAsync(id);
            _context.boleto.Remove(boleto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoletoExists(int id)
        {
            return _context.boleto.Any(e => e.id == id);
        }
    }
}
