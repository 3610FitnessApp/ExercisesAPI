using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercises.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseInstances.Api.Controllers
{
    [Route("api/[Controller]")]
    public class ExerciseInstancesController : Controller
    {
        private readonly ExerciseRepository _repository;
        private readonly ExerciseContext _db;

        public ExerciseInstancesController(ExerciseContext db, ExerciseRepository repository)
        {
            
            _db = db;
            _repository = repository;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAllExerciseInstances());
        }

       
       [HttpGet("{username}")]
        public IActionResult Get(string username)
        {

            return Ok(_repository.GetAllExerciseInstancesByUser(username));
        }
    }
}