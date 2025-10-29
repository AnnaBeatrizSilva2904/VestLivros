using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VestLivros.Data;
using VestLivros.Models;

namespace VestLivros.Controllers;

public class FaculdadesController : Controller
{
    private readonly AppDbContext _context;

    public FaculdadesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Faculdades
    public async Task<IActionResult> Index()
    {
        var faculdades = await _context.Faculdades.ToListAsync();
        return View(faculdades);
    }

    // GET: Faculdades/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Faculdades/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Faculdade faculdade)
    {
        if (ModelState.IsValid)
        {
            _context.Add(faculdade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(faculdade);
    }

    // GET: Faculdades/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var faculdade = await _context.Faculdades.FindAsync(id);
        if (faculdade == null)
            return NotFound();

        return View(faculdade);
    }

    // POST: Faculdades/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Faculdade faculdade)
    {
        if (id != faculdade.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(faculdade);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaculdadeExists(faculdade.Id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(faculdade);
    }

    // GET: Faculdades/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var faculdade = await _context.Faculdades
            .FirstOrDefaultAsync(m => m.Id == id);
        if (faculdade == null)
            return NotFound();

        return View(faculdade);
    }

    // POST: Faculdades/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var faculdade = await _context.Faculdades.FindAsync(id);
        if (faculdade != null)
        {
            _context.Faculdades.Remove(faculdade);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private bool FaculdadeExists(int id)
    {
        return _context.Faculdades.Any(e => e.Id == id);
    }
}

