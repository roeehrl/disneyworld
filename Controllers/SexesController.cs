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
    public class SexesController : ControllerBase
    {
        private readonly GeneralContext _context;

        public SexesController(GeneralContext context)
        {
            _context = context;
        }

        // GET: api/Sexes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sex>>> GetSexes()
        {
            return await _context.Sexes.ToListAsync();
        }

        // GET: api/Sexes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sex>> GetSexes(int id)
        {
            var Sexes = await _context.Sexes.FindAsync(id);

            if (Sexes == null)
            {
                return NotFound();
            }

            return Sexes;
        }

        // PUT: api/Sexes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSexes(int id, Sex Sexes)
        {
            if (id != Sexes.Id)
            {
                return BadRequest();
            }

            _context.Entry(Sexes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SexesExists(id))
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

        // POST: api/Sexes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sex>> PostSexes(Sex Sexes)
        {
            _context.Sexes.Add(Sexes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSexes", new { id = Sexes.Id }, Sexes);
        }

        // DELETE: api/Sexes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSexes(int id)
        {
            var Sexes = await _context.Sexes.FindAsync(id);
            if (Sexes == null)
            {
                return NotFound();
            }

            _context.Sexes.Remove(Sexes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SexesExists(int id)
        {
            return _context.Sexes.Any(e => e.Id == id);
        }
    }
}
