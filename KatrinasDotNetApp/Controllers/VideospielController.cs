using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KatrinasDotNetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideospielController : ControllerBase
    {
        private readonly VideospielContext _context;

        public VideospielController(VideospielContext context)
        {
            _context = context;
        }

        // GET: api/Videospiel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Videospiel>>> GetVideospiel()
        {
            return await _context.Videospiel.ToListAsync();
        }

        // GET: api/Videospiel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Videospiel>> GetVideospiel(int id)
        {
            var videospiel = await _context.Videospiel.FindAsync(id);

            if (videospiel == null)
            {
                return NotFound();
            }

            return videospiel;
        }

        // PUT: api/Videospiel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideospiel(int id, Videospiel videospiel)
        {
            if (id != videospiel.Id)
            {
                return BadRequest();
            }

            _context.Entry(videospiel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideospielExists(id))
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

        // POST: api/Videospiel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Videospiel>> PostVideospiel(Videospiel videospiel)
        {
            _context.Videospiel.Add(videospiel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideospiel", new { id = videospiel.Id }, videospiel);
        }

        // DELETE: api/Videospiel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideospiel(int id)
        {
            var videospiel = await _context.Videospiel.FindAsync(id);
            if (videospiel == null)
            {
                return NotFound();
            }

            _context.Videospiel.Remove(videospiel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideospielExists(int id)
        {
            return _context.Videospiel.Any(e => e.Id == id);
        }
    }
}
