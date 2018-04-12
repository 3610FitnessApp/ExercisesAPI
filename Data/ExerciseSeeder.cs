//This file seeds our database with simple data.
//Called at startup only when the app is in development mode.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercises.Api.Data;
using Exercises.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Exercises.Api.Data
{
    public class ExerciseSeeder {
        private readonly ExerciseContext _db;
        private readonly UserManager<User> _userManager;

        public ExerciseSeeder (ExerciseContext db, UserManager<User> userManager) {
            _db = db;
            _userManager = userManager;
        }

        public async Task Seed() {
            
            _db.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("brettbrun@gmail.com");
            

            if (!_db.ExerciseInstances.Any())
            {
                //seeding simple user data into database
                user = new User {
                    firstName = "Brett",
                    lastName = "Brunswick",
                    UserName = "brettbrun@gmail.com",
                    Email = "brettbrun@gmail.com"
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if(result != IdentityResult.Success) {
                    throw new InvalidOperationException("Failed to create default user");
                }


                var exercise2 = new Exercise() {
                Id = 1,
                name = "Bench Press",
                ExerciseBodyPart = null
                };

            var exerciseInstance2 = new ExerciseInstance() {
                Id = 1,
                weight = 225,
                reps = 10,
                sets = 4,
                exercise = exercise2,
                user = user,
                Date = DateTime.Now
                };

                var exercise = new Exercise() {
                Id = 2,
                name = "Squat",
                ExerciseBodyPart = null
                };

            var exerciseInstance = new ExerciseInstance() {
                Id = 2,
                weight = 315,
                reps = 4,
                sets = 6,
                exercise = exercise,
                user = user,
                Date = DateTime.Now
                };

                _db.Exercises.Add(exercise2);
                _db.ExerciseInstances.Add(exerciseInstance2);
                _db.Exercises.Add(exercise);
                _db.ExerciseInstances.Add(exerciseInstance);
                _db.SaveChanges();
            }
            
        }
    }
}