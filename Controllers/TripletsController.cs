using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using disneyworld.Models;

namespace disneyworld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripletsController : ControllerBase
    {
        private readonly GeneralContext _context;

        public TripletsController(GeneralContext context)
        {
            _context = context;
        }

        // GET: api/Triplets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Triplet>>> GetTriplets()
        {
            return await _context.Triplets.ToListAsync();
        }

        // GET: api/Triplets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Triplet>> GetTriplet(int id)
        {
            var triplet = await _context.Triplets.FindAsync(id);

            if (triplet == null)
            {
                return NotFound();
            }

            return triplet;
        }

        // PUT: api/Triplets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTriplet(int id, Triplet triplet)
        {
            if (id != triplet.Id)
            {
                return BadRequest();
            }

            _context.Entry(triplet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripletExists(id))
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

        // POST: api/Triplets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Triplet>> PostTriplet(Triplet triplet)
        {
            _context.Triplets.Add(triplet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TripletExists(triplet.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTriplet", new { id = triplet.Id }, triplet);
        }

        // DELETE: api/Triplets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTriplet(int id)
        {
            var triplet = await _context.Triplets.FindAsync(id);
            if (triplet == null)
            {
                return NotFound();
            }

            _context.Triplets.Remove(triplet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TripletExists(int id)
        {
            return _context.Triplets.Any(e => e.Id == id);
        }
    }
}
