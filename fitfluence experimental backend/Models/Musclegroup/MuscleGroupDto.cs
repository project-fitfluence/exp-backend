using System.ComponentModel.DataAnnotations;

namespace fitfluence_experimental_backend.Models.Musclegroup
{
    public class MuscleGroupDto
    {
        [Required]
        public string Name { get; set; }
    }
}
