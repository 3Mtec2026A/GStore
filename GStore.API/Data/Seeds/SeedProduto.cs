using GStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GStore.API.Data.Seeds;

public class SeedProduto
{
    public SeedProduto(ModelBuilder builder)
    {
        List<Produto> produtos = [
            // Smartphones
            new() {
                Id = 1,
                CategoriaId = 1,
                Nome = "",
                Descricao = @"",
                ValorCusto = 10.0m,
                ValorVenda = 0,
                Qtde = 0,
                Destaque = true,
                Foto = "/img/produtos/1.png"
            }
        ];
        builder.Entity<Produto>().HasData(produtos);
    }
}
