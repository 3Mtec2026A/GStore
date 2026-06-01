using GStore.API.Data.Seeds;
using GStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GStore.API.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Configuração do Identity
        builder.Entity<Usuario>().ToTable("usuarios");
        builder.Entity<IdentityRole>().ToTable("perfis");
        builder.Entity<IdentityUserRole<string>>().ToTable("usuario_perfis");
        builder.Entity<IdentityUserToken<string>>().ToTable("usuario_tokens");
        builder.Entity<IdentityUserLogin<string>>().ToTable("usuario_logins");
        builder.Entity<IdentityUserClaim<string>>().ToTable("usuario_regras");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("perfil_regras");
        #endregion

        #region Mock de dados
        SeedCategoria seedCategoria = new(builder);
        SeedProduto seedProduto = new(builder);
        SeedUsuario seedUsuario = new (builder);
        #endregion

    }

}
