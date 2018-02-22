using Captions.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Captions.DataMap
{
    public class DataSeed  : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            // users
            var users = new UserLoader().LoadUsers();
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
            
        }
    }
}