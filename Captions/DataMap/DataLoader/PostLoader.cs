using Captions.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace Captions.DataMap.DataLoader
{
    public class PostLoader
    {

        public List<Post> LoadPosts()
        {
            var posts = new List<Post>();
            for(var i = 1; i < 50; i++)
            {
                var post = new Post
                {
                    PostTitle = i + ": " + RandomSentences(1, 1, 1, 5, 12),
                    PostContent = RandomSentences(2, 3, 7, 5, 20),
                    PostedBy = "Chris", 
                };

                posts.Add(post);
            }
            return posts;
        }     
        

        private string RandomSentences(int numberParagraphs, int minSentences,
            int maxSentences, int minWords, int maxWords)
        {
            string[] words = { "anemone", "wagstaff", "man", "the", "for",
            "and", "a", "with", "bird", "fox" };
            var text = new RandomText(words);
            text.AddContentParagraphs(numberParagraphs, minSentences, maxSentences, minWords, maxWords);
            string content = text.Content;

            return content;


        }
    }

    /// <summary>
    /// https://www.dotnetperls.com/random-paragraphs-sentences
    /// </summary>
    public class RandomText
    {
        static Random _random = new Random();
        StringBuilder _builder;
        string[] _words;

        public RandomText(string[] words)
        {
            _builder = new StringBuilder();
            _words = words;
        }

        public void AddContentParagraphs(int numberParagraphs, int minSentences,
            int maxSentences, int minWords, int maxWords)
        {
            for (int i = 0; i < numberParagraphs; i++)
            {
                AddParagraph(_random.Next(minSentences, maxSentences + 1),
                             minWords, maxWords);
                _builder.Append("\n\n");
            }
        }

        void AddParagraph(int numberSentences, int minWords, int maxWords)
        {
            for (int i = 0; i < numberSentences; i++)
            {
                int count = _random.Next(minWords, maxWords + 1);
                AddSentence(count);
            }
        }

        void AddSentence(int numberWords)
        {
            StringBuilder b = new StringBuilder();
            // Add n words together.
            for (int i = 0; i < numberWords; i++) // Number of words
            {
                b.Append(_words[_random.Next(_words.Length)]).Append(" ");
            }
            string sentence = b.ToString().Trim() + ". ";
            // Uppercase sentence
            sentence = char.ToUpper(sentence[0]) + sentence.Substring(1);
            // Add this sentence to the class
            _builder.Append(sentence);
        }

        public string Content
        {
            get
            {
                return _builder.ToString();
            }
        }
    }
}