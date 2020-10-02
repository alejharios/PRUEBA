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
    public class trabajadoresController : Controller
    {
        private readonly prueba2Context _context;

        public trabajadoresController(prueba2Context context)
        {
            _context = context;
        }

        // GET: trabajadores
        public async Task<IActionResult> Index()
        {
            var prueba2Context = _context.trabajadores.Include(t => t.contratos);
            return View(await prueba2Context.ToListAsync());
        }

        // GET: trabajadores/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajadores = await _context.trabajadores
                .Include(t => t.contratos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabajadores == null)
            {
                return NotFound();
            }

            return View(trabajadores);
        }

        // GET: trabajadores/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Set<contratos>(), "Id", "Id");
            return View();
        }

        // POST: trabajadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("trabajadorId,identificacion,tipoindetificacion,primernombre,segundonombre,primerapellido,segundoapellido,fechadenacimineto,Id")] trabajadores trabajadores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trabajadores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Set<contratos>(), "Id", "Id", trabajadores.Id);
            return View(trabajadores);
        }

        // GET: trabajadores/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajadores = await _context.trabajadores.FindAsync(id);
            if (trabajadores == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Set<contratos>(), "Id", "Id", trabajadores.Id);
            return View(trabajadores);
        }

        // POST: trabajadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("trabajadorId,identificacion,tipoindetificacion,primernombre,segundonombre,primerapellido,segundoapellido,fechadenacimineto,Id")] trabajadores trabajadores)
        {
            if (id != trabajadores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabajadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!trabajadoresExists(trabajadores.Id))
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
            ViewData["Id"] = new SelectList(_context.Set<contratos>(), "Id", "Id", trabajadores.Id);
            return View(trabajadores);
        }

        // GET: trabajadores/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajadores = await _context.trabajadores
                .Include(t => t.contratos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabajadores == null)
            {
                return NotFound();
            }

            return View(trabajadores);
        }

        // POST: trabajadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var trabajadores = await _context.trabajadores.FindAsync(id);
            _context.trabajadores.Remove(trabajadores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool trabajadoresExists(long id)
        {
            return _context.trabajadores.Any(e => e.Id == id);
        }
    }
}
