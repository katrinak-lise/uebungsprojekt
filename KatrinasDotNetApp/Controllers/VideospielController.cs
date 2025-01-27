using KatrinasDotNetApp.Services;
using KatrinasDotNetApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace KatrinasDotNetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideospielController : ControllerBase
    {
        private readonly VideospieleService _videospieleService;

        public VideospielController(VideospieleService videospieleService)
        {
            _videospieleService = videospieleService;
        }

        // GET: api/Videospiel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Videospiel>>> GetVideospiel()
        {
            return await _videospieleService.GetAsync();
        }

        // GET: api/Videospiel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Videospiel>> GetVideospiel(ObjectId id)
        {
            var videospiel = await _videospieleService.GetAsync(id);

            if (videospiel == null)
            {
                return NotFound();
            }

            return videospiel;
        }

        // PUT: api/Videospiel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideospiel(ObjectId id, Videospiel videospiel)
        {
            if (id != videospiel.Id)
            {
                return BadRequest();
            }
            
            try
            {
                await _videospieleService.UpdateAsync(id, videospiel);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Videospiel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Videospiel>> PostVideospiel(Videospiel neuesVideospiel)
        {
            await _videospieleService.CreateAsync(neuesVideospiel);

            return CreatedAtAction("GetVideospiel", new { id = neuesVideospiel.Id }, neuesVideospiel);
        }

        // DELETE: api/Videospiel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideospiel(ObjectId id)
        {
            var videospiel = await _videospieleService.GetAsync(id);
            if (videospiel == null)
            {
                return NotFound();
            }
            
            await _videospieleService.RemoveAsync(id);

            return NoContent();
        }
    }
}
