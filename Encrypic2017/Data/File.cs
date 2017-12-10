using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypic2017.Data
{
    class File
    {
        // Encapsulated variables that make up a file object.
        private string encryptedB64;

        // Getters and setters for the variable above.
        public string EncryptedB64
        {
            get { return encryptedB64; }
            set { encryptedB64 = value; }
        }
    }
}
