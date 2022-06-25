using System.ComponentModel.DataAnnotations;

namespace fitfluence_experimental_backend.Models.Exercise
{
    public class ExerciseDto
    {
        [Required]
        [StringLength(20, ErrorMessage = "Length can't be more than {1}")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        [Range(1, 10)]
        public int MuscleGroupId { get; set; }
    }
}