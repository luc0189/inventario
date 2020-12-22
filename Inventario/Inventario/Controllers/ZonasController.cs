using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inventario.Data;
using Inventario.Data.Entities;

namespace Inventario.Controllers
{
    public class ZonasController : Controller
    {
        private readonly DataContext _context;

        public ZonasController(DataContext context)
        {
            _context = context;
        }

        // GET: Zonas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zonas.ToListAsync());
        }

        // GET: Zonas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonas = await _context.Zonas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zonas == null)
            {
                return NotFound();
            }

            return View(zonas);
        }

        // GET: Zonas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zonas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreZona,Asg,FechaActualización")] Zonas zonas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zonas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zonas);
        }

        // GET: Zonas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonas = await _context.Zonas.FindAsync(id);
            if (zonas == null)
            {
                return NotFound();
            }
            return View(zonas);
        }

        // POST: Zonas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreZona,Asg,FechaActualización")] Zonas zonas)
        {
            if (id != zonas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zonas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZonasExists(zonas.Id))
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
            return View(zonas);
        }

        // GET: Zonas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonas = await _context.Zonas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zonas == null)
            {
                return NotFound();
            }

            return View(zonas);
        }

        // POST: Zonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zonas = await _context.Zonas.FindAsync(id);
            _context.Zonas.Remove(zonas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZonasExists(int id)
        {
            return _context.Zonas.Any(e => e.Id == id);
        }
    }
}
