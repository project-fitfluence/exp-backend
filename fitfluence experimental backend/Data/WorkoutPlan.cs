using fitfluence_experimental_backend.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace fitfluence_experimental_backend.Data
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(TrainerId))]
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
        public virtual IList<Customer> Customers { get; set; }
        public ICollection<WorkoutDay> WorkoutDays { get; set; }
    }

}
