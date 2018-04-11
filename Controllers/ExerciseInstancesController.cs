using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercises.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseInstances.Api.Controllers
{
    [Route("api/Exercises")]
    public class ExerciseInstancesController : Controller
    {
        private readonly ExerciseRepository _db;

        public ExerciseInstancesController(ExerciseRepository db)
        {
            
            _db = db;

        }

        [HttpGet]
        public IEnumerable<ExerciseInstance> GetByUser(User user)
        {
            return _db.GetAllExerciseInstancesByUser(user);
        }
    }
}