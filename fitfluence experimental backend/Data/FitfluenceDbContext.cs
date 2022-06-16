using Microsoft.EntityFrameworkCore;

namespace fitfluence_experimental_backend.Data
{
    public class FitfluenceDbContext: DbContext
    {
        public FitfluenceDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MuscleGroup>().HasData(
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
            modelBuilder.Entity<Exercise>().HasData(
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
