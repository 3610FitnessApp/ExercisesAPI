//Used to map a JSON post to a model we can use
//to login a User. Used for AccountsController.Login.

using System;
using System.Collections.Generic;

namespace Exercises.Api.Models.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}