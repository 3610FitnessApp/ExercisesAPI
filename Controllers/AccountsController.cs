using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercises.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Accounts.Api.Controllers
{
    //[Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly ExerciseContext db;
        private readonly ILogger<AccountsController> _logger;


        public AccountsController(ExerciseContext db, ILogger<AccountsController> logger)

        {
            
            this.db = db;
            _logger = logger;

        }

        [Route("api/Accounts/Register")]
        [HttpPost]
        public IActionResult Post([FromBody] AccountModel model)
        //IdentityResult
        {
            var userStore = new UserStore<User>(db);
            //var manager = new UserManager<User>(userStore, null, null, null, null, null, null, null, null);
            var user = new User() { UserName = model.UserName, Email = model.Email };
            user.firstName = model.firstName;
            user.lastName = model.lastName;
            user.skillLevel = model.skillLevel;
            //manager.CreateAsync(user, model.Password);
            db.AspNetUsers.Add(user);
            db.SaveChanges();
            return CreatedAtRoute("GetUser", new { id = user.Id}, user);
        }
    }
}