using System;
using System.Collections.Generic;

namespace Exercises.Api.Data
{
    public class ProgramInstance{
        public int Id { get; set; }
        public int userId { get; set; }
        public Program program { get; set; }
        public List<WorkoutInstance> workouts { get; set; }

       //Setting a User to this instance.
        public User user { get; set; }

        public DateTime Date { get; set; }
    }
}