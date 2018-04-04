using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercises.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Exercises.Api.Controllers
{
    [Route("api/[controller]")]
    public class ExercisesController : Controller
    {
        private readonly ExerciseContext db;

        public ExercisesController(ExerciseContext db)
        {
            this.db = db;

            if (this.db.Exercises.Count() == 0)
            {
                this.db.Exercises.Add(new Exercise
                {
                    Id = 1,
                    name = "Bench Press"
                });

                this.db.Exercises.Add(new Exercise
                {
                    Id = 2,
                    name = "Hammer Curls"
                });

                this.db.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Exercises);
        }

        [HttpGet("{id}", Name="GetExercise")]
        public IActionResult GetById(int id)
        {
            var exercise = db.Exercises.Find(id);

            if(exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Exercise exercise)
        {
            if(exercise== null)
            {
                return BadRequest();
            }
            this.db.Exercises.Add(exercise);
            this.db.SaveChanges();

        return CreatedAtRoute("GetExercise", new { id = exercise.Id}, exercise);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Exercise newExercise)
        {
            if (newExercise == null || newExercise.Id != id)
            {
                return BadRequest();
            }
            var currentExercise = this.db.Exercises.FirstOrDefault(x => x.Id == id);

            if (currentExercise == null)
            {
                return NotFound();
            }

            currentExercise.name = newExercise.name;
            currentExercise.ExerciseBodyPart = newExercise.ExerciseBodyPart;

            this.db.Exercises.Update(currentExercise);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var exercise = this.db.Exercises.FirstOrDefault(x => x.Id == id);

            if (exercise == null)
            {
                return NotFound();
            }

            this.db.Exercises.Remove(exercise);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}


