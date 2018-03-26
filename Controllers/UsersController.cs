using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercises.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Users.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ExerciseContext db;

        public UsersController(ExerciseContext db)
        {
            
            this.db = db;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Users);
        }

        [HttpGet("{id}", Name="GetUser")]
        public IActionResult GetById(int userId)
        {
            var user = db.Users.Find(userId);

            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            this.db.Users.Add(user);
            this.db.SaveChanges();

            return CreatedAtRoute("GetUser", new { id = user.userId}, user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int userId, [FromBody]User newUser)
        {
            if (newUser == null || newUser.userId != userId)
            {
                return BadRequest();
            }
            var currentUser = this.db.Users.FirstOrDefault(x => x.userId == userId);

            if (currentUser == null)
            {
                return NotFound();
            }

            currentUser.lastName = newUser.lastName;
            currentUser.firstName = newUser.firstName;
            currentUser.email = newUser.email;
            currentUser.username = newUser.username;
            currentUser.password = newUser.password;
            currentUser.height = newUser.height;
            currentUser.weight = newUser.weight;
            currentUser.skillLevel = newUser.skillLevel;
            

            this.db.Users.Update(currentUser);
            this.db.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = this.db.Users.FirstOrDefault(x => x.userId == id);

            if (user == null)
            {
                return NotFound();
            }

            this.db.Users.Remove(user);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}