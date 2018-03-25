using System;
using System.Collections.Generic;

namespace Exercises.Api.Models
{
    public class WorkoutInstance{
        public int Id { get; set; }
        public DateTime date { get; set; }
        public int userId { get; set; }
        public int workoutId { get; set; }
        public List<ExerciseInstance> exercises { get; set; }
    }
}