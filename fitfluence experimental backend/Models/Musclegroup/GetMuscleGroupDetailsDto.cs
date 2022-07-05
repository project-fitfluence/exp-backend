using fitfluence_experimental_backend.Models.Exercise;
using HotelListing.API.Core.Models;

namespace fitfluence_experimental_backend.Models.Musclegroup
{
    public class GetMuscleGroupDetailsDto: MuscleGroupDto, IBaseDto
    {
        public int Id { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
    }
}
