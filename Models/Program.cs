using System;
using System.Collections.Generic;

namespace Exercises.Api.Data
{
    public class Program
    {
        public int Id { get; set; }
        public string programName { get; set; }
        public int daysPerWeek { get; set; }
        public int week { get; set; }
        public List<ProgramWorkout> Workouts { get; set; }
        
    }
}