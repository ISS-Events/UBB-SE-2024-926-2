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
    public class CodeReviewSectionsController : ControllerBase
    {
        private readonly DatabaseApplicationContext _context;

        public CodeReviewSectionsController(DatabaseApplicationContext context)
        {
            _context = context;
        }

        // GET: api/CodeReviewSections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodeReviewSection>>> GetCodeReviewSections()
        {
            return await _context.CodeReviewSections.ToListAsync();
        }

        // GET: api/CodeReviewSections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CodeReviewSection>> GetCodeReviewSection(long id)
        {
            var codeReviewSection = await _context.CodeReviewSections.FindAsync(id);

            if (codeReviewSection == null)
            {
                return NotFound();
            }

            return codeReviewSection;
        }

        // PUT: api/CodeReviewSections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCodeReviewSection(long id, CodeReviewSection codeReviewSection)
        {
            if (id != codeReviewSection.Id)
            {
                return BadRequest();
            }

            _context.Entry(codeReviewSection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodeReviewSectionExists(id))
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

        // POST: api/CodeReviewSections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CodeReviewSection>> PostCodeReviewSection(CodeReviewSection codeReviewSection)
        {
            _context.CodeReviewSections.Add(codeReviewSection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCodeReviewSection", new { id = codeReviewSection.Id }, codeReviewSection);
        }

        // DELETE: api/CodeReviewSections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCodeReviewSection(long id)
        {
            var codeReviewSection = await _context.CodeReviewSections.FindAsync(id);
            if (codeReviewSection == null)
            {
                return NotFound();
            }

            _context.CodeReviewSections.Remove(codeReviewSection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CodeReviewSectionExists(long id)
        {
            return _context.CodeReviewSections.Any(e => e.Id == id);
        }
    }
}
