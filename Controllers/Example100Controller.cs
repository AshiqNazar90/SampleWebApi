#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebApi.Data;
using SampleWebApi.Model;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Example100Controller : ControllerBase
    {
        private readonly ExampleDbContext _context;

        public Example100Controller(ExampleDbContext context)
        {
            _context = context;
        }

        // GET: api/Example100
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Example>>> GetExamples()
        {
            return await _context.Examples.ToListAsync();
        }

        // GET: api/Example100/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Example>> GetExample(int id)
        {
            var example = await _context.Examples.FindAsync(id);

            if (example == null)
            {
                return NotFound();
            }

            return example;
        }

        // PUT: api/Example100/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExample(int id, Example example)
        {
            if (id != example.ID)
            {
                return BadRequest();
            }

            _context.Entry(example).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExampleExists(id))
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

        // POST: api/Example100
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Example>> PostExample(Example example)
        {
            _context.Examples.Add(example);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExample", new { id = example.ID }, example);
        }

        // DELETE: api/Example100/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExample(int id)
        {
            var example = await _context.Examples.FindAsync(id);
            if (example == null)
            {
                return NotFound();
            }

            _context.Examples.Remove(example);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExampleExists(int id)
        {
            return _context.Examples.Any(e => e.ID == id);
        }
    }
}
