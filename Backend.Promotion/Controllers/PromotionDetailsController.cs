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
    public class PromotionDetailsController : ControllerBase
    {
        private readonly PromotionContext _context;

        public PromotionDetailsController(PromotionContext context)
        {
            _context = context;
        }

        // GET: api/PromotionDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromotionDetail>>> GetPromotionDetails()
        {
            return await _context.PromotionDetails.ToListAsync();
        }

        // GET: api/PromotionDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionDetail>> GetPromotionDetail(Guid id)
        {
            var promotionDetail = await _context.PromotionDetails.FindAsync(id);

            if (promotionDetail == null)
            {
                return NotFound();
            }

            return promotionDetail;
        }

        // PUT: api/PromotionDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromotionDetail(Guid id, PromotionDetail promotionDetail)
        {
            if (id != promotionDetail.PromotionDetailId)
            {
                return BadRequest();
            }

            _context.Entry(promotionDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionDetailExists(id))
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

        // POST: api/PromotionDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PromotionDetail>> PostPromotionDetail(PromotionDetail promotionDetail)
        {
            _context.PromotionDetails.Add(promotionDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PromotionDetailExists(promotionDetail.PromotionDetailId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPromotionDetail", new { id = promotionDetail.PromotionDetailId }, promotionDetail);
        }

        // DELETE: api/PromotionDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromotionDetail(Guid id)
        {
            var promotionDetail = await _context.PromotionDetails.FindAsync(id);
            if (promotionDetail == null)
            {
                return NotFound();
            }

            _context.PromotionDetails.Remove(promotionDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PromotionDetailExists(Guid id)
        {
            return _context.PromotionDetails.Any(e => e.PromotionDetailId == id);
        }
    }
}
