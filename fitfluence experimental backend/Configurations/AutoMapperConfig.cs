using AutoMapper;
using fitfluence_experimental_backend.Data;
using fitfluence_experimental_backend.Models.Exercise;
using fitfluence_experimental_backend.Models.Musclegroup;
using fitfluence_experimental_backend.Models.Users;

namespace fitfluence_experimental_backend.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<MuscleGroup, MuscleGroupDto>().ReverseMap();
            CreateMap<MuscleGroup, CreateMuscleGroupDto>().ReverseMap();
            CreateMap<MuscleGroup, GetMuscleGroupDto>().ReverseMap();
            CreateMap<MuscleGroup, GetMuscleGroupDetailsDto>().ReverseMap();
            CreateMap<MuscleGroup, UpdateMuscleGroupDto>().ReverseMap();

            CreateMap<Exercise, ExerciseDto>().ReverseMap();
            CreateMap<Exercise, CreateExerciseDto>().ReverseMap();
            CreateMap<Exercise, GetExerciseDto>().ReverseMap();
            CreateMap<Exercise, UpdateExerciseDto>().ReverseMap();

            CreateMap<ApiUserDto, ApiUser>().ReverseMap();
        }
    }
}
