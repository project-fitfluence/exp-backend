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
using fitfluence_experimental_backend.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace fitfluence_experimental_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuscleGroupsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMuscleGroupsRepository _muscleGroupsRepository;

        public MuscleGroupsController(IMapper mapper, IMuscleGroupsRepository muscleGroupsRepository)
        {
            this._mapper = mapper;
            this._muscleGroupsRepository = muscleGroupsRepository;
        }

        // GET: api/MuscleGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetMuscleGroupDto>>> GetMuscleGroups()
        {
            var muscleGroups = await _muscleGroupsRepository.GetAllAsync();
            if (muscleGroups == null)
            {
                return NotFound();
            }
            
            //Here we get a List of GetMuscleGroupDto's
            //mapper wouldn't have alerted otherwise.
            var records = _mapper.Map<List<GetMuscleGroupDto>>(muscleGroups);

            return Ok(records);
        }

        // GET: api/MuscleGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetMuscleGroupDetailsDto>> GetMuscleGroup(int id)
        {
            var muscleGroup = await _muscleGroupsRepository.GetDetails(id);

            if (muscleGroup == null)
            {
                return NotFound();
            }

            var muscleGroupDto = _mapper.Map<GetMuscleGroupDetailsDto>(muscleGroup);

            return Ok(muscleGroupDto);
        }

        // PUT: api/MuscleGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutMuscleGroup(int id, UpdateMuscleGroupDto updateMuscleGroupDto)
        {
            if (id != updateMuscleGroupDto.Id)
            {
                return BadRequest();
            }

            // Fetch record from database
            var muscleGroup = await _muscleGroupsRepository.GetAsync(id);

            // Check if record exists
            if (muscleGroup == null)
            {
                return NotFound();
            }

            // Modify the record by mapping our DTO data to the fetched model
            _mapper.Map(updateMuscleGroupDto, muscleGroup);

            try
            {
                // Update entity changes
                await _muscleGroupsRepository.UpdateAsync(muscleGroup);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _muscleGroupsRepository.Exists(id))
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
        [Authorize]
        public async Task<ActionResult<MuscleGroup>> PostMuscleGroup(CreateMuscleGroupDto createMuscleGroup)
        {
            // "CreateMuscleGroupDto" Now using DTO's to prevent overposting
            // Map DTO to Model
            var muscleGroup = _mapper.Map<MuscleGroup>(createMuscleGroup);

            try
            {
                await _muscleGroupsRepository.AddAsync(muscleGroup);
            } catch (DbUpdateConcurrencyException)
            {
                return UnprocessableEntity();
            }

            return CreatedAtAction("GetMuscleGroup", new { id = muscleGroup.Id }, muscleGroup);
        }

        // DELETE: api/MuscleGroups/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteMuscleGroup(int id)
        {
            var muscleGroup = await _muscleGroupsRepository.GetAsync(id);
            if (muscleGroup == null)
            {
                return NotFound();
            }

            try
            {
                await _muscleGroupsRepository.DeleteAsync(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict();
            }

            return NoContent();
        }
    }
}
