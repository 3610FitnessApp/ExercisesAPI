using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Exercises.Api.Data
{
    public class ExerciseRepository
    {
        private readonly ExerciseContext _db;
        private readonly UserManager<User> _userManager;

        public ExerciseRepository(ExerciseContext db, UserManager<User> userManager) 
        {
            _db = db;
            _userManager = userManager;
        }

        public IEnumerable<ExerciseInstance> GetAllExerciseInstances() {
            
            return _db.ExerciseInstances
                    .Include(u => u.user)
                    .Include(e => e.exercise)
                    .OrderBy(d => d.Date)
                    .ToList();
        }

        public IEnumerable<Exercise> GetAllExercises() {
            
            return _db.Exercises
                    .ToList();
        }

        public IEnumerable<ExerciseInstance> GetAllExerciseInstancesByUser(string username) {
            
            
            return _db.ExerciseInstances
                    .Include(u => u.user)
                    .Include(e => e.exercise)
                    .Where(p => p.user.UserName == username)
                    .OrderBy(d => d.Date)
                    .ToList();
        }

        public void AddEntity (object model) {
            _db.Add(model);
        }


        public void DeleteEntity (object model) {
            _db.Remove(model);
        }

        public bool SaveAll(){
            return _db.SaveChanges() > 0;
        }
    }
}