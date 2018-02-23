using Captions.DataMap.DataLoader;
using System;
using System.Data.Entity;
using System.Linq;

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

            // captions
            var captions = new CaptionLoader().LoadCaptions();
            captions.ForEach(s => context.Captions.Add(s));
            context.SaveChanges();

            // posts
            var posts = new PostLoader().LoadPosts();

            // assign captions to each post
            foreach (var post in posts)
            {
                var postCaptions = context.Captions.Take(new Random().Next(0, 10)).ToList();
                post.Captions = postCaptions;
            }
            posts.ForEach(s => context.Posts.Add(s));
            context.SaveChanges();

        }
    }
}