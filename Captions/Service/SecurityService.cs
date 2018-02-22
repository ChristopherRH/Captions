using Captions.DataMap;
using Captions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Captions.Service
{
    public class SecurityService
    {

        /// <summary>
        /// Check to see if the user has admin access
        /// </summary>
        /// <returns></returns>
        public static bool HasAdminAccess()
        {
            var user = GetLoggedInUser();
            if (user == null) return false;
            return user.Role == User.UserRoles.Admin || user.Role == User.UserRoles.Super;
        }


        /// <summary>
        /// Gets the current session user
        /// </summary>
        /// <returns></returns>
        public static User GetLoggedInUser()
        {
            var userId = HttpContext.Current.Session[nameof(User)];
            return new DataContext().Users.Find(userId);
        }
    }
}