using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeoGrowth.Entity;

namespace NeoGrowth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadInformationsController : ControllerBase
    {
        private readonly NeoGrowthContext _context;

        public LeadInformationsController(NeoGrowthContext context)
        {
            _context = context;
        }

        // GET: api/LeadInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeadInformation>>> GetLeadInformations()
        {
            return await _context.LeadInformations.ToListAsync();
        }

        // GET: api/LeadInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeadInformation>> GetLeadInformation(int id)
        {
            var leadInformation = await _context.LeadInformations.FindAsync(id);

            if (leadInformation == null)
            {
                return NotFound();
            }

            return leadInformation;
        }

        // PUT: api/LeadInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeadInformation(int id, LeadInformation leadInformation)
        {
            if (id != leadInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(leadInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadInformationExists(id))
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

        // POST: api/LeadInformations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LeadInformation>> PostLeadInformation(LeadInformation leadInformation)
        {
            _context.LeadInformations.Add(leadInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeadInformation", new { id = leadInformation.Id }, leadInformation);
        }

        // DELETE: api/LeadInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeadInformation(int id)
        {
            var leadInformation = await _context.LeadInformations.FindAsync(id);
            if (leadInformation == null)
            {
                return NotFound();
            }

            _context.LeadInformations.Remove(leadInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeadInformationExists(int id)
        {
            return _context.LeadInformations.Any(e => e.Id == id);
        }
    }
}
