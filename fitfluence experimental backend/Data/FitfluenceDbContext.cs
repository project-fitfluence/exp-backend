using fitfluence_experimental_backend.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace fitfluence_experimental_backend.Data
{
    public class FitfluenceDbContext: IdentityDbContext<ApiUser>
    {
        public FitfluenceDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new MuscleGroupConfiguration());
        }
    }
}
