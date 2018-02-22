using Captions.Models;
using System.Collections.Generic;

namespace Captions.DataMap
{
    public class PostLoader
    {
        
        public List<Post> LoadPosts()
        {
            return new List<Post>
            {
                new Post{PostTitle="First Post", PostContent = "This is the first post!", PostedBy="Chris" }, 
                new Post{PostTitle="Second Post", PostContent = "This is the second post!", PostedBy="Carl" },  
                new Post{PostTitle="Third Post", PostContent = "This is the third post!", PostedBy="Jessie" },
                new Post{PostTitle="Fourth Post", PostContent = "This is the fourth post!",PostedBy="TestUser" }
            };

        }
    }
}