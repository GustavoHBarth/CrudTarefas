using CrudTarefas.Data;
using CrudTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class TarefaController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TarefaController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/tarefa
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas()
    {
        return await _context.Tarefas.ToListAsync();
    }

    // GET: api/tarefa/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Tarefa>> GetTarefa(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);
        if (tarefa == null)
        {
            return NotFound();
        }
        return tarefa;
    }

    // POST: api/tarefa
    [HttpPost]
    public async Task<ActionResult<Tarefa>> PostTarefa(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetTarefa", new { id = tarefa.Id }, tarefa);
    }

    // PUT: api/tarefa/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTarefa(int id, Tarefa tarefa)
    {
        if (id != tarefa.Id)
        {
            return BadRequest();
        }
        _context.Entry(tarefa).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/tarefa/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTarefa(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);
        if (tarefa == null)
        {
            return NotFound();
        }
        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
