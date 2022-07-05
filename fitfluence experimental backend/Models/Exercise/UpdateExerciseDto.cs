using HotelListing.API.Core.Models;

namespace fitfluence_experimental_backend.Models.Exercise
{
    public class UpdateExerciseDto: ExerciseDto, IBaseDto
    {
        public int Id { get; set; }
    }
}
