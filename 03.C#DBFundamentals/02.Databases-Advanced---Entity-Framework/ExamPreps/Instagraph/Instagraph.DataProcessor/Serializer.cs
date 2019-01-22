using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Instagraph.Data;
using Instagraph.DataProcessor.DTOModels;
using Newtonsoft.Json;

namespace Instagraph.DataProcessor
{
    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var posts = context.Posts
                .Where(p => p.Comments.Count == 0)
                .Select(p => new
                {
                    p.Id,
                    Picture = p.Picture.Path,
                    User = p.User.Username
                });

            var json = JsonConvert.SerializeObject(posts);

            return json;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            var users = context.Users
                .Where(u => u.Posts
                    .Any(p => p.Comments
                        .Any(c => u.Followers
                            .Select(f => f.Follower)
                            .Any(fol => fol == c.User))))
                .Select(u => new
                {
                    u.Username,
                    Followers = u.Followers.Count
                })
                .ToArray();


            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            var users = context.Users
                .Select(u => new
                {
                    Username = u.Username,
                    PostCommentCount = u.Posts
                    .Select(p => p.Comments.Count).ToArray()
                });

            var userDtos = new List<UserTopPostDto>();

            var xDoc = new XDocument(new XElement("users"));

            foreach (var u in users)
            {
                int mostComments = 0;

                if (u.PostCommentCount.Any())
                {
                    mostComments = u.PostCommentCount.OrderByDescending(c => c).First();
                }

                var userDto = new UserTopPostDto()
                {
                    Username = u.Username,
                    MostComments = mostComments
                };

                userDtos.Add(userDto);
            }

            userDtos = userDtos.OrderByDescending(u => u.MostComments)
                .ThenBy(u => u.Username).ToList();

            foreach (var u in userDtos)
            {
                xDoc.Root.Add(new XElement("user", 
                    new XElement("Username", u.Username),
                    new XElement("MostComments", u.MostComments)));
            }


            string result = xDoc.ToString();
            return result;
        }
    }
}