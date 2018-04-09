using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Exercises.Api.Data;

namespace Exercises.Api.Data
{
    public class ExerciseContext : IdentityDbContext<User>
    {
        public ExerciseContext(DbContextOptions<ExerciseContext> options)
            : base(options)
            {
            }


        public ExerciseContext()
            {
            }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<ExerciseBodyPart>().HasKey(ebp => new { ebp.exerciseId, ebp.bodyPartId});
            builder.Entity<WorkoutExercise>().HasKey(ebp => new { ebp.exerciseId, ebp.workoutId});
            builder.Entity<ProgramWorkout>().HasKey(ebp => new { ebp.workoutId, ebp.programId});
            base.OnModelCreating(builder);
        }

        public DbSet<BodyPart> BodyParts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseInstance> ExerciseInstances { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<ProgramInstance> ProgramInstances { get; set; }
        public DbSet<User> AspNetUsers {get; set;}
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutInstance> WorkoutInstances { get; set; }
        public DbSet<ExerciseBodyPart> ExerciseBodyParts { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<ProgramWorkout> ProgramWorkouts { get; set; }


    }
}