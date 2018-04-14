using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercises.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Exercises.Api.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Exercises.Api.Controllers
{
    [Route("api/exercises")]
    //[Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
    public class ExercisesController : Controller
    {
        private readonly ExerciseRepository _repository;
        private readonly ExerciseContext db;


        public ExercisesController(ExerciseContext db, ExerciseRepository repository)
        {
            
           this.db = db;
            _repository = repository;

        }

       
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAllExercises());
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

        [HttpGet("{name}", Name="GetExerciseSearch")]
        public IActionResult getSearch(string exercise)
        {
            return Ok(_repository.GetAllExerciseSearch(exercise));
        }
    }
}