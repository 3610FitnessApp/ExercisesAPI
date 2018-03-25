using System;
using System.Collections.Generic;

namespace Exercises.Api.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string name { get; set; }
        public List<Workout> workouts { get; set; }
        public List<BodyPart> bodyParts { get; set; }
    }
}