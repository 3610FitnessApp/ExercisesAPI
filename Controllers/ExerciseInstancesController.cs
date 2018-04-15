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

namespace ExerciseInstances.Api.Controllers
{
    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
    public class ExerciseInstancesController : Controller
    {
        private readonly ExerciseRepository _repository;
        private readonly ExerciseContext _db;

        private readonly UserManager<User> _userManager;

        public ExerciseInstancesController(ExerciseContext db, ExerciseRepository repository, 
        UserManager<User> userManager)
        {
            
            _db = db;
            _repository = repository;
            _userManager = userManager;

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExerciseViewModel model)
        {
            var currentUser = await _userManager.FindByNameAsync(model.userName);
            var exercise = _db.Exercises.SingleOrDefault(ex => ex.name == model.exercise);
            var newExerciseInstance = new ExerciseInstance() 
            {
                Date = model.ExerciseDate,
                user = currentUser,
                //Id = model.ExerciseInstanceId,
                weight = model.weight,
                reps = model.reps,
                sets = model.sets,
                exercise = exercise
            };
            if (newExerciseInstance.Date == DateTime.MinValue) {
                newExerciseInstance.Date = DateTime.Now;
            }
            _repository.AddEntity(newExerciseInstance);
            _repository.SaveAll();

            return Created($"/api/ExerciseInstances/{model.ExerciseInstanceId}", model);
        }

        [Route("Edit")]
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] ExerciseViewModel model)
        {
            var currentUser = await _userManager.FindByNameAsync(model.userName);
            var exercise = _db.Exercises.SingleOrDefault(ex => ex.name == model.exercise);
            var newExerciseInstance = new ExerciseInstance() 
            {
                Date = model.ExerciseDate,
                user = currentUser,
                Id = model.ExerciseInstanceId,
                weight = model.weight,
                reps = model.reps,
                sets = model.sets,
                exercise = exercise
            };
            if (newExerciseInstance.Date == DateTime.MinValue) {
                newExerciseInstance.Date = DateTime.Now;
            }

            _repository.DeleteEntity(newExerciseInstance);
            _repository.SaveAll();
            _repository.AddEntity(newExerciseInstance);
            _repository.SaveAll();

            return Created($"/api/ExerciseInstances/{model.ExerciseInstanceId}", model);
        }
    }
}