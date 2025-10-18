using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VestLivros.Models;
using VestLivros.Data;
using VestLivros.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace VestLivros.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _db;

    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext db)
    {
        _db = db;
        _logger = logger;
        _context = db;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarLivros(string termo)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(termo))
            {
                return Json(new { total = 0, resultados = new List<object>() });
            }

            var livros = await _context.Livros
                .Include(l => l.Vestibulares)
                    .ThenInclude(v => v.Vestibular)
                .Where(l => l.Nome.Contains(termo))
                .ToListAsync();

            var resultados = livros.Select(l => new
            {
                id = l.Id,
                nome = l.Nome,
                foto = l.ArquivoFoto,
                anos = l.Vestibulares
                    .Select(v => v.Vestibular?.Ano)
                    .Distinct()
                    .Where(a => a != null)
                    .ToList()
            }).ToList();

            return Json(new
            {
                total = resultados.Count,
                resultados
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao buscar livros: " + ex.Message);
            return Json(new { erro = ex.Message });
        }
    }

    public IActionResult Index()
    {
        ViewData["Anos"] = _db.Vestibulares.Select(v => v.Ano).ToList();

        List<Livro> livros =
            _db.Livros
            .Include(l => l.Vestibulares)
            .ThenInclude(v => v.Vestibular)
            .ToList();
        return View(livros);
    }

    public async Task<IActionResult> Livro(int id)
    {
        var livro = await _context.Livros
            .Include(l => l.Faculdade) // carrega a faculdade associada
            .FirstOrDefaultAsync(l => l.Id == id);

        if (livro == null)
            return NotFound();

        return View(livro);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

