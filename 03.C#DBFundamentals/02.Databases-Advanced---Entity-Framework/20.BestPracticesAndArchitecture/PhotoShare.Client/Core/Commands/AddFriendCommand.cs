using System.Linq;
using PhotoShare.Client.Core.Dtos;
using PhotoShare.Services.Contracts;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Contracts;

    public class AddFriendCommand : ICommand
    {
        private readonly IUserService userService;

        public AddFriendCommand(IUserService userService)
        {
            this.userService = userService;
        }

        // AddFriend <username1> <username2>
        public string Execute(string[] data)
        {
            string username = data[0];
            string friendUsername = data[1];

            var userExists = this.userService.Exists(username);
            var friendExists = this.userService.Exists(friendUsername);

            if (!userExists)
            {
                throw new ArgumentException($"{username} not found!");
            }

            if (!friendExists)
            {
                throw new ArgumentException($"{friendUsername} not found!");
            }

            var user = this.userService.ByUsername<UserFriendsDto>(username);
            var friend = this.userService.ByUsername<UserFriendsDto>(friendUsername);

            bool isSendRequestFromUser = user.Friends.Any(x => x.Username == friendUsername);
             bool isSendRequestFromFriend = friend.Friends.Any(x=>x.Username==user.Username);

            if (isSendRequestFromFriend && isSendRequestFromUser)
            {
                throw new InvalidOperationException($"{friend.Username} is already a friend to {user.Username}"); 
            }

            else if (isSendRequestFromUser && !isSendRequestFromFriend)
            {
                throw new InvalidOperationException("Request has already been sent!");
            }

            else if (!isSendRequestFromUser && isSendRequestFromFriend)
            {
                throw new InvalidOperationException("Request has already been sent!");
            }

            this.userService.AddFriend(user.Id, friend.Id);

            return $"Friend {friend.Username} added to {user.Username}";
        }
    }
}
