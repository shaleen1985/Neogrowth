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
    public class CommunicationLogsController : ControllerBase
    {
        private readonly NeoGrowthContext _context;

        public CommunicationLogsController(NeoGrowthContext context)
        {
            _context = context;
        }

        // GET: api/CommunicationLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommunicationLog>>> GetCommunicationLogs()
        {
            return await _context.CommunicationLogs.ToListAsync();
        }

        // GET: api/CommunicationLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommunicationLog>> GetCommunicationLog(int id)
        {
            var communicationLog = await _context.CommunicationLogs.FindAsync(id);

            if (communicationLog == null)
            {
                return NotFound();
            }

            return communicationLog;
        }

        // PUT: api/CommunicationLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommunicationLog(int id, CommunicationLog communicationLog)
        {
            if (id != communicationLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(communicationLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunicationLogExists(id))
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

        // POST: api/CommunicationLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommunicationLog>> PostCommunicationLog(CommunicationLog communicationLog)
        {
            _context.CommunicationLogs.Add(communicationLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommunicationLog", new { id = communicationLog.Id }, communicationLog);
        }

        // DELETE: api/CommunicationLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunicationLog(int id)
        {
            var communicationLog = await _context.CommunicationLogs.FindAsync(id);
            if (communicationLog == null)
            {
                return NotFound();
            }

            _context.CommunicationLogs.Remove(communicationLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommunicationLogExists(int id)
        {
            return _context.CommunicationLogs.Any(e => e.Id == id);
        }
    }
}
