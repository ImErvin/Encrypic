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
        public string firstName { get; set; } // User's first name
        public string surname { get; set; } // User's surname
        public string username { get; set; } // User's username (unique)
        public string password { get; set; } // User's password
        public string secretkey { get; set; } // User's secretkey (used to encrypt and decrypt messages)
        public string friends { get; set; } // An array of the user's friend's usernames
        public DateTime createdAt { get; set; } // Date of user creation
        public string profilePicture { get; set; } // Users profile picture base64 string

        public User()
        {

        }

    }
}
