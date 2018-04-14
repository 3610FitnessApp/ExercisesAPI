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
        public IEnumerable<Exercise> GetExerciseID(int ID) {
            
            return _db.Exercises
                    .Include(e => e.name)
                    .Where(p => p.Id == ID)
                    .ToList();
        }
       
         public IEnumerable<Exercise> GetAllExerciseSearch(string searchExercise) {
            
           
       // get { return "SELECT ID,Description,Price FROM Catalog WHERE Description LIKE '%'+@SearchTerm+'%'
            

            return _db.Exercises
                    .Include(d => d.name)
                    .Where(s => s.name == searchExercise)
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

        public bool SaveAll(){
            return _db.SaveChanges() > 0;
        }
    }
}