using GStore.API.Data;
using GStore.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpPost]
    public ActionResult<Categoria> PostCategoria([FromBody]Categoria categoria)
    {
        if (!ModelState.IsValid)
            return BadRequest("Confira os dados enviados!");
        
        _context.Categorias.Add(categoria);
        _context.SaveChanges();

        return CreatedAtAction("GetCategoria", new { id = categoria.Id}, categoria);
    }

    [HttpPut("{id}")]
    public ActionResult PutCategoria(int id, [FromBody]Categoria categoria)
    {
        if (id == categoria.Id || !ModelState.IsValid)
            return BadRequest("Confira os dados enviados");
        
        var oldCategoria = _context.Categorias.Find(id);
        if (oldCategoria == null) return NotFound("Categoria não localizada");

        oldCategoria.Nome = categoria.Nome;
        oldCategoria.Cor  = categoria.Cor ?? oldCategoria.Cor;
        oldCategoria.Foto = categoria.Foto ?? oldCategoria.Foto;

        _context.Entry(oldCategoria).State = EntityState.Modified;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCategoria(int id)
    {
        var categoria = _context.Categorias.Find(id);
        if (categoria == null)
            return NotFound("Categoria não localizada");
        
        _context.Categorias.Remove(categoria);
        _context.SaveChanges();

        return NoContent();
    }

}
