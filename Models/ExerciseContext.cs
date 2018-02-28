using Microsoft.EntityFrameworkCore;

namespace Exercises.Api.Models
{
    public class ExerciseContext : DbContext
    {
        public ExerciseContext(DbContextOptions<ExerciseContext> options)
            : base(options)
            {
            }

            public DbSet<Exercise> Exercises { get; set; }

            public DbSet<Workout> Workouts { get; set; }
    }
}