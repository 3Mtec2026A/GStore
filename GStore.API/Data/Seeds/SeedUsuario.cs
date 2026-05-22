using GStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GStore.API.Data.Seeds;

public class SeedUsuario
{
    public SeedUsuario(ModelBuilder builder)
    {
        #region Perfil
        List<IdentityRole> perfis = [
            new() {
                Id = "0e854410-eea9-4a73-a94c-290503d8f2c1",
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },
            new() {
                Id = "e1fc6baa-ca55-4bb4-993c-fa5cd578c6aa",
                Name = "Cliente",
                NormalizedName = "CLIENTE"
            },
        ];
        builder.Entity<IdentityRole>().HasData(perfis);
        #endregion

        #region Usuários
        List<Usuario> usuarios = [
            new Usuario() {
                Id = "e1fc6baa-ca55-4bb4-993c-fa5cd578c6aa",
                Email = "admin@gstore.com",
                NormalizedEmail = "ADMIN@GSTORE.COM",
                UserName = "admin@gstore.com",
                NormalizedUserName = "ADMIN@GSTORE.COM",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "Administrador",
                DataNascimento = DateTime.Parse("05/08/1981"),
                Foto = "/img/usuarios/e1fc6baa-ca55-4bb4-993c-fa5cd578c6aa.png"
            },
        ];
        foreach (var usuario in usuarios)
        {
            PasswordHasher<Usuario> passwordHasher = new();
            usuario.PasswordHash = passwordHasher.HashPassword(usuario, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Usuário Perfil
        List<IdentityUserRole<string>> userRoles = [
            new () {
                UserId = usuarios[0].Id,
                RoleId = perfis[0].Id
            }
        ];
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }
}
