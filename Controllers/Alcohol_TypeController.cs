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
    public class Alcohol_TypeController : ControllerBase
    {
        private readonly LiqourDbContex _context;

        public Alcohol_TypeController(LiqourDbContex context)
        {
            _context = context;
        }

        // GET: api/Alcohol_Type
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alcohol_Type>>> GetAlcoholTypes()
        {
            return await _context.AlcoholTypes.ToListAsync();
        }

        // GET: api/Alcohol_Type/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alcohol_Type>> GetAlcohol_Type(int id)
        {
            var alcohol_Type = await _context.AlcoholTypes.FindAsync(id);

            if (alcohol_Type == null)
            {
                return NotFound();
            }

            return alcohol_Type;
        }

        // PUT: api/Alcohol_Type/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlcohol_Type(int id, Alcohol_Type alcohol_Type)
        {
            if (id != alcohol_Type.Id)
            {
                return BadRequest();
            }

            _context.Entry(alcohol_Type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Alcohol_TypeExists(id))
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

        // POST: api/Alcohol_Type
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alcohol_Type>> PostAlcohol_Type(Alcohol_Type alcohol_Type)
        {
            _context.AlcoholTypes.Add(alcohol_Type);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlcohol_Type", new { id = alcohol_Type.Id }, alcohol_Type);
        }

        // DELETE: api/Alcohol_Type/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlcohol_Type(int id)
        {
            var alcohol_Type = await _context.AlcoholTypes.FindAsync(id);
            if (alcohol_Type == null)
            {
                return NotFound();
            }

            _context.AlcoholTypes.Remove(alcohol_Type);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Alcohol_TypeExists(int id)
        {
            return _context.AlcoholTypes.Any(e => e.Id == id);
        }
    }
}
