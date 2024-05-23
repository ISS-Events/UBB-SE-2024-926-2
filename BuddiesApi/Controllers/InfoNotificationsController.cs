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
    public class InfoNotificationsController : ControllerBase
    {
        private readonly DatabaseApplicationContext _context;

        public InfoNotificationsController(DatabaseApplicationContext context)
        {
            _context = context;
        }

        // GET: api/InfoNotifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoNotification>>> GetInfoNotifications()
        {
            return await _context.InfoNotifications.ToListAsync();
        }

        // GET: api/InfoNotifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoNotification>> GetInfoNotification(long id)
        {
            var infoNotification = await _context.InfoNotifications.FindAsync(id);

            if (infoNotification == null)
            {
                return NotFound();
            }

            return infoNotification;
        }

        // PUT: api/InfoNotifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoNotification(long id, InfoNotification infoNotification)
        {
            if (id != infoNotification.Id)
            {
                return BadRequest();
            }

            _context.Entry(infoNotification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoNotificationExists(id))
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

        // POST: api/InfoNotifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfoNotification>> PostInfoNotification(InfoNotification infoNotification)
        {
            _context.InfoNotifications.Add(infoNotification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfoNotification", new { id = infoNotification.Id }, infoNotification);
        }

        // DELETE: api/InfoNotifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfoNotification(long id)
        {
            var infoNotification = await _context.InfoNotifications.FindAsync(id);
            if (infoNotification == null)
            {
                return NotFound();
            }

            _context.InfoNotifications.Remove(infoNotification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfoNotificationExists(long id)
        {
            return _context.InfoNotifications.Any(e => e.Id == id);
        }
    }
}
