using System;
using System.Collections.Generic;

namespace Exercises.Api.Models
{
    public class ProgramInstance{
        public int Id { get; set; }
        public int userId { get; set; }
        public int programId { get; set; }
        public List<WorkoutInstance> workouts { get; set; }
    }
}