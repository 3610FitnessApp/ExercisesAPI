using Microsoft.EntityFrameworkCore;

namespace Exercises.Api.Data
{
    public class ExerciseContext : DbContext
    {
        public ExerciseContext(DbContextOptions<ExerciseContext> options)
            : base(options)
            {
            }

        protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);

        public DbSet<BodyPart> BodyParts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseInstance> ExerciseInstances { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<ProgramInstance> ProgramInstances { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutInstance> WorkoutInstances { get; set; }

    }
}