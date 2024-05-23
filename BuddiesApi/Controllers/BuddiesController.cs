using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeBuddies.Data;
using CodeBuddies.Models.Entities;

namespace BuddiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuddiesController : ControllerBase
    {
        private readonly DatabaseApplicationContext _context;

        public BuddiesController(DatabaseApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Buddies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buddy>>> GetBuddies()
        {
            return await _context.Buddies.ToListAsync();
        }

        // GET: api/Buddies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Buddy>> GetBuddy(long id)
        {
            var buddy = await _context.Buddies.FindAsync(id);

            if (buddy == null)
            {
                return NotFound();
            }

            return buddy;
        }

        // PUT: api/Buddies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuddy(long id, Buddy buddy)
        {
            if (id != buddy.Id)
            {
                return BadRequest();
            }

            _context.Entry(buddy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuddyExists(id))
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

        // POST: api/Buddies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Buddy>> PostBuddy(Buddy buddy)
        {
            _context.Buddies.Add(buddy);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostBuddy), new { id = buddy.Id }, buddy);
        }

        // DELETE: api/Buddies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuddy(long id)
        {
            var buddy = await _context.Buddies.FindAsync(id);
            if (buddy == null)
            {
                return NotFound();
            }

            _context.Buddies.Remove(buddy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuddyExists(long id)
        {
            return _context.Buddies.Any(e => e.Id == id);
        }
    }
}
