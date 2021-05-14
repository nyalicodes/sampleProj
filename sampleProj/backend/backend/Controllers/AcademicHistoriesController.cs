using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Domain;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicHistoriesController : ControllerBase
    {
        private readonly SampleProjContext _context;

        public AcademicHistoriesController(SampleProjContext context)
        {
            _context = context;
        }

        // GET: api/AcademicHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicHistory>>> GetHistory()
        {
            return await _context.History.ToListAsync();
        }

        // GET: api/AcademicHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicHistory>> GetAcademicHistory(Guid id)
        {
            var academicHistory = await _context.History.FindAsync(id);

            if (academicHistory == null)
            {
                return NotFound();
            }

            return academicHistory;
        }

        // PUT: api/AcademicHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicHistory(Guid id, AcademicHistory academicHistory)
        {
            if (id != academicHistory.AcademicHistoryId)
            {
                return BadRequest();
            }

            _context.Entry(academicHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicHistoryExists(id))
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

        // POST: api/AcademicHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AcademicHistory>> PostAcademicHistory(AcademicHistory academicHistory)
        {
            _context.History.Add(academicHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcademicHistory", new { id = academicHistory.AcademicHistoryId }, academicHistory);
        }

        // DELETE: api/AcademicHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicHistory(Guid id)
        {
            var academicHistory = await _context.History.FindAsync(id);
            if (academicHistory == null)
            {
                return NotFound();
            }

            _context.History.Remove(academicHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcademicHistoryExists(Guid id)
        {
            return _context.History.Any(e => e.AcademicHistoryId == id);
        }
    }
}
