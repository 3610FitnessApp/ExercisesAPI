using System;
using System.Collections.Generic;

namespace Exercises.Api.Models
{
    public class Workout
    {
      public int Id { get; set; }
      public List<Exercise> Exercise { get; set; }

      public DateTime WorkoutDate { get; set; }
    }
}