using Microsoft.EntityFrameworkCore;

namespace Exercises.Api.Data
{
    public class ExerciseContext : DbContext
    {
        public ExerciseContext(DbContextOptions<ExerciseContext> options)
            : base(options)
            {
            }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<ExerciseBodyPart>().HasKey(ebp => new { ebp.exerciseId, ebp.bodyPartId});
            builder.Entity<WorkoutExercise>().HasKey(ebp => new { ebp.exerciseId, ebp.workoutId});
            builder.Entity<ProgramWorkout>().HasKey(ebp => new { ebp.workoutId, ebp.programId});
        }

        public DbSet<BodyPart> BodyParts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseInstance> ExerciseInstances { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<ProgramInstance> ProgramInstances { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutInstance> WorkoutInstances { get; set; }
        public DbSet<ExerciseBodyPart> ExerciseBodyParts { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<ProgramWorkout> ProgramWorkouts { get; set; }

    }
}