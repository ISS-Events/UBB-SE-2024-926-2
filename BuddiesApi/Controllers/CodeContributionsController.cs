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
    public class CodeContributionsController : ControllerBase
    {
        private readonly DatabaseApplicationContext _context;

        public CodeContributionsController(DatabaseApplicationContext context)
        {
            _context = context;
        }

        // GET: api/CodeContributions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodeContribution>>> GetCodeContributions()
        {
            return await _context.CodeContributions.ToListAsync();
        }

        // GET: api/CodeContributions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CodeContribution>> GetCodeContribution(long id)
        {
            var codeContribution = await _context.CodeContributions.FindAsync(id);

            if (codeContribution == null)
            {
                return NotFound();
            }

            return codeContribution;
        }

        // PUT: api/CodeContributions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCodeContribution(long id, CodeContribution codeContribution)
        {
            if (id != codeContribution.Id)
            {
                return BadRequest();
            }

            _context.Entry(codeContribution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodeContributionExists(id))
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

        // POST: api/CodeContributions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CodeContribution>> PostCodeContribution(CodeContribution codeContribution)
        {
            _context.CodeContributions.Add(codeContribution);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCodeContribution", new { id = codeContribution.Id }, codeContribution);
        }

        // DELETE: api/CodeContributions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCodeContribution(long id)
        {
            var codeContribution = await _context.CodeContributions.FindAsync(id);
            if (codeContribution == null)
            {
                return NotFound();
            }

            _context.CodeContributions.Remove(codeContribution);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CodeContributionExists(long id)
        {
            return _context.CodeContributions.Any(e => e.Id == id);
        }
    }
}
