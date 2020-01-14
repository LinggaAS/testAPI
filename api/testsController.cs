using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.Data;
using testAPI.models;

namespace testAPI.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class testsController : ControllerBase
    {
        private readonly testAPIContext _context;

        public testsController(testAPIContext context)
        {
            _context = context;
        }

        // GET: api/tests
        [HttpGet]
        public IEnumerable<test> Gettest()
        {
            return _context.test;
        }

        // GET: api/tests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Gettest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var test = await _context.test.FindAsync(id);

            if (test == null)
            {
                return NotFound();
            }

            return Ok(test);
        }

        // PUT: api/tests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttest([FromRoute] int id, [FromBody] test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != test.Id)
            {
                return BadRequest();
            }

            _context.Entry(test).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!testExists(id))
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

        // POST: api/tests
        [HttpPost]
        public async Task<IActionResult> Posttest([FromBody] test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.test.Add(test);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettest", new { id = test.Id }, test);
        }

        // DELETE: api/tests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var test = await _context.test.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            _context.test.Remove(test);
            await _context.SaveChangesAsync();

            return Ok(test);
        }

        private bool testExists(int id)
        {
            return _context.test.Any(e => e.Id == id);
        }
    }
}