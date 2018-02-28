using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercises.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Workouts.Api.Controllers
{
    [Route("api/[controller]")]
    public class WorkoutsController : Controller
    {
        private readonly ExerciseContext db;
        public WorkoutsController(ExerciseContext db)
        {
            
            this.db = db;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Workouts);
        }
        [HttpGet("{id}", Name="GetWorkout")]
        public IActionResult GetById(int id)
        {
            var workout = db.Workouts.Find(id);

            if(workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }
        [HttpPost]
        public IActionResult Post([FromBody]Workout workout)
        {
            if(workout == null)
            {
                return BadRequest();
            }
        this.db.Workouts.Add(workout);
        this.db.SaveChanges();

        return CreatedAtRoute("GetWorkout", new { id = workout.Id}, workout);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Workout newWorkout)
        {
            if (newWorkout == null || newWorkout.Id != id)
            {
                return BadRequest();
            }
            var currentWorkout = this.db.Workouts.FirstOrDefault(x => x.Id == id);

            if (currentWorkout == null)
            {
                return NotFound();
            }

            currentWorkout.Exercise = newWorkout.Exercise;
            currentWorkout.WorkoutDate = newWorkout.WorkoutDate;

            this.db.Workouts.Update(currentWorkout);
            this.db.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var workout = this.db.Workouts.FirstOrDefault(x => x.Id == id);

            if (workout == null)
            {
                return NotFound();
            }

            this.db.Workouts.Remove(workout);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}


