using System;

namespace Exercises.Api.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Weight { get; set; }
        public int Repetitions { get; set; }
        public int Sets { get; set; }
        
    }
}