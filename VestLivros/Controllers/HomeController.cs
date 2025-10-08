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

    public HomeController(ILogger<HomeController> logger, AppDbContext db)
    {
        _db = db;
        _logger = logger;
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

    public IActionResult Livro(int id)
    {
        Livro livro = _db.Livros
            .Where(l => l.Id == id)
            .SingleOrDefault();
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

