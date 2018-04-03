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

            return CreatedAtRoute("GetUser", new { id = user.Id}, user);
        }

        
}}