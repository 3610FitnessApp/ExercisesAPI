using System;
using System.Collections.Generic;

namespace Exercises.Api.Models
{
    public class Program
    {
        public int Id { get; set; }
        public string programName { get; set; }
        public List<Workout> workouts{ get; set; }
        public int daysPerWeek { get; set; }
        public int week { get; set; }
        
    }
}