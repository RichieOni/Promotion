#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Promotion.Data;
using Backend.Promotion.Models;

namespace Backend.Promotion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionHeadersController : ControllerBase
    {
        private readonly PromotionContext _context;

        public PromotionHeadersController(PromotionContext context)
        {
            _context = context;
        }

        // GET: api/PromotionHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromotionHeader>>> GetPromotionHeaders()
        {
            return await _context.PromotionHeaders.ToListAsync();
        }

        // GET: api/PromotionHeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionHeader>> GetPromotionHeader(string id)
        {
            var promotionHeader = await _context.PromotionHeaders.FindAsync(id);

            if (promotionHeader == null)
            {
                return NotFound();
            }

            return promotionHeader;
        }

        // PUT: api/PromotionHeaders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromotionHeader(string id, PromotionHeader promotionHeader)
        {
            if (id != promotionHeader.PromotionId)
            {
                return BadRequest();
            }

            _context.Entry(promotionHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionHeaderExists(id))
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

        // POST: api/PromotionHeaders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PromotionHeader>> PostPromotionHeader(PromotionHeader promotionHeader)
        {
            _context.PromotionHeaders.Add(promotionHeader);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PromotionHeaderExists(promotionHeader.PromotionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPromotionHeader", new { id = promotionHeader.PromotionId }, promotionHeader);
        }

        // DELETE: api/PromotionHeaders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromotionHeader(string id)
        {
            var promotionHeader = await _context.PromotionHeaders.FindAsync(id);
            if (promotionHeader == null)
            {
                return NotFound();
            }

            _context.PromotionHeaders.Remove(promotionHeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PromotionHeaderExists(string id)
        {
            return _context.PromotionHeaders.Any(e => e.PromotionId == id);
        }
    }
}
