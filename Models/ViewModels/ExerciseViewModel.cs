//Used to map a JSON post to a model we can use
//to login a User. Used for AccountsController.Login.

using System;
using System.Collections.Generic;
using Exercises.Api.Data;

namespace Exercises.Api.Models.ViewModels
{
    public class ExerciseViewModel
    {
        public int ExerciseInstanceId { get; set; }
        public int weight { get; set; }
        public int reps { get; set; }
        public int sets { get; set; }
        public string exercise { get; set; }

        //Setting User to this instance.
        public string userName { get; set; }

        public DateTime ExerciseDate { get; set; }

    }
}