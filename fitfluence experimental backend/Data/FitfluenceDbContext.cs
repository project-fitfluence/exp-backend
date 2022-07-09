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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<WorkoutDay> WorkoutDays { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new MuscleGroupConfiguration());

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.WorkoutPlans)
                .WithMany(w => w.Customers)
                .UsingEntity(j => j.ToTable("WorkoutPlansCustomers"));
        }
    }
}
