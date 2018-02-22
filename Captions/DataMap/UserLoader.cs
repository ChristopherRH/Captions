using Captions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Captions.DataMap
{
    public class UserLoader
    {
        
        public List<User> LoadUsers()
        {
            return new List<User>
            {
                new User{Name="Admin", Role="Admin", Password = "admin"}
            };

        }
    }
}