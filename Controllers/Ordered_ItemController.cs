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
    public class Ordered_ItemController : ControllerBase
    {
        private readonly LiqourDbContex _context;

        public Ordered_ItemController(LiqourDbContex context)
        {
            _context = context;
        }

        // GET: api/Ordered_Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordered_Item>>> GetOrderedItems()
        {
            return await _context.OrderedItems.ToListAsync();
        }

        // GET: api/Ordered_Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ordered_Item>> GetOrdered_Item(int id)
        {
            var ordered_Item = await _context.OrderedItems.FindAsync(id);

            if (ordered_Item == null)
            {
                return NotFound();
            }

            return ordered_Item;
        }

        // PUT: api/Ordered_Item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdered_Item(int id, Ordered_Item ordered_Item)
        {
            if (id != ordered_Item.Id)
            {
                return BadRequest();
            }

            _context.Entry(ordered_Item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ordered_ItemExists(id))
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

        // POST: api/Ordered_Item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ordered_Item>> PostOrdered_Item(Ordered_Item ordered_Item)
        {
            _context.OrderedItems.Add(ordered_Item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdered_Item", new { id = ordered_Item.Id }, ordered_Item);
        }

        // DELETE: api/Ordered_Item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdered_Item(int id)
        {
            var ordered_Item = await _context.OrderedItems.FindAsync(id);
            if (ordered_Item == null)
            {
                return NotFound();
            }

            _context.OrderedItems.Remove(ordered_Item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Ordered_ItemExists(int id)
        {
            return _context.OrderedItems.Any(e => e.Id == id);
        }
    }
}
