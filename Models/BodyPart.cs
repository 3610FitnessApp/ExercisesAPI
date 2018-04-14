using System;
using System.Collections.Generic;

namespace Exercises.Api.Data
{
    public class BodyPart
    {
        public int Id { get; set; }
        public string name { get; set; }

        public List<ExerciseBodyPart> ExerciseBodyPart { get; set; }
    }
}