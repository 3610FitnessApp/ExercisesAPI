using System;

namespace Exercises.Api.Models
{
    public class Workout
    {
      public int Id { get; set; }
      public Exercise[] Exercise { get; set; }

      public DateTime WorkoutDate { get; set; }
    }
}