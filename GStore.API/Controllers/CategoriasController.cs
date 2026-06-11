using GStore.API.Data;
using GStore.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriasController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> GetCategorias()
    {
        return Ok(_context.Categorias.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<Categoria> GetCategoria(int id)
    {
        var categoria = _context.Categorias.Find(id);
        return categoria == null ? NotFound("Categoria não localizada") : Ok(categoria);
    }

}
