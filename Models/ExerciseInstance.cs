using System;

namespace Exercises.Api.Data
{
    public class ExerciseInstance{
        public int Id { get; set; }
        public int weight { get; set; }
        public int reps { get; set; }
        public int sets { get; set; }
        public int workoutId { get; set; }
        public int exerciseId { get; set; }

        //setting user to this instance
        public User user { get; set; }
    }
}