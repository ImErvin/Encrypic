using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypic2017.Data
{
    class User
    {
        // Encapsulated variables that make up a user object.
        private string firstName; // User's first name
        private string surname; // User's surname
        private string username; // User's username (unique)
        private string password; // User's password
        private string secretkey; // User's secretkey (used to encrypt and decrypt messages)
        private string[] friends; // An array of the user's friend's usernames
        private DateTime createdAt; // Date of user creation

        // Getters and setters for the variables above.
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Secretkey
        {
            get { return secretkey; }
            set { secretkey = value; }
        }
        public string[] Friends
        {
            get { return friends; }
            set { friends = value; }
        }
        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

    }
}
