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
    public class InviteNotificationsController : ControllerBase
    {
        private readonly DatabaseApplicationContext _context;

        public InviteNotificationsController(DatabaseApplicationContext context)
        {
            _context = context;
        }

        // GET: api/InviteNotifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InviteNotification>>> GetInviteNotifications()
        {
            return await _context.InviteNotifications.ToListAsync();
        }

        // GET: api/InviteNotifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InviteNotification>> GetInviteNotification(long id)
        {
            var inviteNotification = await _context.InviteNotifications.FindAsync(id);

            if (inviteNotification == null)
            {
                return NotFound();
            }

            return inviteNotification;
        }

        // PUT: api/InviteNotifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInviteNotification(long id, InviteNotification inviteNotification)
        {
            if (id != inviteNotification.Id)
            {
                return BadRequest();
            }

            _context.Entry(inviteNotification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InviteNotificationExists(id))
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

        // POST: api/InviteNotifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InviteNotification>> PostInviteNotification(InviteNotification inviteNotification)
        {
            _context.InviteNotifications.Add(inviteNotification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInviteNotification", new { id = inviteNotification.Id }, inviteNotification);
        }

        // DELETE: api/InviteNotifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInviteNotification(long id)
        {
            var inviteNotification = await _context.InviteNotifications.FindAsync(id);
            if (inviteNotification == null)
            {
                return NotFound();
            }

            _context.InviteNotifications.Remove(inviteNotification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InviteNotificationExists(long id)
        {
            return _context.InviteNotifications.Any(e => e.Id == id);
        }
    }
}
