using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fitfluence_experimental_backend.Data.Configurations
{
    public class MuscleGroupConfiguration : IEntityTypeConfiguration<MuscleGroup>
    {
        public void Configure(EntityTypeBuilder<MuscleGroup> builder)
        {
            builder.HasData(
                new MuscleGroup
                {
                    Id = 1,
                    Name = "Deltoid"
                },
                new MuscleGroup
                {
                    Id = 2,
                    Name = "Pectoral"
                },
                new MuscleGroup
                {
                    Id = 3,
                    Name = "Quadriceps"
                },
                new MuscleGroup
                {
                    Id = 4,
                    Name = "Oblique"
                },
                new MuscleGroup
                {
                    Id = 5,
                    Name = "Hamstrings"
                },
                new MuscleGroup
                {
                    Id = 6,
                    Name = "Gluteus"
                },
                new MuscleGroup
                {
                    Id = 7,
                    Name = "Trapezius"
                },
                new MuscleGroup
                {
                    Id = 8,
                    Name = "Triceps"
                },
                new MuscleGroup
                {
                    Id = 9,
                    Name = "Gastrocnemius"
                },
                new MuscleGroup
                {
                    Id = 10,
                    Name = "Latissimus Dorsi"
                },
                new MuscleGroup
                {
                    Id = 11,
                    Name = "Abdominals"
                },
                new MuscleGroup
                {
                    Id = 12,
                    Name = "Biceps"
                }
            );
        }
    }
}
