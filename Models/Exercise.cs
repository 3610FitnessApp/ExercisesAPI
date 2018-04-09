using System;
using System.Collections.Generic;

namespace Exercises.Api.Data
{
    public class Exercise
    {
        public int Id { get; set; }
        public string name { get; set; }
        public List<ExerciseBodyPart> ExerciseBodyPart { get; set; }
    }
}