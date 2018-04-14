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
    [Route("api/[Controller]")]
    //[Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
    public class ExercisesController : Controller
    {
        private readonly ExerciseRepository _repository;
        private readonly ExerciseContext _db;


        public ExercisesController(ExerciseContext db, ExerciseRepository repository)
        {
            
            _db = db;
            _repository = repository;

        }

       
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAllExercises());
        }

        [HttpGet("{id}", Name="GetExercise")]
        public IActionResult GetById(int ID)
        {
            return Ok(_repository.GetExerciseID(ID));
        }

        [HttpGet("{name}")]
        public IActionResult getSearch(string exercise) => Ok(_repository.GetAllExerciseSearch(exercise));
    }
}