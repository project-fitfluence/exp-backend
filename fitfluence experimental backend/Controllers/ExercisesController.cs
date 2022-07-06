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
using Microsoft.AspNetCore.Authorization;
using fitfluence_experimental_backend.Models;

namespace fitfluence_experimental_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExercisesController : ControllerBase
    {
        private readonly IExercisesRepository _exercisesRepository;

        public ExercisesController(IExercisesRepository exercisesRepository)
        {
            this._exercisesRepository = exercisesRepository;
        }

        // GET: api/Exercises
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetExerciseDto>>> GetExercises()
        {
            var exercises = await _exercisesRepository.GetAllAsync<List<GetExerciseDto>>();
            return Ok(exercises);
        }

        // GET: api/Exercises?startindex=0&pagesize=25&pagenumber=1
        [HttpGet]
        public async Task<ActionResult<PagedResult<GetExerciseDto>>> GetExercises([FromQuery] QueryParameters queryParameters)
        {
            var pagedExercisesResult = await _exercisesRepository.GetAllAsync<GetExerciseDto>(queryParameters);
            return Ok(pagedExercisesResult);
        }

        // GET: api/Exercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetExerciseDto>> GetExercise(int id)
        {
            var exercise = await _exercisesRepository.GetAsync(id);
            return Ok(exercise);
        }

        // PUT: api/Exercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercise(int id, UpdateExerciseDto updateExerciseDto)
        {
            try
            {
                await _exercisesRepository.UpdateAsync(id, updateExerciseDto);
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
        public async Task<ActionResult<ExerciseDto>> PostExercise(CreateExerciseDto exerciseDto)
        {
            var exercise = await _exercisesRepository.AddAsync<CreateExerciseDto, GetExerciseDto>(exerciseDto);
            return CreatedAtAction(nameof(GetExercise), new { id = exercise.Id }, exercise);
        }

        // DELETE: api/Exercises/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
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
