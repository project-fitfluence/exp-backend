using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace fitfluence_experimental_backend.Data
{
    public class Trainer
    {
        public int Id { get; set; }
        [ForeignKey(nameof(ApiUserId))]
        public int ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }
        public IList<Exercise> Exercises { get; set; }
        public IList<WorkoutDay> WorkoutDays { get; set; }
        public IList<WorkoutPlan> WorkoutPlan { get; set; }
    }
}
