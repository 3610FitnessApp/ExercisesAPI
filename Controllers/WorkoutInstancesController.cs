using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercises.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace WorkoutInstances.Api.Controllers
{
    [Route("api/[controller]")]
    public class WorkoutInstancesController : Controller
    {
        private readonly ExerciseContext db;

        public WorkoutInstancesController(ExerciseContext db)
        {
            
            this.db = db;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.WorkoutInstances);
        }

        [HttpGet("{id}", Name="GetWorkoutInstance")]
        public IActionResult GetById(int id)
        {
            var workoutInstance = db.WorkoutInstances.Find(id);

            if(workoutInstance == null)
            {
                return NotFound();
            }

            return Ok(workoutInstance);
        }

        [HttpPost]
        public IActionResult Post([FromBody]WorkoutInstance workoutInstance)
        {
            if(workoutInstance == null)
            {
                return BadRequest();
            }
            this.db.WorkoutInstances.Add(workoutInstance);
            this.db.SaveChanges();

            return CreatedAtRoute("GetWorkoutInstance", new { id = workoutInstance.Id}, workoutInstance);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]WorkoutInstance newWorkoutInstance)
        {
            if (newWorkoutInstance == null || newWorkoutInstance.Id != id)
            {
                return BadRequest();
            }
            var currentWorkoutInstance = this.db.WorkoutInstances.FirstOrDefault(x => x.Id == id);

            if (currentWorkoutInstance == null)
            {
                return NotFound();
            }

            currentWorkoutInstance.date = newWorkoutInstance.date;
            currentWorkoutInstance.userId = newWorkoutInstance.userId;
            currentWorkoutInstance.workoutId = newWorkoutInstance.workoutId;
            currentWorkoutInstance.exercises = newWorkoutInstance.exercises;

            this.db.WorkoutInstances.Update(currentWorkoutInstance);
            this.db.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var workoutInstance = this.db.WorkoutInstances.FirstOrDefault(x => x.Id == id);

            if (workoutInstance == null)
            {
                return NotFound();
            }

            this.db.WorkoutInstances.Remove(workoutInstance);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}