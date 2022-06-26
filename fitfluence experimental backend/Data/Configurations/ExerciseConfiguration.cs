using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fitfluence_experimental_backend.Data.Configurations
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasData(
                new Exercise
                {
                    Id = 1,
                    Name = "Benchpress",
                    Description = "A great exercise for the general chest area",
                    MuscleGroupId = 2
                },
                new Exercise
                {
                    Id = 2,
                    Name = "Squat",
                    Description = "Great for building strong legs!",
                    MuscleGroupId = 6
                }
            );
        }
    }
}
