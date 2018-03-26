using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercises.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace ProgramInstances.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProgramInstancesController : Controller
    {
        private readonly ExerciseContext db;

        public ProgramInstancesController(ExerciseContext db)
        {
            
            this.db = db;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.ProgramInstances);
        }

        [HttpGet("{id}", Name="GetProgramInstance")]
        public IActionResult GetById(int Id)
        {
            var programInstance = db.ProgramInstances.Find(Id);

            if(programInstance == null)
            {
                return NotFound();
            }

            return Ok(programInstance);
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProgramInstance programInstance)
        {
            if(programInstance == null)
            {
                return BadRequest();
            }
            this.db.ProgramInstances.Add(programInstance);
            this.db.SaveChanges();

            return CreatedAtRoute("GetProgramInstance", new { id = programInstance.Id}, programInstance);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int Id, [FromBody]ProgramInstance newProgramInstance)
        {
            if (newProgramInstance == null || newProgramInstance.Id != Id)
            {
                return BadRequest();
            }
            var currentProgramInstance = this.db.ProgramInstances.FirstOrDefault(x => x.Id == Id);

            if (currentProgramInstance == null)
            {
                return NotFound();
            }

            currentProgramInstance.userId = newProgramInstance.userId;
            currentProgramInstance.programId = newProgramInstance.programId;
            currentProgramInstance.workouts = newProgramInstance.workouts;
            

            this.db.ProgramInstances.Update(currentProgramInstance);
            this.db.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var programInstance = this.db.ProgramInstances.FirstOrDefault(x => x.Id == id);

            if (programInstance == null)
            {
                return NotFound();
            }

            this.db.ProgramInstances.Remove(programInstance);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}