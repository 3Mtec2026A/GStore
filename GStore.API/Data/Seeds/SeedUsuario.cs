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
        #endregion

        #region Usuário Perfil
        #endregion
    }
}
