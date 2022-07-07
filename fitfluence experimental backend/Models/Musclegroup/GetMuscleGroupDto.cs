using fitfluence_experimental_backend.Models.Exercise;
using System.ComponentModel.DataAnnotations;

namespace fitfluence_experimental_backend.Models.Musclegroup
{
    public class GetMuscleGroupDto: MuscleGroupDto, IBaseDto
    {
        public int Id { get; set; }
    }
}
