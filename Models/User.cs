using System;
using Microsoft.AspNetCore.Identity;

namespace Exercises.Api.Data
{
    public class User : IdentityUser{

        public int userId { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int skillLevel { get; set; }
        public int weight { get; set; }
        public int height { get; set; }

    }
}