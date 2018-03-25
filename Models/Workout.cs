using System;
using System.Collections.Generic;

namespace Exercises.Api.Data
{
    public class Workout
    {
      public int Id { get; set; }
      public string name { get; set; }
      public List<Exercise> exercises { get; set; }
      public List<BodyPart> bodyParts { get; set; }
    }
}