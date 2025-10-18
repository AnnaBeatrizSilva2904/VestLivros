using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VestLivros.Data;
using VestLivros.Models;

namespace VestLivros.Controllers
{
    public class LivrosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _host;

        public LivrosController(AppDbContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }

        // GET: Livros
        public async Task<IActionResult> Index()
        {
            var livros = await _context.Livros
                .Include(l => l.Faculdade)
                .ToListAsync();

            return View(livros);
        }

        // GET: Livros/Details/5
        public async Task<IActionResult> Livro(int id)
        {
            var livro = await _context.Livros
                .Include(l => l.Faculdade)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (livro == null)
                return NotFound();

            return View(livro);
        }

        // GET: Livros/Create
        public IActionResult Create()
        {
            ViewBag.Faculdades = new SelectList(
                _context.Faculdades.ToList(),
                "Id",
                "FaculdadeNome"
            );

            return View();
        }

        // POST: Livros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Livro livro, IFormFile? arquivo)
        {
            if (ModelState.IsValid)
            {
                if (arquivo != null && arquivo.Length > 0)
                {
                    string pasta = Path.Combine(_host.WebRootPath, "uploads", "livros");
                    if (!Directory.Exists(pasta))
                        Directory.CreateDirectory(pasta);

                    string nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(arquivo.FileName);
                    string caminhoArquivo = Path.Combine(pasta, nomeArquivo);

                    using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                    {
                        await arquivo.CopyToAsync(stream);
                    }

                    livro.ArquivoFoto = $"/uploads/livros/{nomeArquivo}";
                }

                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Faculdades = new SelectList(_context.Faculdades.ToList(), "Id", "FaculdadeNome", livro.FaculdadeId);
            return View(livro);
        }

        // GET: Livros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
                return NotFound();

            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Livro livro, IFormFile? novaImagem)
        {
            if (id != livro.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var livroExistente = await _context.Livros.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
                    if (livroExistente == null)
                        return NotFound();

                    // Se o admin enviou uma nova imagem
                    if (novaImagem != null && novaImagem.Length > 0)
                    {
                        // Apagar a imagem anterior se existir
                        if (!string.IsNullOrEmpty(livroExistente.ArquivoFoto))
                        {
                            var caminhoAntigo = Path.Combine(_host.WebRootPath, livroExistente.ArquivoFoto.TrimStart('/'));
                            if (System.IO.File.Exists(caminhoAntigo))
                                System.IO.File.Delete(caminhoAntigo);
                        }

                        // Criar pasta se não existir
                        string pasta = Path.Combine(_host.WebRootPath, "uploads", "livros");
                        if (!Directory.Exists(pasta))
                            Directory.CreateDirectory(pasta);

                        // Salvar nova imagem
                        string nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(novaImagem.FileName);
                        string caminhoArquivo = Path.Combine(pasta, nomeArquivo);

                        using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                        {
                            await novaImagem.CopyToAsync(stream);
                        }

                        livro.ArquivoFoto = $"/uploads/livros/{nomeArquivo}";
                    }
                    else
                    {
                        // Nenhuma nova imagem -> mantém a antiga
                        livro.ArquivoFoto = livroExistente.ArquivoFoto;
                    }

                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Livros.Any(e => e.Id == livro.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(livro);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .Include(l => l.Faculdade)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }


        // DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var livro = await _context.Livros
                .Include(l => l.Faculdade)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (livro == null)
                return NotFound();

            return View(livro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro != null)
                _context.Livros.Remove(livro);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
