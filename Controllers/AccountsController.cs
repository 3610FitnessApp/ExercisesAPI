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

        private readonly UserManager<User> _userManager;

        public AccountsController(ExerciseContext db, ILogger<AccountsController> logger,
        UserManager<User> userManager)

        {
            
            this.db = db;
            _logger = logger;
            _userManager = userManager;

        }

        /*[Route("api/Accounts/Register")]
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
        }*/

        [Route("api/Accounts/Register")]
        [HttpPost]
        public async Task Register([FromBody] AccountModel model)
        //IdentityResult
        {
            var userCheck = await _userManager.FindByEmailAsync(model.Email);
            if (userCheck == null) {
                var newUser = new User {
                    firstName = model.firstName,
                    lastName = model.lastName,
                    UserName = model.UserName,
                    Email = model.Email
                };
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if(result != IdentityResult.Success) {
                    throw new InvalidOperationException("Failed to Register");
                }
            } else {
                    throw new InvalidOperationException("This email is already in use.");
            }
        }

    }
}