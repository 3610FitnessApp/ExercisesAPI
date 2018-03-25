using System;

namespace Exercises.Api.Models
{
    public class ExerciseInstance{
        public int weight { get; set; }
        public int reps { get; set; }
        public int sets { get; set; }
        public int workoutId { get; set; }
        public int exerciseId { get; set; }
    }
}