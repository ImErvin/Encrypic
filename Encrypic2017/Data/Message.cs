using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypic2017.Data
{
    class Message
    {
        // Encapsulated variables that make up a message object.
        public string messageFrom { get; set; } // Who sent the message
        public string messageTo { get; set; } // Who is to recieve/recieved the message
        public string sentAt { get; set; }// Date and time of message creation
        public string secretkey { get; set; } // The secret key that encrypted the message
        public bool fileAttached { get; set; }// A boolean to notify if there is a file attached
        public string fileAttachment { get; set; } // The image
        public string expireAt { get; set; }// A date and time of when the message will expire
    }
}
