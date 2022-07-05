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
using fitfluence_experimental_backend.Models;

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

        // GET: api/Hotels
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetMuscleGroupDto>>> GetMuscleGroups()
        {
            var muscleGroups = await _muscleGroupsRepository.GetAllAsync<List<GetMuscleGroupDto>>();
            return Ok(muscleGroups);
        }

        // GET: api/MuscleGroups?startindex=0&pagesize=25&pagenumber=1
        [HttpGet]
        public async Task<ActionResult<PagedResult<GetMuscleGroupDto>>> GetMuscleGroups([FromQuery] QueryParameters queryParameters)
        {
            var pagedMuscleGroupsResult = await _muscleGroupsRepository.GetAllAsync<GetMuscleGroupDto>(queryParameters);
            return Ok(pagedMuscleGroupsResult);
        }

        // GET: api/MuscleGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetMuscleGroupDto>> GetMuscleGroup(int id)
        {
            var muscleGroups = await _muscleGroupsRepository.GetAsync(id);
            return Ok(muscleGroups);
        }

        // PUT: api/MuscleGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutMuscleGroup(int id, UpdateMuscleGroupDto updateMuscleGroupDto)
        {
            try
            {
                await _muscleGroupsRepository.UpdateAsync(id, updateMuscleGroupDto);
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
            var muscleGroup = await _muscleGroupsRepository.AddAsync<CreateMuscleGroupDto, GetMuscleGroupDto>(createMuscleGroup);
            return CreatedAtAction(nameof(GetMuscleGroup), new { id = muscleGroup.Id }, muscleGroup);
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
