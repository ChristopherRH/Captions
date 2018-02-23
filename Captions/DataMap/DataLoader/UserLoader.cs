using Captions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Captions.DataMap.DataLoader
{
    public class UserLoader
    {
        
        public List<User> LoadUsers()
        {
            return new List<User>
            {
                new User{Name="Chris", Role = User.UserRoles.Super, Password = "chris"},
                new User{Name="Carl", Role = User.UserRoles.Admin, Password = "Carl"},
                new User{Name="Jessie", Role = User.UserRoles.Member, Password = "jessie"},
                new User{Name="TestUser1", Role = User.UserRoles.Member, Password = "test1"}
            };

        }
    }
}