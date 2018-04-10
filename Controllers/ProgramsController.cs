using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercises.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Programs.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProgramsController : Controller
    {
        private readonly ExerciseContext db;

        public ProgramsController(ExerciseContext db)
        {
            
            this.db = db;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Programs);
        }

        [HttpGet("{id}", Name="GetProgram")]
        public IActionResult GetById(int Id)
        {
            var program = db.Programs.Find(Id);

            if(program == null)
            {
                return NotFound();
            }

            return Ok(program);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Program program)
        {
            if(program == null)
            {
                return BadRequest();
            }
            this.db.Programs.Add(program);
            this.db.SaveChanges();

            return CreatedAtRoute("GetProgram", new { id = program.Id}, program);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int Id, [FromBody]Program newProgram)
        {
            if (newProgram == null || newProgram.Id != Id)
            {
                return BadRequest();
            }
            var currentProgram = this.db.Programs.FirstOrDefault(x => x.Id == Id);

            if (currentProgram == null)
            {
                return NotFound();
            }

            currentProgram.programName = newProgram.programName;
            currentProgram.daysPerWeek = newProgram.daysPerWeek;
            currentProgram.week = newProgram.week;
            currentProgram.Workouts = newProgram.Workouts;
            

            this.db.Programs.Update(currentProgram);
            this.db.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var program = this.db.Programs.FirstOrDefault(x => x.Id == id);

            if (program == null)
            {
                return NotFound();
            }

            this.db.Programs.Remove(program);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}