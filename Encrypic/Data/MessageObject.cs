using Encrypic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypic.Data
{
    class MessageObject
    {
        public UserObject messageFrom { get; set; }
        public UserObject messageTo { get; set; }
        public string sentAt { get; set; }
        public string secretKey { get; set; }
        public bool fileAttached { get; set; }
        public FileObject fileAttachement { get; set; }
        public string encryptedMessage { get; set; }
    }
}
