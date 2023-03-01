﻿using System;
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
    public class Order_DetailsController : ControllerBase
    {
        private readonly LiqourDbContex _context;

        public Order_DetailsController(LiqourDbContex context)
        {
            _context = context;
        }

        // GET: api/Order_Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order_Details>>> GetOrderDetails()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        // GET: api/Order_Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order_Details>> GetOrder_Details(int id)
        {
            var order_Details = await _context.OrderDetails.FindAsync(id);

            if (order_Details == null)
            {
                return NotFound();
            }

            return order_Details;
        }

        // PUT: api/Order_Details/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder_Details(int id, Order_Details order_Details)
        {
            if (id != order_Details.Id)
            {
                return BadRequest();
            }

            _context.Entry(order_Details).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order_DetailsExists(id))
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

        // POST: api/Order_Details
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order_Details>> PostOrder_Details(Order_Details order_Details)
        {
            _context.OrderDetails.Add(order_Details);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder_Details", new { id = order_Details.Id }, order_Details);
        }

        // DELETE: api/Order_Details/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder_Details(int id)
        {
            var order_Details = await _context.OrderDetails.FindAsync(id);
            if (order_Details == null)
            {
                return NotFound();
            }

            _context.OrderDetails.Remove(order_Details);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Order_DetailsExists(int id)
        {
            return _context.OrderDetails.Any(e => e.Id == id);
        }
    }
}
