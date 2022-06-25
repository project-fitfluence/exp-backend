using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fitfluence_experimental_backend.Data;
using AutoMapper;
using fitfluence_experimental_backend.Contracts;
using fitfluence_experimental_backend.Models.Exercise;

namespace fitfluence_experimental_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IExercisesRepository _exercisesRepository;

        public ExercisesController(IMapper mapper, IExercisesRepository exercisesRepository)
        {
            this._mapper = mapper;
            this._exercisesRepository = exercisesRepository;
        }

        // GET: api/Exercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetExerciseDto>>> GetExercises()
        {
            var exercises = await _exercisesRepository.GetAllAsync();
            if (exercises == null)
            {
                return NotFound();
            }

            var records = _mapper.Map<List<GetExerciseDto>>(exercises);

            return Ok(records);
        }

        // GET: api/Exercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetExerciseDto>> GetExercise(int id)
        {
            var exercises = await _exercisesRepository.GetAsync(id);

            if (exercises == null)
            {
                return NotFound();
            }

            var exercisesDto = _mapper.Map<GetExerciseDto>(exercises);

            return Ok(exercisesDto);
        }

        // PUT: api/Exercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercise(int id, UpdateExerciseDto updateExerciseDto)
        {
            if (id != updateExerciseDto.Id)
            {
                return BadRequest();
            }

            // Fetch record from database
            var exercise = await _exercisesRepository.GetAsync(id);

            // Check if record exists
            if (exercise == null)
            {
                return NotFound();
            }

            // Modify the record by mapping our DTO data to the fetched model
            _mapper.Map(updateExerciseDto, exercise);

            try
            {
                // Update entity changes
                await _exercisesRepository.UpdateAsync(exercise);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _exercisesRepository.Exists(id))
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

        // POST: api/Exercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exercise>> PostExercise(CreateExerciseDto createExerciseDto)
        {
            // "CreateMuscleGroupDto" Now using DTO's to prevent overposting
            // Map DTO to Model
            var exercise = _mapper.Map<Exercise>(createExerciseDto);

            try
            {
                await _exercisesRepository.AddAsync(exercise);
            }
            catch (DbUpdateConcurrencyException)
            {
                return UnprocessableEntity();
            }

            return CreatedAtAction("GetExercise", new { id = exercise.Id }, exercise);
        }

        // DELETE: api/Exercises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            var exercise = await _exercisesRepository.GetAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            try
            {
                await _exercisesRepository.DeleteAsync(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict();
            }

            return NoContent();
        }
    }
}
