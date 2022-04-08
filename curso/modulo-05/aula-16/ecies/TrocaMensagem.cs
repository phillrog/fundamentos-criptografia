using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecc
{
    public class TrocaMensagem
    {
        public TrocaMensagem() { }
        public TrocaMensagem(string cipher, string initializationVector, string authenticationTag)
        {
            Cipher = cipher;
            InitializationVector = initializationVector;
            AuthenticationTag = authenticationTag;
        }

        public string Cipher { get; set; }
        public string InitializationVector { get; set; }
        public string AuthenticationTag { get; set; }
    }
}
