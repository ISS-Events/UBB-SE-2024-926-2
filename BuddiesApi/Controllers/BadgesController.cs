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
    public class BadgesController : ControllerBase
    {
        private readonly DatabaseApplicationContext _context;

        public BadgesController(DatabaseApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Badges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Badge>>> GetBadges()
        {
            return await _context.Badges.ToListAsync();
        }

        // GET: api/Badges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Badge>> GetBadge(long id)
        {
            var badge = await _context.Badges.FindAsync(id);

            if (badge == null)
            {
                return NotFound();
            }

            return badge;
        }

        // PUT: api/Badges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBadge(long id, Badge badge)
        {
            if (id != badge.ID)
            {
                return BadRequest();
            }

            _context.Entry(badge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BadgeExists(id))
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

        // POST: api/Badges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Badge>> PostBadge(Badge badge)
        {
            _context.Badges.Add(badge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBadge", new { id = badge.ID }, badge);
        }

        // DELETE: api/Badges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBadge(long id)
        {
            var badge = await _context.Badges.FindAsync(id);
            if (badge == null)
            {
                return NotFound();
            }

            _context.Badges.Remove(badge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BadgeExists(long id)
        {
            return _context.Badges.Any(e => e.ID == id);
        }
    }
}
