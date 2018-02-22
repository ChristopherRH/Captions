using Captions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Captions.Service
{
    public class LoginService
    {

        /// <summary>
        /// If this user is validated, log them in
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        public static bool ValidateUserLogin(User user, string password)
        {
            return user.Password.Equals(DataContextService.ComputeHash(password));
        }
    }
}