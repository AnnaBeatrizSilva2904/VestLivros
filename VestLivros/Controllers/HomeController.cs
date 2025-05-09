using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VestLivros.Models;

namespace VestLivros.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, AppDbContext db)
    {
        _db = db;
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Livro> livros = _db.Livros
            .Where (l => l.nome)
            .Include (l =>)
        return View();
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
