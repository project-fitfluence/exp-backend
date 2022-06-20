using AutoMapper;
using fitfluence_experimental_backend.Data;
using fitfluence_experimental_backend.Models.Exercise;
using fitfluence_experimental_backend.Models.Musclegroup;

namespace fitfluence_experimental_backend.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<MuscleGroup, CreateMuscleGroupDto>().ReverseMap();
            CreateMap<MuscleGroup, GetMuscleGroupDto>().ReverseMap();
            CreateMap<MuscleGroup, GetMuscleGroupDetailsDto>().ReverseMap();
            CreateMap<Exercise, ExerciseDto>().ReverseMap();
        }
    }
}
