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
            ViewBag.Faculdades = new SelectList(_context.Faculdades, "Id", "FaculdadeNome");
            ViewBag.Anos = new MultiSelectList(_context.Vestibulares.OrderBy(v => v.Ano), "Id", "Ano");
            return View();
        }

        // POST: Livros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Livro livro, IFormFile? arquivo, IFormFile? pdf, int[] anosSelecionados)
        {
            if (ModelState.IsValid)
            {
                // Upload de imagem
                if (arquivo != null && arquivo.Length > 0)
                {
                    string pasta = Path.Combine(_host.WebRootPath, "uploads", "livros");
                    if (!Directory.Exists(pasta))
                        Directory.CreateDirectory(pasta);

                    string nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(arquivo.FileName);
                    string caminhoArquivo = Path.Combine(pasta, nomeArquivo);

                    using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                        await arquivo.CopyToAsync(stream);

                    livro.ArquivoFoto = $"/uploads/livros/{nomeArquivo}";
                }

                // Upload do PDF
                if (pdf != null && pdf.Length > 0)
                {
                    string pastaPdf = Path.Combine(_host.WebRootPath, "uploads", "pdf");
                    if (!Directory.Exists(pastaPdf))
                        Directory.CreateDirectory(pastaPdf);

                    string nomePdf = Guid.NewGuid().ToString() + Path.GetExtension(pdf.FileName);
                    string caminhoPdf = Path.Combine(pastaPdf, nomePdf);

                    using (var stream = new FileStream(caminhoPdf, FileMode.Create))
                        await pdf.CopyToAsync(stream);

                    livro.PDF = $"/uploads/pdf/{nomePdf}";
                }

                _context.Livros.Add(livro);
                await _context.SaveChangesAsync();

                // Relacionar os anos
                if (anosSelecionados != null && anosSelecionados.Length > 0)
                {
                    foreach (var anoId in anosSelecionados)
                    {
                        _context.LivroVestibulares.Add(new LivroVestibular
                        {
                            LivroId = livro.Id,
                            VestibularId = anoId,
                            FaculdadeId = livro.FaculdadeId.Value
                        });
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Faculdades = new SelectList(_context.Faculdades, "Id", "FaculdadeNome", livro.FaculdadeId);
            ViewBag.Anos = new MultiSelectList(_context.Vestibulares.OrderBy(v => v.Ano), "Id", "Ano");
            return View(livro);
        }


        // GET: Livros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var livro = await _context.Livros
                .Include(l => l.Vestibulares)
                .ThenInclude(lv => lv.Vestibular)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (livro == null)
                return NotFound();

            ViewBag.Faculdades = new SelectList(_context.Faculdades, "Id", "FaculdadeNome", livro.FaculdadeId);

            var anosSelecionados = livro.Vestibulares.Select(v => v.VestibularId).ToArray();
            ViewBag.Anos = new MultiSelectList(_context.Vestibulares.OrderBy(v => v.Ano), "Id", "Ano", anosSelecionados);

            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Livro livro, IFormFile? novaImagem, IFormFile? novoPdf, int[] anosSelecionados)
        {
            if (id != livro.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var livroExistente = await _context.Livros
                        .Include(l => l.Vestibulares)
                        .FirstOrDefaultAsync(l => l.Id == id);

                    if (livroExistente == null)
                        return NotFound();

                    // Guarda valores antigos antes de sobrescrever
                    var pdfAntigo = livroExistente.PDF;
                    var fotoAntiga = livroExistente.ArquivoFoto;

                    // Atualiza campos básicos
                    _context.Entry(livroExistente).CurrentValues.SetValues(livro);

                    // Restaura PDF e imagem se o form não enviou novos arquivos
                    livroExistente.PDF = pdfAntigo;
                    livroExistente.ArquivoFoto = fotoAntiga;

                    // ======== IMAGEM ========
                    if (novaImagem != null && novaImagem.Length > 0)
                    {
                        string pasta = Path.Combine(_host.WebRootPath, "uploads", "livros");
                        if (!Directory.Exists(pasta))
                            Directory.CreateDirectory(pasta);

                        string nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(novaImagem.FileName);
                        string caminhoArquivo = Path.Combine(pasta, nomeArquivo);

                        using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                            await novaImagem.CopyToAsync(stream);

                        livroExistente.ArquivoFoto = $"/uploads/livros/{nomeArquivo}";
                    }

                    // ======== PDF ========
                    if (novoPdf != null && novoPdf.Length > 0)
                    {
                        string pastaPdf = Path.Combine(_host.WebRootPath, "uploads", "pdf");
                        if (!Directory.Exists(pastaPdf))
                            Directory.CreateDirectory(pastaPdf);

                        string nomePdf = Guid.NewGuid().ToString() + Path.GetExtension(novoPdf.FileName);
                        string caminhoPdf = Path.Combine(pastaPdf, nomePdf);

                        using (var stream = new FileStream(caminhoPdf, FileMode.Create))
                            await novoPdf.CopyToAsync(stream);

                        livroExistente.PDF = $"/uploads/pdf/{nomePdf}";
                    }

                    // ======== MANTÉM SE NÃO TROCAR ========
                    if (novaImagem == null)
                        _context.Entry(livroExistente).Property(l => l.ArquivoFoto).IsModified = false;

                    if (novoPdf == null)
                        _context.Entry(livroExistente).Property(l => l.PDF).IsModified = false;

                    // ======== ANOS ========
                    livroExistente.Vestibulares.Clear();
                    if (anosSelecionados != null && anosSelecionados.Length > 0)
                    {
                        foreach (var anoId in anosSelecionados)
                        {
                            livroExistente.Vestibulares.Add(new LivroVestibular
                            {
                                LivroId = livroExistente.Id,
                                VestibularId = anoId,
                                FaculdadeId = livro.FaculdadeId.Value
                            });
                        }
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Livros.Any(e => e.Id == livro.Id))
                        return NotFound();
                    else
                        throw;
                }
            }

            // ======== SE DER ERRO, RECARREGA TUDO ========
            ViewBag.Faculdades = new SelectList(_context.Faculdades, "Id", "FaculdadeNome", livro.FaculdadeId);
            ViewBag.Anos = new MultiSelectList(_context.Vestibulares.OrderBy(v => v.Ano), "Id", "Ano", anosSelecionados);

            var livroAtual = await _context.Livros.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
            if (livroAtual != null)
            {
                livro.ArquivoFoto = livroAtual.ArquivoFoto;
                livro.PDF = livroAtual.PDF;
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
