//The controller that will take care of registering users, logging
//users in, and creating cookies for users that logged in.
//UsersController may not be necessary in our app.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercises.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Exercises.Api.Models.ViewModels;


namespace Accounts.Api.Controllers
{
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

        //Used to Create a new User. UserManager takes care of adding the User to our db
        //so db.add is not neccessary here.
        [Route("api/Accounts/Register")]
        [HttpPost]
        public async Task <IdentityResult> Register([FromBody] RegisterViewModel model)
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
                    var exceptionText = result.Errors.Aggregate("User Creation Failed - Identity Exception. Errors were: \n\r\n\r", (current, error) => current + (" - " + error + "\n\r"));
                    throw new Exception (exceptionText);
                } else {
                    return result;
                }
            } else {
                    throw new InvalidOperationException("This email is already in use.");
            }
        }

    }
}