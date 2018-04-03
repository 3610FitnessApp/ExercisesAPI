using System;
using System.Collections.Generic;

namespace Exercises.Api.Data
{
    public class AccountModel
    {
       public string UserName { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int skillLevel { get; set; }
        public int weight { get; set; }
        public int height { get; set; }
    }
}