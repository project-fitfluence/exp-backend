using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace fitfluence_experimental_backend.Data
{
    public class Customer
    {
        public int Id { get; set; }
        [ForeignKey(nameof(ApiUserId))]
        public int ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }
        public virtual IList<WorkoutPlan> WorkoutPlans { get; set; }
    }
}
