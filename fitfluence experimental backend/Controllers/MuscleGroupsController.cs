using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fitfluence_experimental_backend.Data;
using fitfluence_experimental_backend.Models.Musclegroup;
using AutoMapper;

namespace fitfluence_experimental_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuscleGroupsController : ControllerBase
    {
        private readonly FitfluenceDbContext _context;
        private readonly IMapper _mapper;

        public MuscleGroupsController(FitfluenceDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/MuscleGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetMuscleGroupDto>>> GetMuscleGroups()
        {
            if (_context.MuscleGroups == null)
            {
                return NotFound();
            }
            var muscleGroups = await _context.MuscleGroups.ToListAsync();

            
            //Here we get a List of GetMuscleGroupDto's
            //mapper wouldn't have alerted otherwise.
            var records = _mapper.Map<List<GetMuscleGroupDto>>(muscleGroups);

            return Ok(records);
        }

        // GET: api/MuscleGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetMuscleGroupDetailsDto>> GetMuscleGroup(int id)
        {
            if (_context.MuscleGroups == null)
            {
                return NotFound();
            }

            var muscleGroup = await _context.MuscleGroups.
                Include(q => q.Exercises)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (muscleGroup == null)
            {
                return NotFound();
            }

            var muscleGroupDto = _mapper.Map<GetMuscleGroupDetailsDto>(muscleGroup);

            return muscleGroupDto;
        }

        // PUT: api/MuscleGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMuscleGroup(int id, UpdateMuscleGroupDto updateMuscleGroupDto)
        {
            if (id != updateMuscleGroupDto.Id)
            {
                return BadRequest();
            }

            // Fetch record from database
            var muscleGroup = await _context.MuscleGroups.FindAsync(id);

            // Check if record exists
            if (muscleGroup == null)
            {
                return NotFound();
            }

            // Modify the record by mapping our DTO data to the fetched model
            _mapper.Map(updateMuscleGroupDto, muscleGroup);

            try
            {
                // Persist changes
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
        public async Task<ActionResult<MuscleGroup>> PostMuscleGroup(CreateMuscleGroupDto createMuscleGroup)
        {
            // "CreateMuscleGroupDto" Now using DTO's to prevent overposting

            if (_context.MuscleGroups == null)
            {
                return Problem("Entity set 'FitfluenceDbContext.MuscleGroups'  is null.");
            }

            // Map DTO to Model
            var muscleGroup = _mapper.Map<MuscleGroup>(createMuscleGroup);

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
