using System;
using System.Collections.Generic;

namespace Exercises.Api.Data
{
    public class Workout
    {
      public int Id { get; set; }
      public string name { get; set; }
      public List<WorkoutExercise> Exercises { get; set; }
      public List<ProgramWorkout> Workouts { get; set; }
    }
}