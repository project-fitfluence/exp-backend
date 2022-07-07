using fitfluence_experimental_backend.Models.Exercise;

namespace fitfluence_experimental_backend.Models.Musclegroup
{
    public class GetMuscleGroupDetailsDto: MuscleGroupDto, IBaseDto
    {
        public int Id { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
    }
}
