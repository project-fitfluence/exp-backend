using HotelListing.API.Core.Models;

namespace fitfluence_experimental_backend.Models.Musclegroup
{
    public class UpdateMuscleGroupDto : MuscleGroupDto, IBaseDto
    {
        public int Id { get; set; }
    }
}
