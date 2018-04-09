using System;
using Microsoft.AspNetCore.Identity;

namespace Exercises.Api.Data
{
    public class User : IdentityUser{

        public string lastName { get; set; }
        public string firstName { get; set; }
        public int skillLevel { get; set; }
        public int weight { get; set; }
        public int height { get; set; }

    }
}