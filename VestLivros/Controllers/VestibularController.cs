using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VestLivros.Data;
using VestLivros.Models;

namespace VestLivros.Controllers;

public class VestibularController : Controller
{
    private readonly AppDbContext _context;

    public VestibularController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Vestibular
    public async Task<IActionResult> Index()
    {
        var anos = await _context.Vestibulares.OrderBy(v => v.Ano).ToListAsync();
        return View(anos);
    }

    // GET: Vestibular/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Vestibular/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Ano")] Vestibular vestibular)
    {
        if (ModelState.IsValid)
        {
            _context.Add(vestibular);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(vestibular);
    }

    // GET: Vestibular/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var vestibular = await _context.Vestibulares.FindAsync(id);
        if (vestibular == null) return NotFound();

        return View(vestibular);
    }

    // POST: Vestibular/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Ano")] Vestibular vestibular)
    {
        if (id != vestibular.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(vestibular);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Vestibulares.Any(e => e.Id == vestibular.Id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(vestibular);
    }

    // GET: Vestibular/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var vestibular = await _context.Vestibulares
            .FirstOrDefaultAsync(m => m.Id == id);
        if (vestibular == null) return NotFound();

        return View(vestibular);
    }

    // POST: Vestibular/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var vestibular = await _context.Vestibulares.FindAsync(id);
        _context.Vestibulares.Remove(vestibular);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}