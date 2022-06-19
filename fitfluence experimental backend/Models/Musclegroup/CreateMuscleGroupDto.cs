using System.ComponentModel.DataAnnotations;

namespace fitfluence_experimental_backend.Models.Musclegroup
{
    public class CreateMuscleGroupDto
    {
        [Required]
        public string Name { get; set; }
    }
}
