using System;

namespace Instagraph.DataProcessor.DTOModels
{
    public class UserDto
    {
        private string username;
        private string password;
        private string profilePicture;

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                //if (String.IsNullOrWhiteSpace(value) || value.Length >30)
                //{
                //    throw new ArgumentException("Error: Invalid data.");
                //}
                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                //if (String.IsNullOrWhiteSpace(value) || value.Length > 20)
                //{
                //    throw new ArgumentException("Error: Invalid data.");
                //}
                this.password = value;
            }
        }
        public string ProfilePicture
        {
            get
            {
                return this.profilePicture;
            }
            set
            {
            //    if (String.IsNullOrWhiteSpace(value))
            //    {
            //        throw new ArgumentException("Error: Invalid data.");
            //    }
                this.profilePicture = value;
            }
        }
    }
}
