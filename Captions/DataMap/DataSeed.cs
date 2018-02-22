using Captions.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Captions.DataMap
{
    // todo: Don't want to drop and create always, just drop and rebuild every table with seed data
    // probably only the tables that have model changes
    public class DataSeed : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            // application values
            var applicationValues = new ApplicationValueLoader().LoadApplicationValues();
            applicationValues.ForEach(s => context.ApplicationValues.Add(s));
            context.SaveChanges();

            // users
            var users = new UserLoader().LoadUsers();
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
            
        }
    }
}