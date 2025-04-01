using VestLivros.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VestLivros.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContextt(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Livro> Livros { get; set; }
    public DbSet<LivroFoto> LivroFotos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Faculdade> Faculdades { get; set; }
    public DbSet<Ano> Anos { get; set; }
    
}
