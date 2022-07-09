using fitfluence_experimental_backend.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace fitfluence_experimental_backend.Data
{
    public class WorkoutDay
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(TrainerId))]
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }

        [ForeignKey(nameof(WorkoutPlanId))]
        public int WorkoutPlanId { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; }

        [Column(TypeName = "int")]
        public ExerciseDayTypes DayType { get; set; }

        public IList<Exercise> Exercises { get; set; }
    }

}
