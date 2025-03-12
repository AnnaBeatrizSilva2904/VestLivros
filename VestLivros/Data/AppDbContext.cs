using VestLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace VestLivros.Data;

public class AppDbContext
{
    public DbSet<LivroFoto> LivrosFotos { get; set; }
    public DbSet<Livro> Livros { get; set; }
    public int Anos { get; set; }
    public string Faculdades { get; set; }
    public string NomeLivros { get; set; }
}
