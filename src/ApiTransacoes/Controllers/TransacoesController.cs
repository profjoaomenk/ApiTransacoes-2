using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTransacoes.Data;
using ApiTransacoes.Models;

namespace ApiTransacoes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransacoesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Transacoes.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tx = await _context.Transacoes.FindAsync(id);
            return tx == null ? NotFound() : Ok(tx);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Transacao tx)
        {
            _context.Transacoes.Add(tx);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = tx.Id }, tx);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Transacao txUpdate)
        {
            if (id != txUpdate.Id) return BadRequest();
            _context.Entry(txUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tx = await _context.Transacoes.FindAsync(id);
            if (tx == null) return NotFound();
            _context.Transacoes.Remove(tx);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
