using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercises.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace BodyParts.Api.Controllers
{
    [Route("api/[controller]")]
    public class BodyPartsController : Controller
    {
        private readonly ExerciseContext db;

        public BodyPartsController(ExerciseContext db)
        {
            
            this.db = db;
            if (this.db.BodyParts.Count() == 0)
            {
                this.db.BodyParts.Add(new BodyPart
                {
                    Id = 1,
                    name = "Arms"
                });

                this.db.BodyParts.Add(new BodyPart
                {
                    Id = 2,
                    name = "Legs"
                });

                this.db.SaveChanges();
            }

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.BodyParts);
        }

        [HttpGet("{id}", Name="GetBodyPart")]
        public IActionResult GetById(int Id)
        {
            var bodyPart = db.Workouts.Find(Id);

            if(bodyPart == null)
            {
                return NotFound();
            }

            return Ok(bodyPart);
        }

        [HttpPost]
        public IActionResult Post([FromBody]BodyPart bodyPart)
        {
            if(bodyPart == null)
            {
                return BadRequest();
            }
            this.db.BodyParts.Add(bodyPart);
            this.db.SaveChanges();

            return CreatedAtRoute("GetBodyPart", new { id = bodyPart.Id}, bodyPart);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int Id, [FromBody]BodyPart newBodyPart)
        {
            if (newBodyPart == null || newBodyPart.Id != Id)
            {
                return BadRequest();
            }
            var currentBodyPart = this.db.BodyParts.FirstOrDefault(x => x.Id == Id);

            if (currentBodyPart == null)
            {
                return NotFound();
            }

            currentBodyPart.name = newBodyPart.name;
            

            this.db.BodyParts.Update(currentBodyPart);
            this.db.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bodyPart = this.db.BodyParts.FirstOrDefault(x => x.Id == id);

            if (bodyPart == null)
            {
                return NotFound();
            }

            this.db.BodyParts.Remove(bodyPart);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}