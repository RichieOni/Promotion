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
    public class PromoTypesController : ControllerBase
    {
        private readonly PromotionContext _context;

        public PromoTypesController(PromotionContext context)
        {
            _context = context;
        }

        // GET: api/PromoTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromoType>>> GetPromoTypes()
        {
            return await _context.PromoTypes.ToListAsync();
        }

        // GET: api/PromoTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PromoType>> GetPromoType(Guid id)
        {
            var promoType = await _context.PromoTypes.FindAsync(id);

            if (promoType == null)
            {
                return NotFound();
            }

            return promoType;
        }

        // PUT: api/PromoTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromoType(Guid id, PromoType promoType)
        {
            if (id != promoType.PromoTypeId)
            {
                return BadRequest();
            }

            _context.Entry(promoType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromoTypeExists(id))
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

        // POST: api/PromoTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PromoType>> PostPromoType(PromoType promoType)
        {
            _context.PromoTypes.Add(promoType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PromoTypeExists(promoType.PromoTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPromoType", new { id = promoType.PromoTypeId }, promoType);
        }

        // DELETE: api/PromoTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromoType(Guid id)
        {
            var promoType = await _context.PromoTypes.FindAsync(id);
            if (promoType == null)
            {
                return NotFound();
            }

            _context.PromoTypes.Remove(promoType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PromoTypeExists(Guid id)
        {
            return _context.PromoTypes.Any(e => e.PromoTypeId == id);
        }
    }
}
