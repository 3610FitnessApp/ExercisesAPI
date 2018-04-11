using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Api.Data
{
    public class ExerciseRepository
    {
        private readonly ExerciseContext _db;
        public ExerciseRepository(ExerciseContext db) 
        {
            _db = db;
        }

        public IEnumerable<ExerciseInstance> GetAllExerciseInstancesByUser(User user) {
            return _db.ExerciseInstances
                    .Where(p => p.user == user)
                    .OrderBy(d => d.Date)
                    .ToList();
        }

        public bool SaveAll(){
            return _db.SaveChanges() > 0;
        }
    }
}