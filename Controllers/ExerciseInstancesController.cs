using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercises.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseInstances.Api.Controllers
{
    [Route("api/[controller]")]
    public class ExerciseInstancesController : Controller
    {
        private readonly ExerciseContext db;

        public ExerciseInstancesController(ExerciseContext db)
        {
            
            this.db = db;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.ExerciseInstances);
        }

        [HttpGet("{id}", Name="GetExerciseInstance")]
        public IActionResult GetById(int Id)
        {
            var exerciseInstance = db.ExerciseInstances.Find(Id);

            if(exerciseInstance == null)
            {
                return NotFound();
            }

            return Ok(exerciseInstance);
        }

        [HttpPost]
        public IActionResult Post([FromBody]ExerciseInstance exerciseInstance)
        {
            if(exerciseInstance == null)
            {
                return BadRequest();
            }
            this.db.ExerciseInstances.Add(exerciseInstance);
            this.db.SaveChanges();

            return CreatedAtRoute("GetExerciseInstance", new { id = exerciseInstance.Id}, exerciseInstance);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int Id, [FromBody]ExerciseInstance newExerciseInstance)
        {
            if (newExerciseInstance == null || newExerciseInstance.Id != Id)
            {
                return BadRequest();
            }
            var currentExerciseInstance = this.db.ExerciseInstances.FirstOrDefault(x => x.Id == Id);

            if (currentExerciseInstance == null)
            {
                return NotFound();
            }

            currentExerciseInstance.weight = newExerciseInstance.weight;
            currentExerciseInstance.reps = newExerciseInstance.reps;
            currentExerciseInstance.sets = newExerciseInstance.sets;
            currentExerciseInstance.workoutId = newExerciseInstance.workoutId;
            currentExerciseInstance.exerciseId = newExerciseInstance.exerciseId;
            

            this.db.ExerciseInstances.Update(currentExerciseInstance);
            this.db.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var exerciseInstance = this.db.ExerciseInstances.FirstOrDefault(x => x.Id == Id);

            if (exerciseInstance == null)
            {
                return NotFound();
            }

            this.db.ExerciseInstances.Remove(exerciseInstance);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}