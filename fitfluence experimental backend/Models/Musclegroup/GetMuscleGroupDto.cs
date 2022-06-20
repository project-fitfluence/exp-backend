using fitfluence_experimental_backend.Models.Exercise;
using System.ComponentModel.DataAnnotations;

namespace fitfluence_experimental_backend.Models.Musclegroup
{
    public class GetMuscleGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GetMuscleGroupDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
    }
}
