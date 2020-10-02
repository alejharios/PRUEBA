using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prueba2.Data;
using prueba2.Models;

namespace prueba2.Controllers
{
    public class contratosController : Controller
    {
        private readonly prueba2Context _context;

        public contratosController(prueba2Context context)
        {
            _context = context;
        }

        // GET: contratos
        public async Task<IActionResult> Index()
        {
            return View(await _context.contratos.ToListAsync());
        }

        // GET: contratos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await _context.contratos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contratos == null)
            {
                return NotFound();
            }

            return View(contratos);
        }

        // GET: contratos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,numerocontrato,nombreentidad,fechainicio,fechafin")] contratos contratos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contratos);
        }

        // GET: contratos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await _context.contratos.FindAsync(id);
            if (contratos == null)
            {
                return NotFound();
            }
            return View(contratos);
        }

        // POST: contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("Id,numerocontrato,nombreentidad,fechainicio,fechafin")] contratos contratos)
        {
            if (id != contratos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!contratosExists(contratos.Id))
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
            return View(contratos);
        }

        // GET: contratos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await _context.contratos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contratos == null)
            {
                return NotFound();
            }

            return View(contratos);
        }

        // POST: contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var contratos = await _context.contratos.FindAsync(id);
            _context.contratos.Remove(contratos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool contratosExists(long? id)
        {
            return _context.contratos.Any(e => e.Id == id);
        }
    }
}
