using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercises.Api.Data;
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

            if (user == null) {
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
            }
        }
    }
}