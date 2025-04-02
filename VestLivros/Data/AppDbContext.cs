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
    public DbSet<LivroVestibular> LivroVestibulares { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        AppDbSeed seed = new(builder);

        #region Definindo nomes do Identity
        builder.Entity<IdentityUser>().ToTable("usuario");
        builder.Entity<IdentityRole>().ToTable("perfil");
        builder.Entity<IdentityUserRole<string>>().ToTable("usuario_perfil");
        builder.Entity<IdentityUserClaim<string>>().ToTable("usuario_regra");
        builder.Entity<IdentityUserLogin<string>>().ToTable("usuario_login");
        builder.Entity<IdentityUserToken<string>>().ToTable("usuario_token");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("perfil_regra");
        #endregion
    }
    
}
