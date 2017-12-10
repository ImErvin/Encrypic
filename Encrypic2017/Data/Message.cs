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
        private User messageFrom; // Who sent the message
        private User messageTo; // Who is to recieve/recieved the message
        private DateTime sentAt; // Date and time of message creation
        private string secretkey; // The secret key that encrypted the message
        private bool fileAttached; // A boolean to notify if there is a file attached
        private File fileAttachment; // The file
        private string encryptedMessage; // The encrypted message
        private DateTime expireAt; // A date and time of when the message will expire

        // Getters and setters for the variables above.
        public User MessageFrome
        {
            get { return messageFrom; }
            set { messageFrom = value; }
        }
        public User MessageTo
        {
            get { return messageTo; }
            set { messageTo = value; }
        }
        public DateTime SentAt
        {
            get { return sentAt; }
            set { sentAt = value; }
        }
        public string Secretkey
        {
            get { return secretkey; }
            set { secretkey = value; }
        }
        public bool FileAttached
        {
            get { return fileAttached; }
            set { fileAttached = value; }
        }
        public File FileAttachment
        {
            get { return fileAttachment; }
            set { fileAttachment = value; }
        }
        public string EncryptedMessage
        {
            get { return encryptedMessage; }
            set { encryptedMessage = value; }
        }
        public DateTime ExpireAt
        {
            get { return expireAt; }
            set { expireAt = value; }
        }

    }
}
