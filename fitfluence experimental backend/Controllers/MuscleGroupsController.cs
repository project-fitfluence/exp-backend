using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fitfluence_experimental_backend.Data;

namespace fitfluence_experimental_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuscleGroupsController : ControllerBase
    {
        private readonly FitfluenceDbContext _context;

        public MuscleGroupsController(FitfluenceDbContext context)
        {
            _context = context;
        }

        // GET: api/MuscleGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MuscleGroup>>> GetMuscleGroups()
        {
          if (_context.MuscleGroups == null)
          {
              return NotFound();
          }
            return await _context.MuscleGroups.ToListAsync();
        }

        // GET: api/MuscleGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MuscleGroup>> GetMuscleGroup(int id)
        {
          if (_context.MuscleGroups == null)
          {
              return NotFound();
          }
            var muscleGroup = await _context.MuscleGroups.FindAsync(id);

            if (muscleGroup == null)
            {
                return NotFound();
            }

            return muscleGroup;
        }

        // PUT: api/MuscleGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMuscleGroup(int id, MuscleGroup muscleGroup)
        {
            if (id != muscleGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(muscleGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MuscleGroupExists(id))
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

        // POST: api/MuscleGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MuscleGroup>> PostMuscleGroup(MuscleGroup muscleGroup)
        {
          if (_context.MuscleGroups == null)
          {
              return Problem("Entity set 'FitfluenceDbContext.MuscleGroups'  is null.");
          }
            _context.MuscleGroups.Add(muscleGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMuscleGroup", new { id = muscleGroup.Id }, muscleGroup);
        }

        // DELETE: api/MuscleGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMuscleGroup(int id)
        {
            if (_context.MuscleGroups == null)
            {
                return NotFound();
            }
            var muscleGroup = await _context.MuscleGroups.FindAsync(id);
            if (muscleGroup == null)
            {
                return NotFound();
            }

            _context.MuscleGroups.Remove(muscleGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MuscleGroupExists(int id)
        {
            return (_context.MuscleGroups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
