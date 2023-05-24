using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosComida.Modelos;

namespace PedidosComida.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoComidasController : ControllerBase
    {
        private readonly DataContext _context;

        public PedidoComidasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PedidoComidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoComida>>> GetPedidoComida()
        {
          if (_context.PedidoComidas == null)
          {
              return NotFound();
          }
            return await _context.PedidoComidas.ToListAsync();
        }

        // GET: api/PedidoComidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoComida>> GetPedidoComida(int id)
        {
          if (_context.PedidoComidas == null)
          {
              return NotFound();
          }
            var pedidoComida = await _context.PedidoComidas.Include(p => p.Cliente).FirstAsync(p => p.Id ==id);

            if (pedidoComida == null)
            {
                return NotFound();
            }

            return pedidoComida;
        }

        // PUT: api/PedidoComidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoComida(int id, PedidoComida pedidoComida)
        {
            if (id != pedidoComida.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedidoComida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoComidaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PedidoComidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PedidoComida>> PostPedidoComida(PedidoComida pedidoComida)
        {
          if (_context.PedidoComidas == null)
          {
              return Problem("Entity set 'DataContext.PedidoComida'  is null.");
          }
            _context.PedidoComidas.Add(pedidoComida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidoComida", new { id = pedidoComida.Id }, pedidoComida);
        }

        // DELETE: api/PedidoComidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoComida(int id)
        {
            if (_context.PedidoComidas == null)
            {
                return NotFound();
            }
            var pedidoComida = await _context.PedidoComidas.FindAsync(id);
            if (pedidoComida == null)
            {
                return NotFound();
            }

            _context.PedidoComidas.Remove(pedidoComida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoComidaExists(int id)
        {
            return (_context.PedidoComidas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
