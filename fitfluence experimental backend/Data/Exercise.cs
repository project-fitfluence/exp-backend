using System.ComponentModel.DataAnnotations.Schema;

namespace fitfluence_experimental_backend.Data
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(MuscleGroupId))]
        public int MuscleGroupId { get; set; }
        public MuscleGroup MuscleGroup { get; set; }

    }

}
