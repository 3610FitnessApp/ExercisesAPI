using System;
using System.Collections.Generic;

namespace Exercises.Api.Models
{
    public class BodyPart
    {
        public int Id { get; set; }
        public string name { get; set; }
        public List<Exercise> exercises { get; set; }
        
    }
}