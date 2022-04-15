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
    public class ValueTypesController : ControllerBase
    {
        private readonly PromotionContext _context;

        public ValueTypesController(PromotionContext context)
        {
            _context = context;
        }

        // GET: api/ValueTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.ValueType>>> GetValueTypes()
        {
            return await _context.ValueTypes.ToListAsync();
        }

        // GET: api/ValueTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.ValueType>> GetValueType(Guid id)
        {
            var valueType = await _context.ValueTypes.FindAsync(id);

            if (valueType == null)
            {
                return NotFound();
            }

            return valueType;
        }

        // PUT: api/ValueTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValueType(Guid id, Models.ValueType valueType)
        {
            if (id != valueType.ValueTypeId)
            {
                return BadRequest();
            }

            _context.Entry(valueType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValueTypeExists(id))
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

        // POST: api/ValueTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.ValueType>> PostValueType(Models.ValueType valueType)
        {
            _context.ValueTypes.Add(valueType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ValueTypeExists(valueType.ValueTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetValueType", new { id = valueType.ValueTypeId }, valueType);
        }

        // DELETE: api/ValueTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteValueType(Guid id)
        {
            var valueType = await _context.ValueTypes.FindAsync(id);
            if (valueType == null)
            {
                return NotFound();
            }

            _context.ValueTypes.Remove(valueType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ValueTypeExists(Guid id)
        {
            return _context.ValueTypes.Any(e => e.ValueTypeId == id);
        }
    }
}
