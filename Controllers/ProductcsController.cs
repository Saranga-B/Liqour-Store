using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LiqourStore.Data;
using LiqourStore.Model;

namespace LiqourStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductcsController : ControllerBase
    {
        private readonly LiqourDbContex _context;

        public ProductcsController(LiqourDbContex context)
        {
            _context = context;
        }

        // GET: api/Productcs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productcs>>> GetProductcs()
        {
            return await _context.Productcs.ToListAsync();
        }

        // GET: api/Productcs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Productcs>> GetProductcs(int id)
        {
            var productcs = await _context.Productcs.FindAsync(id);

            if (productcs == null)
            {
                return NotFound();
            }

            return productcs;
        }

        // PUT: api/Productcs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductcs(int id, Productcs productcs)
        {
            if (id != productcs.Id)
            {
                return BadRequest();
            }

            _context.Entry(productcs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductcsExists(id))
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

        // POST: api/Productcs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Productcs>> PostProductcs(Productcs productcs)
        {
            _context.Productcs.Add(productcs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductcs", new { id = productcs.Id }, productcs);
        }

        // DELETE: api/Productcs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductcs(int id)
        {
            var productcs = await _context.Productcs.FindAsync(id);
            if (productcs == null)
            {
                return NotFound();
            }

            _context.Productcs.Remove(productcs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductcsExists(int id)
        {
            return _context.Productcs.Any(e => e.Id == id);
        }
    }
}
